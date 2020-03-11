﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LadeskabLogik;

namespace LadeskabAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            console.writeline("To open the door, press O");
            console.writeline("To close the door, press C");
            
            var key = Console.ReadKey(true);//Skal altid læse hvad for en tast der bliver tastet på
            switch (key.KeyChar)
            {
                case 'O':
                    door.SetDoorStatus(doorOpen = true);
                    break;

                case 'C':
                    door.SetDoorStatus(doorOpen = false);
                    break;

                
            }
        }
    }
}
