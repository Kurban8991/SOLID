namespace SolidPrinciplesHw2.NumberGenerator
{
    public class MyGenerator : Generator
    {
        // просто пример, играть с числами в диапазоне long будет тяжело
        public long GenerateLong(long minValue, long maxValue)
        {
            Random rnd = new Random();
            return rnd.NextInt64(minValue, maxValue + 1);
        }
    }
}
