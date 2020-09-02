using System;
using System.Collections.Generic;
using System.Linq;
using Part1;
namespace Part1.LinqLearn{
    public class LinqLearn {
        //Linq（语言集成查询）是C#3的核心。linq是关于查询的，其目的是使用一致的语法和特征，以一种易于阅读，可组合的方式，使对多数据源的查询变得而简单
        public void TestProgram () {
            List<Products> products = Products.GetSmallProducts ();
            List<Supplier> suppliers = Supplier.GetSmallSupplier ();

            var tempList = from p in products
            join s in suppliers
            on p.SupplierID equals s.SupplierID
            select new {p.Name,s.Price,sName=s.Name};
            foreach (var item in tempList)
            {
                System.Console.WriteLine( item);
            }
        }

        #region LinqToSQL
        
            
        #endregion
    }

}