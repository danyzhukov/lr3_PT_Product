using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EditForm : Form
    {
        Form1 form;
        private Product pt = new Product();
        private DefaultStore FishingStore;
        private DefaultStore ClothesStore;
        private DefaultStore PhoneStore;
        private string store_name;

        public EditForm(Form1 f1, string store_name, DefaultStore FishingStore, DefaultStore ClothesStore, DefaultStore PhoneStore)
        {
            this.FishingStore = FishingStore;
            this.ClothesStore = ClothesStore;
            this.PhoneStore = PhoneStore;
            form = f1;
            this.store_name = store_name;

            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.Show();
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            pt.Name = txt_name.Text;
        }

        private void txt_Datemaking_TextChanged(object sender, EventArgs e)
        {
            pt.Datemaking = txt_Datemaking.Text;
        }

        private void txt_Price_TextChanged(object sender, EventArgs e)
        {
           pt.Price = int.Parse(txt_Price.Text);
        }

        private void txt_Vendorcode_TextChanged(object sender, EventArgs e)
        {
            pt.Vendorcode = txt_Vendorcode.Text;
        }


        private void save_btn_Click(object sender, EventArgs e)
        {
            if (pt.Name == null || pt.Datemaking == null || pt.Vendorcode == null)
                MessageBox.Show("Fill all the fields please", "Notification", MessageBoxButtons.OK);
                switch (store_name)
                {
                    case "Fishing":
                        FishingStore.ProductList.Add(pt);
                        break;
                    case "Clotes":
                        ClothesStore.ProductList.Add(pt);
                        break;
                    case "Phone":
                        PhoneStore.ProductList.Add(pt);
                        break;
                }

            this.Hide();
            form.Show();
        }
    }
}
