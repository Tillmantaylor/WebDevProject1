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
    /// Controls Vertical bar graph
    /// </summary>
    public class VBarGraphController : Controller
    {
        private readonly IVerticalBarService _verticalBarService;
        public VBarGraphController(IVerticalBarService input)
        {
            _verticalBarService = input;
        }
        public IActionResult Index(string Bars)
        {
            int[] tempBars = Bars.Split('/').Select(Int32.Parse).ToArray();
            var model = this._verticalBarService.VBarGraph(tempBars);
            if(model.ErrorMessage != null)
            {
                return Content(model.ErrorMessage);
            }
            else
            {
                return Content(string.Concat(model.FinishedGraph));
            }
        }
    }
}
