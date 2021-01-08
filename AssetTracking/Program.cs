using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace AssetTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Level 1
            List<CompanyAsset> myAssets= new List<CompanyAsset>();
            LaptopComputer pc1 = new LaptopComputer("MacBook",  11000, new DateTime(2018, 12, 12), "Finland");
            LaptopComputer pc2 = new LaptopComputer("Asus", 10000, new DateTime(2018, 1, 12), "Sweden");
            LaptopComputer pc3 = new LaptopComputer("Lenovo", 8000, new DateTime(2019, 12, 12), "USA");

            List<MobilePhone> myPhones = new List<MobilePhone>();
            MobilePhone phone1 = new MobilePhone("Iphone", 9000, new DateTime(2011, 12, 12), "Finland");
            MobilePhone phone2 = new MobilePhone("Samsung", 7000, new DateTime(2018, 3, 12), "USA");
            MobilePhone phone3 = new MobilePhone("Nokia", 2000, new DateTime(2018, 4, 12), "Sweden");

            myAssets.Add(pc1);
            myAssets.Add(phone1);
            myAssets.Add(pc3);            
            myAssets.Add(phone2);
            myAssets.Add(pc2);
            myAssets.Add(phone3);

            // Level 2

            myAssets = myAssets.OrderBy(myAssets => myAssets.GetType().ToString()).ToList();

            Console.WriteLine("\nLEVEL2 \nOrder by Type");
            Console.WriteLine("ModelName    Price   PurchaseDate");
            foreach (CompanyAsset asset in myAssets)
            {
                Console.WriteLine(asset.ModelName + "  " + asset.Price.ToString() + "  " + asset.PurchaseDate);
            }

            myAssets = myAssets.OrderBy(myAssets => myAssets.PurchaseDate).ToList();

            Console.WriteLine("\nOrder by PurchaseDate");
            Console.WriteLine("ModelName    Price   PurchaseDate");
            DateTime nowDate = DateTime.Now;
            TimeSpan assetLifeSpan;
            // 1005 is 2 years and 9 months  = (365*3)-(30*3) days
            TimeSpan soonEoLSpan = new TimeSpan(1005, 0, 0, 0, 0);
            foreach (CompanyAsset asset in myAssets)
            {
                assetLifeSpan = nowDate - asset.PurchaseDate;
                if (assetLifeSpan > soonEoLSpan)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(asset.ModelName + "  " + asset.Price.ToString() + "  " + asset.PurchaseDate);               

            }

            Console.ReadLine();
        }
    }
    class LaptopComputer: CompanyAsset
    {
        public LaptopComputer(string modelName, int price, DateTime purchaseDate, string office) : base(modelName, price, purchaseDate, office)
        {
            ModelName = modelName;
            Price = price;
            PurchaseDate = purchaseDate;
        }

    }
    class MobilePhone: CompanyAsset
    {
        public MobilePhone(string modelName, int price, DateTime purchaseDate, string office) : base(modelName, price, purchaseDate, office)
        {
            ModelName = modelName;
            Price = price;
            PurchaseDate = purchaseDate;
        }
    }
    class CompanyAsset
    {
        public CompanyAsset(string modelName, int price, DateTime purchaseDate, string office)
        {

            ModelName = modelName;
            Price = price;
            PurchaseDate = purchaseDate;
            Office = office;
        }
        public string ModelName { get; set; }
        public int Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Office { get; set; }

    }
}
