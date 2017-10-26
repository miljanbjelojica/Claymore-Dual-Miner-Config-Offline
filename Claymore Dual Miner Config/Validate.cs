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
    }
}
