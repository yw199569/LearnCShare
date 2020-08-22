using System;
using System.Collections.Generic;
namespace Part1
{
   public class Products
    {
        public string Name{get;private set;}

        public decimal Price{get;private set;}

        public Products(string name,decimal price)
        {
            Name=name;
            Price=price;
        }

      public static List<Products> GetSmallProducts()
      {
          List<Products> list=new List<Products>
          {
              new Products("one",1),
              new Products("two",2)
          };
         return list;
      }        
      public override string ToString()
      {
          return string.Format("{0},{1}",Name,Price);
      }
    }

}