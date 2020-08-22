using System;
using System.Collections;
namespace Part1
{
   public class Products
    {
        string _name;
        public string Name{get{return _name; }}
        decimal _price;

        public decimal Price{get{return _price;}}

        public Products(string name,decimal price)
        {
            this._name=name;
            this._price=price;
        }

      public static ArrayList GetSmallProducts()
      {
          ArrayList list=new ArrayList();
          list.Add(new Products("one",1));
          list.Add(new Products("two",2));
          list.Add(new Products("there",3));
         return list;
      }        
      public override string ToString()
      {
          return string.Format("{0},{1}",Name,Price);
      }
    }

}