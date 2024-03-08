namespace SolidPrinciplesHw2.Logger
{
    public abstract class Logger
    {
        public abstract void Log(LogLevel level, string message);
        
        public enum LogLevel
        {
            Info,
            Error
        }
    }
}
