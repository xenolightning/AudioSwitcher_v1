using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using AudioSwitcher.AudioApi;

namespace FortyOne.AudioSwitcher.HotKeyData
{
    public class HotKey : IDisposable
    {
        /// <summary>
        ///     Register a hotkey combination of one or more Modifers and a Key.
        /// </summary>
        /// <remarks>
        ///     This method uses the values of the Modifiers and Key properties.  If
        ///     Modifiers == Modifiers.None and Key = Keys.None then any current hotkey combination
        ///     represented by this instance is deactivated.  Calling this method a subsequent time with
        ///     a different combination will cause the current combination to be replaced and the new hotkey
        ///     combination installed.  If the hotkey registration process fails (for example the hotkey combination
        ///     is already registered) then a Win32Exception is thrown.
        /// </remarks>
        public bool IsRegistered;

        public HotKey()
        {
            Modifiers = Modifiers.None;
            Key = Keys.None;
        }

        /// <summary>
        ///     The deviceID the hot key is used for
        /// </summary>
        public Guid DeviceId { get; set; }

        public IDevice Device
        {
            get { return AudioDeviceManager.Controller.GetDevice(DeviceId); }
        }

        public string DeviceName
        {
            get { return Device.FullName; }
        }

        public string HotKeyString
        {
            get
            {
                var keystring = "";
                if ((Modifiers & Modifiers.Alt) > 0)
                    keystring += "Alt+";
                if ((Modifiers & Modifiers.Control) > 0)
                    keystring += "Ctrl+";
                if ((Modifiers & Modifiers.Shift) > 0)
                    keystring += "Shift+";
                if ((Modifiers & Modifiers.Win) > 0)
                    keystring += "Win+";
                keystring += Key.ToString();

                return keystring;
            }
        }

        /// <summary>
        ///     Get/Set the HotKeyNativeWindow instance used to capture WM_HOTKEY messages
        ///     for this instance.
        /// </summary>
        private HotKeyNativeWindow HotKeyWindow { get; set; }

        /// <summary>
        ///     Get/Set the modifier or modifers to use to activate this hotkey
        /// </summary>
        public Modifiers Modifiers { get; set; }

        /// <summary>
        ///     Get/Set the virtual key code as the actual hotkey.
        /// </summary>
        /// <remarks>
        ///     While it is possible to combine multiple keycodes together, it is likely that under
        ///     many circumstances you will have an inoperative hotkey.  Also, you should not use any of the
        ///     Keys modifier keys.
        /// </remarks>
        public Keys Key { get; set; }

        public void Dispose()
        {
            // unregister the current hotkey...
            if (HotKeyWindow != null)
                HotKeyWindow.UnregisterHotkey();
        }

        /// <summary>
        ///     Event fired when this instance receives a WM_HOTKEY message.
        /// </summary>
        public event EventHandler HotKeyPressed;

        public bool RegisterHotkey()
        {
            if (HotKeyWindow == null)
                HotKeyWindow = new HotKeyNativeWindow(this);

            try
            {
                if (Key != Keys.None)
                {
                    HotKeyWindow.RegisterHotkey();
                }
                else
                {
                    if (HotKeyWindow.Handle != IntPtr.Zero)
                        HotKeyWindow.DestroyHandle();
                    HotKeyWindow = null;
                }

                IsRegistered = true;
            }
            catch
            {
                if (HotKeyWindow.Handle != IntPtr.Zero)
                    HotKeyWindow.DestroyHandle();
                HotKeyWindow = null;

                IsRegistered = false;
            }

            return IsRegistered;
        }

        /// <summary>
        ///     Register a hotkey combination of one or more Modifers and a Key.
        /// </summary>
        /// <param name="modifiers">The modifier or modifiers to use to activate the hotkey</param>
        /// <param name="key">The actual hotkey value</param>
        /// <remarks>
        ///     This method uses the values of the modifers and key parameters to set the Modifiers and Key properties, and
        ///     then delegates to the RegisterHotkey() function.  See remarks for that function to understand the behavior of
        ///     this method.
        /// </remarks>
        public void RegisterHotkey(Modifiers modifiers, Keys key)
        {
            Modifiers = modifiers;
            Key = key;
            RegisterHotkey();
        }

        public void UnregsiterHotkey()
        {
            if (IsRegistered && HotKeyWindow != null)
                HotKeyWindow.UnregisterHotkey();

            IsRegistered = false;
        }

