namespace SolidPrinciplesHw2.Logger
{
    public class SinkConsoleLogger : Logger
    {
        public override void Log(LogLevel level, string message)
        {
            string formattedMessage = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} [{level.ToString()}] {message}";
            
            switch (level)
            {
                case LogLevel.Info:
                    Console.WriteLine(formattedMessage);
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(formattedMessage);
                    Console.ResetColor();
                    break;
            }
        }
    }
}
