namespace SolidPrinciplesHw2.Logger
{
    public class FileLogger : ILogger, IDisposable
    {
        public void Log(string message)
        {
            if (!File.Exists(PATH_TO_FILE))
            {
                File.Create(PATH_TO_FILE).Dispose();
            }

            sw.WriteLine(message);
            Dispose();
        }

        public void Dispose()
        {
            sw.Dispose();
        }

        private StreamWriter sw = new StreamWriter(PATH_TO_FILE, true);
        private const string PATH_TO_FILE = "MyLog.txt";
    }
}
