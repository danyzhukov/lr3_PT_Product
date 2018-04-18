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
    public partial class Form1 : Form
    {
        private DefaultStore FishingStore = new DefaultStore();
        private DefaultStore ClothesStore = new DefaultStore();
        private DefaultStore PhoneStore = new DefaultStore();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Fishing");
            comboBox1.Items.Add("Clothes");
            comboBox1.Items.Add("Phone");
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                string store_name = comboBox1.GetItemText(comboBox1.SelectedItem);
                EditForm ed = new EditForm(this, store_name, FishingStore, ClothesStore, PhoneStore);
                this.Hide();
                ed.ShowDialog();
            }

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                if (comboBox1.SelectedIndex != -1)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            FishingStore.RemoveProduct(listBox1.SelectedIndex);
                            break;
                        case 1:
                            ClothesStore.RemoveProduct(listBox1.SelectedIndex);
                            break;
                        case 2:
                            PhoneStore.RemoveProduct(listBox1.SelectedIndex);
                            break;
                    }
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;

            List<string> allProductList = new List<string>();
            allProductList.Add("Fishing:" + System.Environment.NewLine);
            allProductList.AddRange(FishingStore.GetStudInfo()); 
            allProductList.Add(System.Environment.NewLine+"Clothes:" + System.Environment.NewLine);
            allProductList.AddRange(ClothesStore.GetStudInfo());
            allProductList.Add(System.Environment.NewLine+"Phone:" + System.Environment.NewLine);
            allProductList.AddRange(PhoneStore.PickStudInfo());

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName != "")
                {

                    foreach (string s in allProductList)
                    {
                        System.IO.File.AppendAllText(sfd.FileName, s + System.Environment.NewLine);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm closing!", "Store",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                  System.Windows.Forms.DialogResult.Yes)
                Application.Exit();
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добро пожаловать в SID приложение для гипермаркета!\n"+
                "Первое окно с 3 активными кнопками и список текущих категорий товаров увидите на главном экране\n "+
                "Чтобы добавить новый товар выберите  любую категорию, выберите имя категории и нажмите «Изменить ».\n"+
                "В форме введите необходимые данные\n"+
                "Если вы сделаете ошибку, приложение предоставит вам еще один шанс\n"+
                "После добавления нового товора Вы вернетесь к главному экрану\n"+
                "Если вы хотите увидеть список студентов, выберите экзамен и нажмите Показать\n"+
                "Если вы хотите удалить кого-нибудь, выберите ученика и нажмите Удалить\n "+
                "Если вы хотите сохранить файл со всем списком студентов, нажмите Сохранить в строке меню в поле Файл\n", "Documentation", MessageBoxButtons.OK);
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if(comboBox1.SelectedIndex != -1)
            {
                switch (comboBox1.GetItemText(comboBox1.SelectedItem))
            {
                case "Fishing":
                    foreach (string s in FishingStore.GetStudInfo())
                        listBox1.Items.Add(s);
                    break;
                case "Clothes":
                    foreach (string s in ClothesStore.PickStudInfo())
                        listBox1.Items.Add(s);
                    break;
                case "Phone":
                    foreach (string s in PhoneStore.GetStudInfo())
                        listBox1.Items.Add(s);
                    break;
            }
            }
        }
    }
}
