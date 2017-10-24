using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace dojodachi
{
    
 
// Somewhere in your namespace, outside other classes
public static class SessionExtensions
{
    // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        // This helper function simply serializes theobject to JSON and stores it as a string in session
        session.SetString(key, JsonConvert.SerializeObject(value));
    }
       
    // generic type T is a stand-in indicating that we need to specify the type on retrieval
    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        string value = session.GetString(key);
        // Upon retrieval the object is deserialized based on the type we specified
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
}
    public class Dachi
    {
        private Random rand = new Random();
        public int happiness;
        public int fullness;
        public int energy;
        public int meals;
        public Dachi()
        {
            happiness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
        }

        public string isDone(){
            if(happiness <=0 || fullness<=0)
            {
                return "dead";
            }
            if(happiness>100 && fullness>100 && energy>100)
            {
                return "win";
            }
            return "false";
        }

        public string feeding()
        {
            if(meals<=0)
            {
                return "You're out of meals to feed! Try working some";
            }
            meals--;
            if(rand.Next(0,4)>0)
            {
                int amt = rand.Next(5,11);
                fullness+=amt;
                return $"You fed your dachi! His fullness increased by {amt}!";
            }
            else
            {
                return "Dachi didn't like that... ";
            }

        }

        public string playing()
        {
            if(energy<=4)
            {
                return "Your dachi is too tired to play now. Try sleeping some";
            }
            energy-=5;
            if(rand.Next(0,4)>0)
            {
                int amt = rand.Next(5,11);
                happiness+=amt;
                return $"You played with your dachi! His happiness increased by {amt}!";
            }
            else
            {
                return "Dachi didn't like that... ";
            }
        }

        public string working()
        {
            if(energy<=4)
            {
                return "Your dachi is too tired to work now. Try sleeping some";
            }
            energy-=5;
            int amt = rand.Next(1,4);
            meals+=amt;
            return $"Dachi worked! He earned {amt} meals.";
        }

        public string sleeping()
        {
            energy+=15;
            fullness-=5;
            happiness-=5;
            return "Dachi slept! His energy increased by 15!";
        }
    }
}