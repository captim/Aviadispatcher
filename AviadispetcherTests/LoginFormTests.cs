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
    public class LoginFormTests
    {
        [TestMethod()]
        public void LoginFormTest()
        {
            SelectXTest();
        }
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
    }
}