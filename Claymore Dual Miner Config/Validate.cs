using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Claymore_Dual_Miner_Config
{
    class Validate
    {
        // VALIDATES ETH OR ETC ADDRESS
        public bool CheckETHAddress(string mainAddress)
        {
            bool valid = false;

            if (mainAddress.Length == 42 & mainAddress.Contains("0x"))
            {
                valid = true;
            }
            else
            {                
                MessageBox.Show("ETH/ETC Address is not valid", "Address Error");
            }
            return valid;
        }

        // VALIDATES SIA ADDRESS
        public bool CheckSIAAddress(string altAddress)
        {
            bool valid = false;

            if(altAddress.Length == 76)
            {
                valid = true;
            }
            else
            {
                MessageBox.Show("SIA address is no valid", "Address Error");
            }
            return valid;
        }

        //VALIDATES PASC ADDRESS
        public bool CheckPASCAddress(string altAddress)
        {
            bool valid = false;

            if (altAddress.Length == 25 & altAddress.Contains("Poloniex"))
            {
                valid = true;
            }
            else
            {
                MessageBox.Show("PASC address is no valid", "Address Error");
            }
            return valid;
        }
    }
}
