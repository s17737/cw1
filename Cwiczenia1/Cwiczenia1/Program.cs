using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cwiczenia1
{
    class Program
    {
        static async Task Main(string[] args) //dodalismy async, bo to dla wątku
        {
            string url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var client = new HttpClient(); //do wykonywania zadan http. 
            var result = await client.GetAsync(url); //odpalane na nowym wątku, zeby nie blokowac

            if(result.IsSuccessStatusCode) //dowolna wartosc z kodem 200+
            {
                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+",
                    RegexOptions.IgnoreCase);
                var matches = regex.Matches(html);

                foreach(var m in matches)
                {
                    Console.WriteLine(m.ToString());
                }
            }
        }
    }
}
