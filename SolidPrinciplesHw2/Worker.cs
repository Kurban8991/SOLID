using Microsoft.Extensions.Options;
using SolidPrinciplesHw2.NumberGenerator;
using SolidPrinciplesHw2.Settings;

namespace SolidPrinciplesHw2
{
    public sealed class Worker
    {
        public Worker(MyGenerator generator, IOptions<GameRulesSetting> gameOptions, Logger.Logger logger)
        {
            _generator = generator;
            _gameOptions = gameOptions.Value;
            _logger = logger;
        }

        public void Run()
        {
            while (_gameOptions.Attempts > 0)
            {
                var min = Convert.ToInt32(_gameOptions.MinValue);
                var max = Convert.ToInt32(_gameOptions.MaxValue);
                var randomNumber = _generator.GenerateInt(min, max);

                _logger.Log(Logger.Logger.LogLevel.Info, "Type in the number");
                var number = Convert.ToInt32(Console.ReadLine());

                if (randomNumber == number)
                {
                    _logger.Log(Logger.Logger.LogLevel.Info, "You've guessed");
                }
                else
                {
                    _logger.Log(Logger.Logger.LogLevel.Info, "You didn't guess");
                }

                _logger.Log(Logger.Logger.LogLevel.Info, $"Number of tries: {--_gameOptions.Attempts}");
            }
        }

        private readonly MyGenerator _generator;
        private readonly GameRulesSetting _gameOptions;
        private readonly Logger.Logger _logger;
    }
}
