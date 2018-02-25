using Crucian.FileStorage.CORE;
using Crucian.FileStorage.CORE.Models;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;

namespace Crucian.FileStorage.CORE
{
    class Program
    {
        static void Main(string[] args)
        {

            var UserManager = new UserManager();

            var Id = UserManager.CheckUserByLogin("admin");

            Console.WriteLine(" --> Execution \"Crucian.FileStorage.DB\". This project is not the starting one..");
            Console.WriteLine("     To continue, press any key");
            Console.ReadKey();
        }
    }
}
