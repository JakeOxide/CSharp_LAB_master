using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    class Validator
    {
        public bool ValidateName(string name)
        {
            bool result = false;
            if(name == null)
            {
                return false;
            }
            else
            {
                // Name
                char[] nameChar = name.Trim().ToCharArray();
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
                else
                {
                    return false;
                }
            }
            return result;
        }

        public bool ValidateNumber(string number, int limit)
        {
            bool result = false;

            if (CheckString(number))
            {
                int entryNum = Convert.ToInt32(number);
                if (entryNum >= 1 && entryNum <= limit)
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

        private bool CheckString(string number)
        {
            return number.All(char.IsDigit); 
        }

        public bool ValidatePrice(string price)
        {
            bool result = false;
            // Price
            decimal checkPrice;
                if (!(decimal.TryParse(price, out checkPrice))
                && checkPrice >= 0
                && checkPrice * 100 == Math.Floor(checkPrice * 100))
                {
                    return false;
                }
                else
                {
                    result = true;
                }
        return result;
        }

    }
}
