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

        public bool charCount { get; set; }

        private bool checkBoxes()
        {
            charCount = false;
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

            Validator validate = new Validator();
            bool check = false, check2 = false;
            if (checkBoxes())
            {
                check = validate.ValidateName(txt_itemName.Text);
                check = validate.ValidateNumber(txt_entryNumber.Text, 1000000);
                check = validate.ValidateNumber(txt_inventoryNumber.Text, 10000);
                check = validate.ValidateNumber(txt_itemCount.Text, 100);
                check2 = validate.ValidatePrice(txt_itemPrice.Text, 1000000.00);

                decimal checkPrice = decimal.Parse(txt_itemPrice.Text, System.Globalization.NumberStyles.AllowDecimalPoint);
                decimal netPrice = Math.Round(checkPrice, 2);
    
                if (check)
                {
                    MessageBox.Show("This is a valid entry " + netPrice);
                    if (!check2)
                    {
                        MessageBox.Show("Invalid Entry at Check2 1d" + checkPrice);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Entry " + txt_entryNumber.Text);
                    if (!check2)
                    {
                        MessageBox.Show("Invalid Entry at Check2 2d" + checkPrice);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill the empty fields");
            }
        }
    }


}
