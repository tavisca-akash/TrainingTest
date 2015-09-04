using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentB;
namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Itinerary publishedRateObject = new Itinerary();
            publishedRateObject.BaseFareInUSD = 100;
            publishedRateObject.NumberOfStops = 3;

            List<Itinerary> discountedRates = new List<Itinerary>();
            Itinerary discounted = new Itinerary();
            discounted.BaseFareInUSD = 75;
            discounted.NumberOfStops = 2;
            discountedRates.Add(discounted);


            Itinerary discounted1 = new Itinerary();

            discounted1.BaseFareInUSD = 85;
            discounted1.NumberOfStops = 4;
            discountedRates.Add(discounted1);

            List<Itinerary> markupAnswer = new List<Itinerary>();
            MarkupManager markupManager = new MarkupManager();
            markupAnswer = markupManager.CalculateMarkup(publishedRateObject, discountedRates);
            foreach (Itinerary dis in markupAnswer)
            {
                Console.WriteLine(dis.TotalFareInUSD);
            }
            Console.ReadKey();
        }
    }
}
