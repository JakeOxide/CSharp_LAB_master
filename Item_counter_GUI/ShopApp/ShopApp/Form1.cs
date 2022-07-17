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
            date_dateOfEntry.MinDate = DateTime.Now;
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
            bool check1 = false, check2 = false, check3 = false, check4 = false, check5 = false;
            if (checkBoxes())
            {
                    check1 = validate.ValidateName(txt_itemName.Text); //Char.ToUpper(nameChar[1]) if dataClass and Char Array is used
                    check2 = validate.ValidateNumber(txt_entryNumber.Text, 1000000);
                    check3 = validate.ValidateNumber(txt_inventoryNumber.Text, 10000);
                    check4 = validate.ValidateNumber(txt_itemCount.Text, 500);
                double retVal;
                bool isNum = Double.TryParse(txt_itemPrice.Text, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retVal);
                if(isNum)
                {
                    check5 = validate.ValidatePrice(txt_itemPrice.Text);
                }
                else
                {
                    check5 = false;
                }


    
                if (check1 && check2 && check3 && check4 && check5)
                {                
                    decimal checkPrice = decimal.Parse(txt_itemPrice.Text, System.Globalization.NumberStyles.AllowDecimalPoint);
                    decimal netPrice = Math.Round(checkPrice, 2);
                    string[] messages = new string[] {"This is a valid entry \n \n",
                    "Item Name      \t \n" + txt_itemName.Text + "\n \n",
                    "Entry Number   \t \n" + txt_entryNumber.Text + "\n \n",
                    "Inventory No   \t \n" + txt_inventoryNumber.Text + "\n \n",
                    "Item Count     \t \n" + txt_itemCount.Text + "\n \n",
                    "Price          \t \n" + netPrice + "\n \n",
                    "Date of Entry  \t \n" + date_dateOfEntry.Value};
                    var message = string.Join(Environment.NewLine, messages);
                    MessageBox.Show(message);
                    btn_clear.PerformClick();
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_entryNumber.Text = "";
            txt_inventoryNumber.Text = "";
            txt_itemCount.Text = "";
            txt_itemName.Text = "";
            txt_itemPrice.Text = "";
            date_dateOfEntry.Value = date_dateOfEntry.MinDate;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
