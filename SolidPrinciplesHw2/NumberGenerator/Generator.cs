namespace SolidPrinciplesHw2.NumberGenerator
{
    public class Generator
    {
        public int GenerateInt(int minValue, int maxValue)
        {
            Random rnd = new Random();
            return rnd.Next(minValue, maxValue + 1);
        }
    }
}
