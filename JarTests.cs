using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2;
using System.Linq;
using System.Collections.Generic;
using System;

namespace CookieJarTests
{
    [TestClass]
    public class JarTests
    {
        [TestMethod]
        public void CookieTypeCount_GivesStringofType_ReturnsAmountofThatType()
        {
            //Arrange
            CookieJar jar = new CookieJar(20, 20);
            List<Cookie> cookie = new List<Cookie>();
            for (int y = 0; y < 10; y++)
            {
                cookie.Add(new Cookie("Chocolate Chip", 10, DateTime.Parse("2/22/2022")));
            }
            jar.depositCookies(cookie);

            //ACT
            int calculated = jar.CookieTypeCount("Chocolate Chip");

            //ASSERT
            int expected = 10;
            Assert.AreEqual(expected, calculated);
        }

        [TestMethod]
        public void RequestCookie_NameofChild_ReturnsCookieAvailabletoThatChild()
        {
            //Arrange
            CookieJar jar = new CookieJar(20, 20);
            List<Cookie> cookie = new List<Cookie>();
            for (int y = 0; y < 10; y++)
            {
                cookie.Add(new Cookie("Chocolate Chip", 10, DateTime.Parse("2/22/2022")));
                cookie.Add(new Cookie("Peanut Butter", 25, DateTime.Parse("2/22/2022")));
            }
            jar.depositCookies(cookie);

            //ACT
            Cookie request = jar.RequestCookie("Johnny");
            double testsugar = request.sugarContent;

            //ASSERT
            double expected = 10;
            Assert.AreEqual(expected, testsugar);
        }

        [TestMethod]
        public void removeExpired_GivesNothing_removesExpiredCookiesFromJar ()
        {
            //Arrange
            CookieJar jar = new CookieJar(20, 20);
            List<Cookie> cookie = new List<Cookie>();
            for (int y = 0; y < 10; y++)
            {
                cookie.Add(new Cookie("Chocolate Chip", 10, DateTime.Parse("2/22/2022")));
            }
            DateTime current = DateTime.Now;
            DateTime weekAgo = current.AddDays(-7).Date;
            cookie.Add(new Cookie("Peanut Butter", 10, weekAgo));
            jar.depositCookies(cookie);

            //ACT
            jar.removeExpired();

            //ASSERT
            int expected = 0;
            Assert.AreEqual(expected, jar.amountCookies);
        }

    }
}
