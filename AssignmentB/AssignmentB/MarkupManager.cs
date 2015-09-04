using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentB
{
    public class MarkupManager
    {
        public List<Itinerary> CalculateMarkup(Itinerary published, List<Itinerary> discounted)
        {
             List<Itinerary> markupAnswer = new List<Itinerary>();
            foreach (Itinerary dis in discounted)
            {
                if (IsAllDataSame(published, dis))
                    markupAnswer.Add(CalculateMarkupWithSameData(published, dis));
                else if (published.NumberOfStops > dis.NumberOfStops)
                    markupAnswer.Add(CalculateMarkupWithlessNoOfStops(published, dis));
                else if (published.NumberOfStops < dis.NumberOfStops)
                    markupAnswer.Add(CalculateMarkupWithMoreNoOfStops(published, dis));
            }
            return markupAnswer;
        }
        public bool IsAllDataSame(Itinerary published,Itinerary discounted)
        {
            if(published.NumberOfStops==discounted.NumberOfStops)
                return true;
            return false;
        }
        public Itinerary CalculateMarkupWithSameData(Itinerary published, Itinerary discounted)
        {
            if ((published.BaseFareInUSD - discounted.BaseFareInUSD) > 15)
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD - 10;
            return discounted;
        }
        public Itinerary CalculateMarkupWithlessNoOfStops(Itinerary published, Itinerary discounted)
        {
            
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD + 10;
            return discounted;
        }
        public Itinerary CalculateMarkupWithMoreNoOfStops(Itinerary published, Itinerary discounted)
        {
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD - 10;
            
              return discounted;
        }

    }
}
