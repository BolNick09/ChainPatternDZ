using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainPatternDZ
{
    public abstract class AbstractHandler
    {
        protected AbstractHandler nextHandler;
        public AbstractHandler() 
        {
            nextHandler = null;
        }

        public AbstractHandler (AbstractHandler handler)
        {
            this.nextHandler = handler;
        }

        public abstract void Handle(string message);
    }
    public class GreetingHandler : AbstractHandler
    {
        public GreetingHandler(AbstractHandler handler) : base(handler)
        {
        }

        public override void Handle(string message)
        {
            if (message.ToLower().Contains("привет"))
            {
                Console.WriteLine("Здравствуйте! Я чат-бот, расскажу погоду в вашем городе.");
                if (nextHandler != null)                
                    nextHandler.Handle(message);                
            }
            else if (nextHandler != null)                
                nextHandler.Handle(message); 
        }
    }

    public class WeatherHandler : AbstractHandler
    {
        public WeatherHandler(AbstractHandler handler) : base(handler) { }


        public override void Handle(string message)
        {
            if (message.ToLower().Contains("погода"))
            {
                Console.WriteLine("В Москве +22, солнечно, без осадков.");
                if (nextHandler != null)                
                    nextHandler.Handle(message);
                
            }
            else if (nextHandler != null)                
                nextHandler.Handle(message);  
        }
    }

    public class DefaultHandler : AbstractHandler
    {
        public DefaultHandler(AbstractHandler handler) : base(handler) { }
        public DefaultHandler() : base() 
        {
            //nextHandler = null;
        }

        public override void Handle(string message)
        {
            if (nextHandler != null)            
                nextHandler.Handle(message);            
            else            
               Console.WriteLine("Что???");            
        }
    }

}
