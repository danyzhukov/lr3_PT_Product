using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Product
    {
        protected string name;
        protected string datamaking;
        protected int price;
        protected string vendorcode;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Datemaking
        {
            get { return datamaking; }
            set { datamaking = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Vendorcode
        {
            get { return vendorcode; }
            set { vendorcode = value; }
        }
    }
}
