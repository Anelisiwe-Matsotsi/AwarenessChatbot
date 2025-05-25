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
            Console.WriteLine("         _______");
            Console.WriteLine("       _/       \\_");
            Console.WriteLine("      / |  O   O | \\");
            Console.WriteLine("     |  |    ^    | |");
            Console.WriteLine("     |  |  \\___/  | |");
            Console.WriteLine("     \\_\\_______/_/");
            Console.WriteLine("       |       |");
            Console.WriteLine("      /|       |\\");
            Console.WriteLine("     /_|_______|_\\");
            Console.WriteLine("      |   |_|   |");
            Console.WriteLine("      |___|_|___|");
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║     CYBERSECURITY AWARENESS BOT              ║");
            Console.WriteLine("╚══════════════════════════════════════════════╝");
        }
    }
}
/*Reference List:
Troelsen,A. and Japikse, P. 2021.Pro C# 9 with .NET 5:Foundational Principles and Practices in Programming. 10th ed.Apress.
*/