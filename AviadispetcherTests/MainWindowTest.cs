using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aviadispetcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aviadispetcher.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void SelectXTest()
        {
            FlightList expected = new FlightList();
            expected.Add(new Flight(7, "КА-199", "Київ", TimeSpan.Parse("00:55:00"), 6));
            expected.Add(new Flight(12, "LL-000", "Київ", TimeSpan.Parse("07:22:00"), 3));
            var target = new MainWindow();
            object sender = target;
            RoutedEventArgs e = null;
            target.InitializeComponent();
            target.InfoFlightForm_Loaded(sender, e);
            target.SelectXMenuItem_Click(sender, e);
            string cityX = "Київ";
            List<Flight> actual = SelectData.SelectX(expected, cityX);
            if (expected.Flights_list.Count != actual.Count)
            {
                Assert.Fail();
            }
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected.Flights_list.ElementAt(i), actual.ElementAt(i));
            }
        }

        [TestMethod()]
        public void SelectXYTest()
        {
            FlightList expected = new FlightList();
            expected.Add(new Flight(5, "КМ-608", "Мюнхен", TimeSpan.Parse("15:30:00"), 2));
            expected.Add(new Flight(8, "КМ-602", "Мюнхен", TimeSpan.Parse("07:35:00"), 32));
            var target = new MainWindow();
            object sender = target;
            RoutedEventArgs e = null;
            target.InitializeComponent();
            target.InfoFlightForm_Loaded(sender, e);
            target.SelectXYMenuItem_Click(sender, e);
            string cityX = "Мюнхен";
            TimeSpan time = TimeSpan.Parse("20:00:00");
            List<Flight> actual = SelectData.SelectXY(expected, cityX, time);
            if (expected.Flights_list.Count != actual.Count)
            {
                Assert.Fail();
            }
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected.Flights_list.ElementAt(i), actual.ElementAt(i));
            }
        }

        [TestMethod()]
        public void FillCityListTest()
        {
            var target = new MainWindow();
            object sender = target;
            RoutedEventArgs e = null;
            target.InitializeComponent();
            target.InfoFlightForm_Loaded(sender, e);
            target.SelectXMenuItem_Click(sender, e);
            List<string> expected = new List<string>();
            expected.Add("Київ");
            expected.Add("Львів");
            expected.Add("Париж");
            expected.Add("Лондон");
            expected.Add("Відень");
            expected.Add("Мюнхен");
            expected.Add("Берлін");
            expected.Add("Мадрид");
            List<string> actual = target.allCities;
            Assert.IsTrue(expected.Count == actual.Count);
            int expSize = expected.Count;
            int actSize = 0;
            for (int i = 0; i < expected.Count; ++i)
            {
                for (int j = 0; j < expected.Count; ++j)
                {
                    if (expected.ElementAt(i).Equals(actual.ElementAt(j)))
                    {
                        actSize += 1;
                    }
                        
                }
            }
            Assert.IsTrue(actSize == expSize);
        }
    }
}