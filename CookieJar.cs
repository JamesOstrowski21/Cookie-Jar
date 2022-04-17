using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class CookieJar
    {
        public CookieJar()
        {

        }
        public CookieJar(int max, int sMax)
        {
            maxCookies = max;
            sugarMax = sMax;
        }

        public List<Cookie> cookies { get; set; } = new List<Cookie>();
        public Dictionary<string, double> children = new Dictionary<string, double>();
        public int maxCookies { get; set; }
        public int amountCookies => cookies.Count();
        public double sugarMax { get; set; }
        public void depositCookies(List<Cookie> cookie)
        {
            int x;
            if (cookie.Count() < maxCookies - amountCookies)
            {
                x = cookie.Count();
            }
            else
            {
                x = maxCookies - amountCookies;
            }

            for (int y = 0; y < x; y++)
            {
                cookies.Add(cookie[y]);
                
            }
            Console.WriteLine("Deposited: " + x + " Cookies");

        }

        public Cookie RequestCookie(string cName)
        {
            bool keyexists = children.ContainsKey(cName);
            if (!keyexists)
            {
                children.Add(cName, sugarMax);
            }

            if (cookies.Count() > 0)
            {
                for (int x = cookies.Count() - 1; x >= 0; x--)
                {
                    if (cookies[x].sugarContent <= children[cName])
                    {
                        children[cName] = children[cName] - cookies[x].sugarContent;
                        Cookie c = cookies[x];
                        cookies.Remove(cookies[x]);
                        return c;

                    }

                }
                return null;

            }
            else
            {
                return null;
            }
        }
        public double AverageSugar()
        {
            IEnumerable<double> _sugar = cookies.Select(cookie => cookie.sugarContent);
            double averageSugar = _sugar.Average();
            return averageSugar;
        }

        public int CookieTypeCount(string typeWanted)
        {
            IEnumerable<Cookie> type = cookies.Where(cookie => cookie.type == typeWanted);
            int count = type.Count();
            return count;
        }

        public void removeExpired()
        {
            IEnumerable<Cookie> expired = cookies.Where(cookie => (DateTime.Now.Date - (cookie.baked.Date)).Days >= 7);

            foreach (Cookie c in expired.Reverse())
            {
                cookies.Remove(c);
            }


        }


    }
}