        /// <summary>
        /// </summary>
        /// <param name="hWnd">The handle of the window to force to the front.</param>
        public void ActivateWindow(IntPtr hWnd)
        {
            var hForeground = NativeMethods.GetForegroundWindow();
            if (hWnd != hForeground)
            {
                var hForegroundThread = NativeMethods.GetWindowThreadProcessId(hForeground, IntPtr.Zero);
                var hCurrentThread = NativeMethods.GetWindowThreadProcessId(hWnd, IntPtr.Zero);

                if (hForegroundThread != hCurrentThread)
                {
                    NativeMethods.AttachThreadInput(hForegroundThread, hCurrentThread, true);
                    NativeMethods.SetForegroundWindow(hWnd);
                    NativeMethods.AttachThreadInput(hForegroundThread, hCurrentThread, false);
                }
                else
                {
                    NativeMethods.SetForegroundWindow(hWnd);
                }

                if (NativeMethods.IsIconic(hWnd))
                {
                    NativeMethods.ShowWindow(hWnd, NativeMethods.ShowWindowCommand.SW_RESTORE);
                }
                else
                {
                    NativeMethods.ShowWindow(hWnd, NativeMethods.ShowWindowCommand.SW_SHOW);
                }
            }
        }

        /// <summary>
        ///     Raises the HotkeyPressed event on WM_HOTKEY notification
        /// </summary>
        protected virtual void OnHotKey()
        {
            if (HotKeyPressed != null)
                HotKeyPressed(this, new EventArgs());
        }

        /// <summary>
        ///     Handles the capturing of the WM_HOTKEY messages as well as registering/unregistering
        ///     the hotkey via Win32 API.
        /// </summary>
        private class HotKeyNativeWindow : NativeWindow
        {
            private const int WM_HOTKEY = 0x312;
            private static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

            public HotKeyNativeWindow(HotKey owner)
            {
                Owner = owner;
            }

            private HotKey Owner { get; set; }
            private short HotKeyID { get; set; }

            ~HotKeyNativeWindow()
            {
                try
                {
                    UnregisterHotkey();
                }
                catch
                {
                }
            }

            public override void DestroyHandle()
            {
                UnregisterHotkey();
                base.DestroyHandle();
            }

            public override void ReleaseHandle()
            {
                UnregisterHotkey();
                base.ReleaseHandle();
            }

            public void RegisterHotkey()
            {
                if (HandleCreated() && Owner.Key != Keys.None)
                {
                    if (HotKeyID == 0)
                        HotKeyID = NativeMethods.GlobalAddAtom(Guid.NewGuid().ToString("N"));

                    if (!NativeMethods.RegisterHotKey(Handle, HotKeyID, (int) Owner.Modifiers, (int) Owner.Key))
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                }
            }

            public void UnregisterHotkey()
            {
                if (Handle != IntPtr.Zero && HotKeyID != 0)
                {
                    NativeMethods.UnregisterHotKey(Handle, HotKeyID);
                    NativeMethods.GlobalDeleteAtom(HotKeyID);
                    HotKeyID = 0;
                }
            }

            private bool HandleCreated()
            {
                if (Handle == IntPtr.Zero)
                {
                    var createParams = new CreateParams();
                    createParams.Caption = Guid.NewGuid().ToString("N");
                    createParams.Style = 0;
                    createParams.ExStyle = 0;
                    createParams.ClassStyle = 0;
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        createParams.Parent = HWND_MESSAGE;
                    }
                    CreateHandle(createParams);
                }
                return (Handle != IntPtr.Zero);
            }

            protected override void WndProc(ref Message m)
            {
                // handle a hotkey event..
                if (m.Msg == WM_HOTKEY)
                {
                    Owner.OnHotKey();
                    UnregisterHotkey();

                    var input = new InputSimulator();

                    var mods = new List<VirtualKeyCode>();

                    if (Owner.Modifiers == Modifiers.Shift)
                        mods.Add(VirtualKeyCode.SHIFT);

                    if (Owner.Modifiers == Modifiers.Control)
                        mods.Add(VirtualKeyCode.CONTROL);

                    if (Owner.Modifiers == Modifiers.Alt)
                        mods.Add(VirtualKeyCode.LMENU);

                    if (Owner.Modifiers == Modifiers.Win)
                        mods.Add(VirtualKeyCode.LWIN);

                    if (mods.Count > 0)
                        input.Keyboard.ModifiedKeyStroke(mods, (VirtualKeyCode) Owner.Key);
                    else
                        input.Keyboard.KeyPress((VirtualKeyCode) Owner.Key);

                    RegisterHotkey();
                }

                base.WndProc(ref m);
            }
        }
    }
}