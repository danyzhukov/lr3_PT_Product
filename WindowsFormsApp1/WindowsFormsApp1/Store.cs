using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Store
    {
        protected string store_name ;

        public string Store_name
        {
            get { return store_name; }
            set { store_name = value; }
        }
        

    }
}
