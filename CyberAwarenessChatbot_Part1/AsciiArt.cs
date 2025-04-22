using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessChatbot_Part1
{
    /*Troelsen and Japikse, 2021*/
    public static class AsciiArt
    {
        //Displays a banner for the chatbot
        public static void Display()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║    :) CYBERSECURITY AWARENESS BOT :)         ║");
            Console.WriteLine("╚══════════════════════════════════════════════╝");
        }
    }
}
/*Reference List:
Troelsen,A. and Japikse, P. 2021.Pro C# 9 with .NET 5:Foundational Principles and Practices in Programming. 10th ed.Apress.
*/