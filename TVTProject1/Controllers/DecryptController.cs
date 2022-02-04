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
using TVTProject1.Services;

namespace TVTProject1.Controllers
{
    /// <summary>
    /// Controls Decryption
    /// </summary>
    public class DecryptController : Controller
    {
        private readonly IDecryptService _decryptService;
        public DecryptController(IDecryptService input)
        {
            _decryptService = input;
        }
        public IActionResult Index(int numToDecrypt)
        {
            var data = this._decryptService.Decryption(numToDecrypt);
            return Content(data != "0" ? data : "Cannot Decrypt");
        }
    }
}
