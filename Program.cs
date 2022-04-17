using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("No storage file was provided");
                return;
            }
            string storageFile = args[0];

            CookieJar cj;
            if (File.Exists(storageFile))
            {
                string cjAsJsonText = File.ReadAllText(storageFile);
                cj = JsonSerializer.Deserialize<CookieJar>(cjAsJsonText);
            }
            else
            {
                cj = new CookieJar(20, 20);
            }
            int x = 0;
            string user;
            while (x == 0)
            {
                user = AskQuestion("Would you like to  DepositCookies, RequestCookie, CheckCookieCount, AverageSugar, CountByType, RemoveExpired or Exit");
                if(user == "DepositCookies")
                {
                    List<Cookie> Cookies = new List<Cookie>();
                    string type = AskQuestion("What type of cookie is the batch?");
                    int amount = AskNumericalQuestion("How many cookies are in the batch?");
                    double sugar = AskNumericalQuestion("How much sugar is in the batch?");
                    sugar = sugar / amount;
                    string Date = AskQuestion("When were the cookies made?");
                    DateTime newDate;
                    if (DateTime.TryParse(Date, out newDate))
                    {
                        for (int y = 0; y < amount; y++)
                        {
                                Cookie newCookie = new Cookie(type, sugar, newDate);
                                Cookies.Add(newCookie);
                        }
                    } else
                    {
                        Console.WriteLine("INVALID DATE");
                    }

                    cj.depositCookies(Cookies);

                } else if (user == "RequestCookie")
                {
                    string r = AskQuestion("What is your name?");
                    Cookie request = cj.RequestCookie(r);
                    if (request == null)
                    {
                        Console.WriteLine("All cookies in the jar contain more sugar than you're allowed.");
                    }
                    else
                    {
                        Console.WriteLine("Enjoy this " + request.type + " Cookie that has " + request.sugarContent + " grams of sugar in it.");
                    }
                } else if (user == "CheckCookieCount")
                {
                    Console.WriteLine("The CookieJar currently has " + cj.amountCookies + " in it");

                } else if(user == "AverageSugar")
                {
                    Console.WriteLine("The average sugar content of the cookies in the jar: " + cj.AverageSugar());
                }else if(user == "CountByType")
                {
                    string cookietype = AskQuestion("What type of cookie would you like to count?");
                    Console.WriteLine("There are " + cj.CookieTypeCount(cookietype) + " cookie of that type in the jar.");
                }else if(user == "RemoveExpired")
                {
                    cj.removeExpired();
                }else if (user == "Exit")
                {
                    Console.WriteLine("GoodBye");
                    string cjAsJsonText = JsonSerializer.Serialize(cj);
                    File.WriteAllText(storageFile, cjAsJsonText);
                    x = 1;
                }else
                {
                    Console.WriteLine("Invalid Response");
                }

            }



        }

        static string AskQuestion(string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();
            return answer;
        }
        static int AskNumericalQuestion(string question)
        {
            Console.WriteLine(question);
            string answerAsString = Console.ReadLine();
            int answer = int.Parse(answerAsString);
            return answer;
        }


    }
}
