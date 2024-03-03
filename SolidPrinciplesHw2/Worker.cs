using Microsoft.Extensions.Options;
using SolidPrinciplesHw2.NumberGenerator;
using SolidPrinciplesHw2.Settings;
using SolidPrinciplesHw2.Logger;

namespace SolidPrinciplesHw2
{
    public sealed class Worker
    {
        public Worker(MyGenerator generator, IOptions<GameRulesSetting> gameOptions,ILogger logger)
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
                var max = Convert.ToInt32(_gameOptions.MinValue);
                var randomNumber = _generator.GenerateInt(min, max);

                _logger.Log("Type in the number");
                var number = Convert.ToInt32(Console.ReadLine());

                if (randomNumber == number)
                {
                    _logger.Log("You've guessed");
                }
                else
                {
                    _logger.Log("You didn't guess");
                }

                _logger.Log($"Number of tries: {_gameOptions.Attempts--}");
            }
        }

        private readonly MyGenerator _generator;
        private readonly GameRulesSetting _gameOptions;
        private readonly ILogger _logger;
    }
}
