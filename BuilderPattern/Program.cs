﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            //var builder = new NewCustomerProductBuilder();
            var builder = new OldCustomerProductBuilder();
            director.GenereteProduct(builder);
            var model = builder.GetModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.UnitPrice);
            Console.ReadLine();

        }
    }
    class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }
    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }
    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();

       
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice *(decimal) 0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
    }
    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
        public override ProductViewModel GetModel()
        {
            return model;
        }
    }
    class ProductDirector
    {
        public void GenereteProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
