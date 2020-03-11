using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To open the door, press O");
            Console.WriteLine("To close the door, press C");
            
            var key = Console.ReadKey(true);//Skal altid læse hvad for en tast der bliver tastet på
            switch (key.KeyChar)
            {
                case 'O':
                    
                    break;

                case 'C':
                    
                    break;

                
            }
        }
    }
}
