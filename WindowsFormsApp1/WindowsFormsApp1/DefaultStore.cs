using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class DefaultStore : Store,IListInfoGetter,IListInfoGet
    {
        public DefaultStore()
        {
            ProductList = new List<Product>();
        }

        public List<Product> ProductList
        {
            get;
            set;
        }

        List<string> info;
       
        List<string> IListInfoGetter.GetInfoFromList()
        {

            info = new List<string>();
            ProductList.ForEach(pt => info.Add("Name:" + pt.Name + "  Datemaking: " + pt.Datemaking + " Price: " + pt.Price + " Vendor Code: " + pt.Vendorcode));
            return info;
        }

        public List<string> GetStudInfo()
        {
            return ((IListInfoGetter)this).GetInfoFromList();
        }

        List<string> IListInfoGet.GetInfoFromList()
        {

            info = new List<string>();
            ProductList.ForEach(pt => info.Add("Fio: " + pt.Name + "  Datemaking: " + pt.Datemaking + " Price: " + pt.Price + " Vendor Code: " + pt.Vendorcode));
            return info;
        }

        public List<string> PickStudInfo()
        {
            return ((IListInfoGet)this).GetInfoFromList();
        }

        public void RemoveProduct(int index)
        {
            ProductList.Remove(ProductList[index]);
        }

        
    }
}
