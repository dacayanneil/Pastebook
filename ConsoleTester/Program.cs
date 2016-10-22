using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastebookBusinessLogicLayer;
using PastebookEFModel;

namespace ConsoleTester
{
    public class Program
    {
        static void Main(string[] args)
        {
            var appBusinessLogic = new AppBusinessLogic();
            var userBusinessLogic = new UserBusinessLogic();

            //var result = appBusinessLogic.retrieveNewsFeedPost(1).ToList();
            //foreach(var item in result)
            //{
            //    Console.WriteLine(item.CONTENT);
            //}
            //Console.Read();
        }
    }
}
