using System.IO;
using System;

namespace MyApp.Models.Common
{
    public static class Logger
    {
        private static readonly string LogDirectory = Path.Combine(
                 Directory.GetCurrentDirectory(), // Get the current project root directory
                 "wwwroot",
                 "Logs"
             );

        static Logger()
        {
            // Ensure the log directory exists
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        public static void WriteLog(string message, string logType)
        {
            try
            {
                string logFilePath = Path.Combine(LogDirectory, $"{DateTime.Now:yyyy-MM-dd}.txt");
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logType}] {message}";

                // Append the log message to the file
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write log: {ex.Message}");
            }
        }

        public static void WriteException(Exception ex)
        {
            WriteLog($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}", "ERROR");
        }
    }
}
