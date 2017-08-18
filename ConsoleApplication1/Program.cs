using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.GetUsersJson;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetUsersJson.TestWebService test = new TestWebService();

            var str = test.GetUsersXml();

            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
