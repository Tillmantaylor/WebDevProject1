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
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TVTProject1.Services;

namespace TVTProject1.Controllers
{
    /// <summary>
    /// Controls Dice Roller
    /// </summary>
    public class RollDiceController : Controller
    {
        private readonly IDiceRollService _rollDice;
        public RollDiceController(IDiceRollService input)
        {
            _rollDice = input;
        }
        public IActionResult Index(int count, int sides)
        {    
            return Json(this._rollDice.RollDice(count, sides));
        }       
    }
}
