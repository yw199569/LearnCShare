using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Part1
{
    public class Products
    {
        readonly string _name;
        public string Name { get { return _name; } }
        readonly decimal _price;
        public decimal Price { get { return _price; } }

        public Products()
        {
        }
        public Products(string name, decimal price)
        {
            _name = name;
            _price = price;
        }

        public static List<Products> GetSmallProducts()
        {
            List<Products> list = new List<Products>
                    {
                        new Products(name:"one",price:1),
                        new Products(name:"two",price:2),
                        new Products(name:"three",price:3)
                    };
            return list;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", Name, Price);
        }
        public void TestExtensions()
        {
            System.Console.WriteLine("这是扩展方法的原始方法");
        }
    }

    public class Comprare : IComparer<Products>
    {
        public int Compare(Products x, Products y)
        {
            Products frist = x;
            Products second = y;
            return frist.Name.CompareTo(second.Name);//比的是ASCII码的排序
        }
    }
}