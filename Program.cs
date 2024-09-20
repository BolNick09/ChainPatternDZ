namespace ChainPatternDZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AbstractHandler aHandler = new GreetingHandler(new WeatherHandler(new DefaultHandler()));


            string message = "Привет! Какая погода сегодня в Москве?";
            Console.WriteLine(message);
            aHandler.Handle(message);
        }
    }
}
