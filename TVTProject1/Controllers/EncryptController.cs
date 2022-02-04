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
    /// Controls Encryption
    /// </summary>
    public class EncryptController : Controller
    {
        private readonly IEncryptService _encryptService;
        public EncryptController(IEncryptService input)
        {
            _encryptService = input;
        }
        public IActionResult Index(int numToEncrypt)
        {
            var data = this._encryptService.Encryption(numToEncrypt);
            return Content(data != "0" ? data : "Cannot Encrypt");
        }
    }
}
