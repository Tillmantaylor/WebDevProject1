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
    /// Creates vertical bar with * based on url input
    /// </summary>
    public class VerticalBarService : IVerticalBarService
    {
        public Graph VBarGraph(int[] Bars)
        {
            if(Bars.Length > 5)
            {
                Graph temp1 = new Graph()
                {
                    ErrorMessage = "Too Many Numbers"
                };
                return temp1;
            }
            if (Bars.Length < 5)
            {
                Graph temp1 = new Graph()
                {
                    ErrorMessage = "Not Enough Numbers"
                };
                return temp1;
            }
            for(int i = 0; Bars.Length > i; i++)
            {
                if(Bars[i] > 20)
                {
                    Graph temp1 = new Graph()
                    {
                        ErrorMessage = "Number Entered was greater than 20"
                    };
                    return temp1;
                }
                if (Bars[i] < 1)
                {
                    Graph temp1 = new Graph()
                    {
                        ErrorMessage = "Number Entered was less than 1"
                    };
                    return temp1;
                }
            }

            //creates graph
            int maxNum = Bars.Max();
            string[] completedGraph = new string[maxNum];
            for (int i = 0; i < maxNum; i++)
            {
                char[] tempStr = new char[] { ' ', ' ', ' ', ' ', ' ', '\n'};
                for(int j = 0; j < Bars.Length; j++)
                {
                    if (Bars[j] > i)
                    {
                        tempStr[j] = '*';
                    }
                }
                completedGraph[i] = new string(tempStr);
            }
            Array.Reverse(completedGraph);
            Graph temp = new Graph()
            {
                FinishedGraph = completedGraph
            };
            return temp;
        }
    }
}
