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
    public interface IDiceRollService
    {
        public RollDice RollDice(int count, int sides);
    }
}
