using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using cw1_2.EF;
using cw1_2.EF.Models;

namespace cw1_2
{
    class Program
    {
        static object ReadProps(Type modelType, IEnumerable<PropertyInfo> props)
        {
            var z = Activator.CreateInstance(modelType);
            foreach (var prop in props)
            {
                Console.Write("Insert {0} : ", prop.Name);
                string s = Console.ReadLine();
                prop.SetValue(z, Convert.ChangeType(s, prop.PropertyType));
            }
            return z;
        }

        static void Main(string[] args)
        {
            ConsoleCrudParser p = new ConsoleCrudParser(new MyDbContext());

            while (true)
            {
                Console.Write(">");
                string s = Console.ReadLine();
                if (s == "q")
                    break;
                var z = p.Parse(s);
                var t = p.GetProps(z.Item1, z.Item2);
                var o = ReadProps(z.Item1,t);
                //p.DbSave(o, z.Item2);
            }
        }
    }
}
