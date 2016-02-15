using Microsoft.VisualStudio.TestTools.UITesting;

namespace codedui_demo.uitests
{
    /// <summary>
    /// Thanks to http://stackoverflow.com/a/20406849/129269 for some playback settings tweaks for speedup.
    /// </summary>
    static class SpeedUp
    {
        /// <summary>
        /// Invoke this method from the TestInitialize because it only then affects the playback.
        /// </summary>
        public static void Setup()
        {
            // Configure the playback engine
            Playback.PlaybackSettings.WaitForReadyLevel = Microsoft.VisualStudio.TestTools.UITest.Extension.WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.MaximumRetryCount = 10;
            Playback.PlaybackSettings.ShouldSearchFailFast = false;
            Playback.PlaybackSettings.DelayBetweenActions = 500;
            Playback.PlaybackSettings.SearchTimeout = 1000;
            // Add the error handler
            Playback.PlaybackError -= Playback_PlaybackError; // Remove the handler if it's already added
            Playback.PlaybackError += Playback_PlaybackError; // Ta dah...
        }

        /// <summary> PlaybackError event handler. </summary>
        private static void Playback_PlaybackError(object sender, PlaybackErrorEventArgs e)
        {
            // Wait a second
            System.Threading.Thread.Sleep(1000);
            // Retry the failed test operation
            e.Result = PlaybackErrorOptions.Retry;
        }
    }
}