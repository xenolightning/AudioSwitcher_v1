using System;
using System.Threading;

namespace FortyOne.AudioSwitcher
{
    /// <summary>
    ///     This class handles the brokering of exceptions to a graphical and optionally into the exception management
    ///     application block
    /// </summary>
    public class WinFormExceptionHandler
    {
        /// <summary>
        ///     Event handler implementation for the ApplicationThreadException event
        /// </summary>
        /// <param name="sender">Application sending the event</param>
        /// <param name="t">ThreadExceptionEventArgs</param>
        public static void OnThreadException(object sender, ThreadExceptionEventArgs t)
        {
            HandleException(t.Exception, null);
        }

        /// <summary>
        ///     Event handler implementation for the ApplicationThreadException event
        /// </summary>
        /// <param name="sender">Application sending the event</param>
        /// <param name="t">UnhandledExceptionEventArgs</param>
        public static void OnUnhandledCLRException(object sender, UnhandledExceptionEventArgs t)
        {
            HandleException((Exception) t.ExceptionObject, null);
        }

        public static void HandleException(Exception ex, string caption)
        {
            HandleSystemException(ex, caption);
        }

        private static void HandleSystemException(Exception ex, string caption)
        {
            //Ignore com timeouts
            if (ex is TimeoutException && ex.Message.IndexOf("COM operation", StringComparison.OrdinalIgnoreCase) >= 0)
                return;

            var edf = new ExceptionDisplayForm("An Unhandled Error Occurred", ex);
            edf.ShowDialog();
        }
    }
}