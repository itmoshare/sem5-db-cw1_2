using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using cw1_2.EF;
using cw1_2.EF.Models;

namespace cw1_2
{
    public class ConsoleCrudParser
    {
        private DbContext _dbcontext;
        private Dictionary<string, Tuple<Type, PropertyInfo>> _dbtypes;

        private HashSet<string> _allowedCrud = new HashSet<string>()
        { "Add", "Remove", "tr" };

        public ConsoleCrudParser(DbContext dbcontext)
        {
            _dbcontext = dbcontext;
            // Get registered EF models
            var z = _dbcontext.GetType().GetProperties()
                .Where(x => x.PropertyType.IsGenericType)
                .Where(x => x.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));
            _dbtypes = z.ToDictionary(x => x.PropertyType.GenericTypeArguments[0].Name, x => new Tuple<Type, PropertyInfo>(x.PropertyType.GenericTypeArguments[0], x));
        }

        public Type GetClass(string className)
        {
            Type fixedClassType;
            if (!_dbtypes.ContainsKey(className))
                throw new ArgumentException("Inavlid class name");
            else
                fixedClassType = _dbtypes[className].Item1;

            return fixedClassType;
        }

        public MethodInfo GetMethod(Type efType, string methodName)
        {
            if (!_allowedCrud.Contains(methodName))
                throw new ArgumentException("Inavlid method name");

            MethodInfo entryMethodInfo = _dbcontext.GetType()
                .GetMethods()
                .Single(x => !x.IsGenericMethod && x.Name == "Entry");
            return null;
        }

        public IEnumerable<PropertyInfo> GetProps(Type modelClassType, string method)
        {
            switch (method)
            {
                case "Add":
                    return modelClassType.GetProperties()
                        .Where(x => !x.GetMethod.IsVirtual)
                        .Where(x => !x.PropertyType.IsGenericType || x.PropertyType.GetGenericTypeDefinition() != typeof(List<>));
                case "Remove":
                    break;
            }
            return null;
        }

        public void DbSave(object obj, string method)
        {
            switch (method)
            {
                case "Add":
                    _dbtypes[obj.GetType().Name].Item2.GetValue(_dbcontext)
                        .GetType()
                        .GetMethod("Add")
                        .Invoke(_dbcontext, new[] {obj});
                    _dbcontext.SaveChanges();
                    break;
                case "Remove":
                    break;
            }
        }

        public Tuple<Type, string> Parse(string str)
        {
            Regex reg = new Regex(@"^(\w+) (\w+)$");
            if (!reg.IsMatch(str))
                throw new ArgumentException("Invalid input format");
            Match res = reg.Match(str);

            return new Tuple<Type, string>(GetClass(res.Groups[1].Value), res.Groups[2].Value);
        }
    }
}
