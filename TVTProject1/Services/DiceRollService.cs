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
using TVTProject1.Models;

namespace TVTProject1.Services
{
    /// <summary>
    /// Rolls dice based on URL input
    /// </summary>
    public class DiceRollService : IDiceRollService
    {     
        public RollDice RollDice(int count, int sides)
        {
            var rand = new Random();
            if (count < 1 || count > 20)
            {
                count = 1;
            }
            if (sides < 2 || sides > 20)
            {
                sides = 2;
            }
            int[] rolls = new int[count];
            int total = 0;
            for (int i = 0; count > i; i++)
            {
                rolls[i] = rand.Next(1, sides + 1) ;
                total += rolls[i];
            }
            string evenOrOdd;
            if(total % 2 == 0)
            {
                evenOrOdd = "Even";
            }
            else
            {
                evenOrOdd = "Odd";
            }
            RollDice results = new RollDice()
            {
                Rolls = rolls,
                Total = total,
                EvenOrOdd = evenOrOdd
            };
            return results;
        }

    }
}
