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
    /// Controls Encryption with URL input
    /// </summary>
    public class EncryptService : IEncryptService
    {
        public string Encryption(int numToEncrypt)
        {
            if(numToEncrypt > 9999 || numToEncrypt < 1000)
            {
                return "0";
            }

            //encrypting getting digits
            int len = 4;
            int[] digits = new int[len];
            int parseNo = numToEncrypt;
            int dec = (int)Math.Pow(10, len - 1);
            for (int i = len - 1; i >= 0; --i)
            {
                digits[len - i - 1] = parseNo / dec;
                parseNo -= digits[len - i - 1] * dec;
                dec /= 10;
            }
            for(int i = 0; digits.Length > i; i++)
            {
                digits[i] += 7;
                digits[i] %= 10;
            }

            //swap 1st and 3rd 
            int swap = digits[0];
            digits[0] = digits[2];
            digits[2] = swap;
            //swap 2nd and 4th
            int swap2 = digits[1];
            digits[1] = digits[3];
            digits[3] = swap2;

            int holder = 1000;
            int count = 0;
            int total = 0;
            while (true)
            {
                total = total + digits[count] * holder;
                if(holder == 1)
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
