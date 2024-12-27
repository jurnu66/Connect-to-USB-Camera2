namespace Connect_to_USB_Camera2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize application configuration
            ApplicationConfiguration.Initialize();

            // Run the main form
            Application.Run(new MainForm());
        }
    }
}
