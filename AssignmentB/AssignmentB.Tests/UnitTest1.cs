using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AssignmentB.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AllSameData()
        {
            Itinerary publishedRateObject = new Itinerary();
            publishedRateObject.BaseFareInUSD = 100;

            List<Itinerary> discountedRates = new List<Itinerary>();
            Itinerary discounted = new Itinerary();
            discounted.BaseFareInUSD = 75;
            discountedRates.Add(discounted);

            Itinerary discounted1 = new Itinerary();

            discounted1.BaseFareInUSD = 75;
            discountedRates.Add(discounted1);

            List<Itinerary> markupAnswer = new List<Itinerary>();
             MarkupManager markupManager = new MarkupManager();
            markupAnswer = markupManager.CalculateMarkup(publishedRateObject, discountedRates);


            decimal[] answer = {15,15};
            decimal[] answer2 = new decimal[2];
            int i = 0;
            foreach (Itinerary dis in markupAnswer)
            {
                answer2[i] = dis.MarkupInUSD;
                i++;
            }
            CollectionAssert.AreEqual(answer, answer2);

        }
        [TestMethod]
        public void AllDifferentData()
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

            decimal[] answer = { 35, 5 };
            decimal[] answer2 = new decimal[2];
            int i = 0;
            foreach (Itinerary dis in markupAnswer)
            {
                answer2[i] = dis.MarkupInUSD;
                i++;
            }
            CollectionAssert.AreEqual(answer, answer2);
        }

    }
}
