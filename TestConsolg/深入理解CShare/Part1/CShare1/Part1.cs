using System;
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
            this.Name=name;
            this.Price=price;
        }

      public static ArrayList GetSmallProducts()
      {
          ArrayList list=new ArrayList();
          list.add(new Products("one",1));
          list.add(new Products("two",2));
         list.add(new Products("there",3));
         return list;
      }        
      public static override string ToString()
      {
          return string.Format("{0},{1}",Name,Price);
      }
    }

}