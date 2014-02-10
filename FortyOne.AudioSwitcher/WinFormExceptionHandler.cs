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
        public static void OnThreadException(Object sender, ThreadExceptionEventArgs t)
        {
            HandleException(t.Exception, null);
        }

        /// <summary>
        ///     Event handler implementation for the ApplicationThreadException event
        /// </summary>
        /// <param name="sender">Application sending the event</param>
        /// <param name="t">UnhandledExceptionEventArgs</param>
        public static void OnUnhandledCLRException(Object sender, UnhandledExceptionEventArgs t)
        {
            HandleException((Exception) t.ExceptionObject, null);
        }

        /// <summary>
        ///     Static method to invoke the UI to display the exception. Gives user the option to log or not in the UI.
        /// </summary>
        /// <param name="ex">The exception to display.</param>
        public static void HandleException(Exception ex)
        {
            HandleException(ex, null);
        }

        public static void HandleException(Exception ex, string caption)
        {
            HandleSystemException(ex, caption);
        }

        private static void HandleSystemException(Exception ex, string caption)
        {
            string title = "An Unhandled Error Occurred";
            string text = string.Empty;
            if (caption != null)
                text = caption + Environment.NewLine;

            var edf = new ExceptionDisplayForm(title, text, ex);
            edf.ShowDialog();
        }
    }
}