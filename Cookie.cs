using System;

namespace Homework2
{
    public class Cookie
    {
        public Cookie()
        {

        }
        public string type { get; set; }
        public double sugarContent { get; set; }
        public DateTime baked { get; set; }

        public Cookie(string Type, double sugar, DateTime date)
        {
            type = Type;
            sugarContent = sugar;
            baked = date;
        }
        public Cookie(string Type)
        {
            type = Type;
        }
    }
}
