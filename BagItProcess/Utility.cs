namespace BagItProcess
{
    using System;
    using System.Configuration;
    using System.IO;

    /// <summary>
    /// Defines the <see cref="Logger" />
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Defines the _logFileName
        /// </summary>
        private static string _logFileName = ConfigurationManager.AppSettings["LogFileName"];

        /// <summary>
        /// Defines the _logFileNameDateFormat
        /// </summary>
        private static string _logFileNameDateFormat = ConfigurationManager.AppSettings["LogFileNameDateFormat"];

        /// <summary>
        /// Defines the _LOCK
        /// </summary>
        private static Object _LOCK = new Object();

        /// <summary>
        /// log the process execution
        /// </summary>
        /// <param name="logType">The logType<see cref="LogType"/></param>
        /// <param name="dateTime">The dateTime<see cref="DateTime"/></param>
        /// <param name="title">The title<see cref="String"/></param>
        /// <param name="body">The body<see cref="String"/></param>
        private static void Log(LogType logType, DateTime dateTime, String title, String body)
        {
            lock (_LOCK)
            {
                var logDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\Logs";
                var ArchiveDirectory = logDirectory + "\\Archive";
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }
                var logFileName = _logFileName + "_" + DateTime.Now.ToString(_logFileNameDateFormat);
                var logFile = Path.Combine(logDirectory, logFileName + ".txt");

                foreach (string fileName in Directory.GetFiles(logDirectory, _logFileName + "*.txt"))
                {
                    if (fileName != logFile)
                    {
                        if (!Directory.Exists(ArchiveDirectory))
                            Directory.CreateDirectory(ArchiveDirectory);
                        var archiveFileName = Path.Combine(ArchiveDirectory, Path.GetFileName(fileName));
                        if (File.Exists(archiveFileName))
                            File.Delete(archiveFileName);
                        File.Move(fileName, archiveFileName);
                    }
                }
                using (StreamWriter writer = new StreamWriter(logFile, true))
                {
                    writer.WriteLine(String.Format("{0} {1} {2}", logType == LogType.Success ? "++++++++" : "--------", title, dateTime.ToString("MM/dd/yyyy HH:mm:ss")));
                    writer.WriteLine(body);
                    if (title != "Information")
                        writer.WriteLine(Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// The LogSuccess
        /// </summary>
        /// <param name="Message">The Message<see cref="String"/></param>
        public static void LogSuccess(String Message)
        {
            Log(LogType.Success, DateTime.Now, LogType.Success.ToString(), Message);
        }

        /// <summary>
        /// The LogInformation
        /// </summary>
        /// <param name="Message">The Message<see cref="String"/></param>
        public static void LogInformation(String Message)
        {
            Log(LogType.Success, DateTime.Now, LogType.Information.ToString(), Message);
        }

        /// <summary>
        /// The LogException
        /// </summary>
        /// <param name="stackTrace">The stackTrace<see cref="String"/></param>
        public static void LogException(String stackTrace)
        {
            Log(LogType.Error, DateTime.Now, LogType.Error.ToString(), stackTrace);
        }

        /// <summary>
        /// The GetConfigValueByKey
        /// </summary>
        /// <param name="key">The key<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetConfigValueByKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }

    /// <summary>
    /// Defines the LogType
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// Defines the Success
        /// </summary>
        Success,

        /// <summary>
        /// Defines the Error
        /// </summary>
        Error,

        /// <summary>
        /// Defines the Information
        /// </summary>
        Information
    }

    /// <summary>
    /// Defines the <see cref="Utility" />
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// The GetConfigValueByKey
        /// </summary>
        /// <param name="key">The key<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetConfigValueByKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
