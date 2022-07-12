using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp
{
    public partial class ShopApp : Form
    {
        public ShopApp()
        {
            InitializeComponent();
        }

        private bool checkBoxes()
        {
            bool charCount = false;

            if (txt_entryNumber.Text.Length > 0)
                charCount = true;
            else
                return false;

            if (txt_inventoryNumber.Text.Length > 0)
                charCount = true;
            else
                return false;

            if (txt_itemCount.Text.Length > 0)
                charCount = true;
            else
                return false;

            if (txt_itemName.Text.Length > 0)
                charCount = true;
            else
                return false;

            if (txt_itemPrice.Text.Length > 0)
                charCount = true;
            else
                return false;

            return charCount;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (checkBoxes())
            {
                DataClass data = new DataClass();
                data.itemName = txt_itemName.Text;
                data.itemNumber = txt_entryNumber.Text;
                bool check = data.validateData();
                if (check)
                {
                    MessageBox.Show("This is a valid entry " + txt_entryNumber.Text);
                }
                else
                {
                    MessageBox.Show("Invalid Entry " + txt_entryNumber.Text);
                }
            }
            else
            {
                MessageBox.Show("Please fill the empty fields");
            }
        }
    }

    class DataClass
    {
        public string itemName { get; set; }
        public string itemNumber { get; set; }
        public string  inventoryNumber { get; set; }
        public string itemCount { get; set; }
        public double itemPrice { get; set; }

        public bool validateData()
        {
            bool result = false;

            // Name
            char[] nameChar = itemName.Trim().ToCharArray();
            if (nameChar.Length > 2)
            {
                foreach (char x in nameChar)
                {
                    if (x >= 'a' & x <= 'z' || x >= 'A' & x <= 'Z')
                    {
                        result = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            //Number
            int[] itemNum = itemNumber.ToString().ToCharArray().Select(Convert.ToInt32).ToArray();
            bool checker = false;
                foreach (int x in itemNum)
                    {
                        if (x >= 0 | x <= 9)
                        {
                            result = true;
                            checker = true;
                        }
                        else
                        {
                            checker = false;
                            return false;
                        }
                    }
            if (checker)
            {
                int entryNum = Convert.ToInt32(itemNumber);
                if (entryNum >= 1 && entryNum <= 1000)
                {
                    result = true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return result;
        }

    }

}
