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
            if (published.Equals(null))
                throw new NullReferenceException();

            List<Itinerary> markupAnswer = new List<Itinerary>();
            foreach (Itinerary discount in discounted)
            {
                if (IsAllDataSame(published, discount))
                    markupAnswer.Add(CalculateMarkupWithSameData(published, discount));

                else if (published.NumberOfStops > discount.NumberOfStops)
                    markupAnswer.Add(CalculateMarkupWithlessNoOfStops(published, discount));

                else if (published.NumberOfStops < discount.NumberOfStops)
                    markupAnswer.Add(CalculateMarkupWithMoreNoOfStops(published, discount));
                else if (published.TotalLayoverTime > discount.TotalLayoverTime)
                    markupAnswer.Add(CalculateMarkupWithlesslLayoverTime(published, discount));
                else
                    markupAnswer.Add(CalculateMarkupWithMoreNoOfStops(published,discount));
            }
            return markupAnswer;
        }

        public bool IsAllDataSame(Itinerary published, Itinerary discounted)
        {
            if (published.NumberOfStops == discounted.NumberOfStops)
                return true;
            return false;
        }

        public Itinerary CalculateMarkupWithSameData(Itinerary published, Itinerary discounted)
        {
            
            discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD;
            return discounted;
        }

        public Itinerary CalculateMarkupWithlessNoOfStops(Itinerary published, Itinerary discounted)
        {
            if(published.TotalLayoverTime > discounted.TotalLayoverTime )
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD + 20;
            else if (published.TotalLayoverTime < discounted.TotalLayoverTime)
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD;
            else
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD + 10;
            return discounted;
        }

        public Itinerary CalculateMarkupWithMoreNoOfStops(Itinerary published, Itinerary discounted)
        {
            if (published.TotalLayoverTime > discounted.TotalLayoverTime)
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD;
            else if (published.TotalLayoverTime < discounted.TotalLayoverTime)
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD-20;
            else
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD - 10;
            
            return discounted;
        }
        public Itinerary CalculateMarkupWithlesslLayoverTime(Itinerary published, Itinerary discounted)
        {
            if (published.NumberOfStops > discounted.NumberOfStops)
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD + 20;
            else
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD + 10;
            return discounted;
        }

        public Itinerary CalculateMarkupWithMorelLayoverTime(Itinerary published, Itinerary discounted)
        {
            if (published.NumberOfStops > discounted.NumberOfStops)
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD - 20;
            else
                discounted.MarkupInUSD = published.BaseFareInUSD - discounted.BaseFareInUSD - 10;
            return discounted;
        }
    }
}