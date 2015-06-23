using System;

namespace FortyOne.AudioSwitcher.HotKeyData
{
    [Flags]
    public enum Modifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8,
        All = Alt | Control | Shift | Win
    }
}