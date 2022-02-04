////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Project:        Project1
//  File Name:      Project1.cs
//  Description:    MVC Dice roll, Encryption, Decryption, and 
//  Course:         CSCI-3110-001
//  Author:         Taylor Tillman, tillmant@etsu.edu
//  Created:        Tuesday, September 21, 2021
//  Copyright:      Taylor Tillman, 2021
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TVTProject1.Services
{
    /// <summary>
    /// Does decryption
    /// </summary>
    public class DecryptService : IDecryptService
    {
        public string Decryption(int numToDecrypt)
        {
            if (numToDecrypt > 9999 || numToDecrypt < 1000)
            {
                return "0";
            }
            
            //decryption
            int len = 4;
            int[] digits = new int[len];
            int parseNo = numToDecrypt;
            int dec = (int)Math.Pow(10, len - 1);
            for (int i = len - 1; i >= 0; --i)
            {
                digits[len - i - 1] = parseNo / dec;
                parseNo -= digits[len - i - 1] * dec;
                dec /= 10;
            }
            for (int i = 0; digits.Length > i; i++)
            {
                if(digits[i] - 7 < 0)
                {
                    digits[i] += 10;
                }
                digits[i] -= 7;
                digits[i] %= 10;
            }

            //swap numbers
            int swap = digits[0];
            digits[0] = digits[2];
            digits[2] = swap;
            int swap2 = digits[1];
            digits[1] = digits[3];
            digits[3] = swap2;

            int holder = 1000;
            int count = 0;
            int total = 0;
            while (true)
            {
                total = total + digits[count] * holder;
                if (holder == 1)
                {
                    break;
                }
                else
                {
                    holder = holder / 10;
                    count = count + 1;
                }
            }
            return total.ToString();
        }
    }
}
