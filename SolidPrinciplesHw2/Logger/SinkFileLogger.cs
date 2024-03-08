namespace SolidPrinciplesHw2.Logger
{
    public class SinkFileLogger : Logger, IDisposable
    {
        public override void Log(LogLevel level, string message)
        {
            string formattedMessage = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} [{level.ToString()}] {message}";

            switch (level)
            {
                case LogLevel.Info:
                    LogToFile(formattedMessage);
                    break;
                case LogLevel.Error:
                    LogToFile(formattedMessage);
                    break;
            }
        }

        public void Dispose()
        {
            sw.Dispose();
        }

        private void LogToFile(string message)
        {
            if (!File.Exists(PATH_TO_FILE))
            {
                File.Create(PATH_TO_FILE).Dispose();
            }

            sw.WriteLine(message);
            Dispose();
        }

        private StreamWriter sw = new StreamWriter(PATH_TO_FILE, true);
        private const string PATH_TO_FILE = "MyLog.txt";
    }
}
