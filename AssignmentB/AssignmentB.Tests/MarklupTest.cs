using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AssignmentB.Tests
{
    [TestClass]
    public class MarklupTest
    {
        [TestMethod]
        public void AllFactorsSame_Test()
        {
            Itinerary publishedRateObject = new Itinerary();
            publishedRateObject.BaseFareInUSD = 100;

            List<Itinerary> discountedRates = new List<Itinerary>();
            Itinerary discountedOne = new Itinerary();
            discountedOne.BaseFareInUSD = 75;
            discountedRates.Add(discountedOne);

            Itinerary discountedTwo = new Itinerary();

            discountedTwo.BaseFareInUSD = 75;
            discountedRates.Add(discountedTwo);

            List<Itinerary> markupAnswer = new List<Itinerary>();
            MarkupManager markupManager = new MarkupManager();
            markupAnswer = markupManager.CalculateMarkup(publishedRateObject, discountedRates);


            decimal[] expected = { 25, 25 };
            decimal[] actual = new decimal[2];
            int i = 0;
            foreach (Itinerary dis in markupAnswer)
            {
                actual[i] = dis.MarkupInUSD;
                i++;
            }
            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void NumberOfStopsOrTotalLAyoutDifferent_Test()
        {
            Itinerary publishedRateObject = new Itinerary();
            publishedRateObject.BaseFareInUSD = 100;
            publishedRateObject.NumberOfStops = 3;
          

            List<Itinerary> discountedRates = new List<Itinerary>();
            Itinerary discountedOne = new Itinerary();
            discountedOne.BaseFareInUSD = 75;
            discountedOne.NumberOfStops = 2;
            discountedRates.Add(discountedOne);


            Itinerary discountedTwo = new Itinerary();

            discountedTwo.BaseFareInUSD = 85;
            discountedTwo.NumberOfStops = 4;
            discountedRates.Add(discountedTwo);

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

        [TestMethod]
        public void NumberOfStopsAndTotalLAyoutDifferent_Test()
        {
            Itinerary publishedRateObject = new Itinerary();
            publishedRateObject.BaseFareInUSD = 100;
            publishedRateObject.NumberOfStops = 3;
            publishedRateObject.TotalLayoverTime = new TimeSpan(0,2,3,4,5);


            List<Itinerary> discountedRates = new List<Itinerary>();
            Itinerary discountedOne = new Itinerary();
            discountedOne.BaseFareInUSD = 75;
            discountedOne.NumberOfStops = 2;
            discountedOne.TotalLayoverTime = new TimeSpan(0, 3, 3, 4, 5);

            discountedRates.Add(discountedOne);


            Itinerary discountedTwo = new Itinerary();

            discountedTwo.BaseFareInUSD = 75;
            discountedTwo.NumberOfStops = 4;
            discountedTwo.TotalLayoverTime = new TimeSpan(0, 3, 3, 4, 5);
            discountedRates.Add(discountedTwo);

            List<Itinerary> markupAnswer = new List<Itinerary>();
            MarkupManager markupManager = new MarkupManager();
            markupAnswer = markupManager.CalculateMarkup(publishedRateObject, discountedRates);

            decimal[] answer = { 25, 5 };
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
        [ExpectedException(typeof(NullReferenceException))]
        public void ExceptionOccured()
        {
            Itinerary publishedRateObject=null;
            List<Itinerary> discountedRates = new List<Itinerary>();
            Itinerary discountedOne = new Itinerary();
            discountedOne.BaseFareInUSD = 75;
            discountedOne.NumberOfStops = 2;
            discountedRates.Add(discountedOne);


            Itinerary discountedTwo = new Itinerary();

            discountedTwo.BaseFareInUSD = 85;
            discountedTwo.NumberOfStops = 4;
            discountedRates.Add(discountedTwo);

            MarkupManager markupManager = new MarkupManager();
            var markupAnswer = markupManager.CalculateMarkup(publishedRateObject, discountedRates);
        }
    }
}
