using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessChatbot_Part1
{
    /*Troelsen and Japikse, 2021*/
    public class ChatBot
    {
        private string userName;
        public void Start()
        {
            AskForUserName();
            StartTextChat();
        }
        private void AskForUserName()
        {
            Console.WriteLine("What is your name?", ConsoleColor.Green);
            userName = Console.ReadLine();

            if (userName == null || userName == "")
            {
                Console.WriteLine("Name cannot be empty. Please insert name.\n");
                AskForUserName();
            }
            Console.WriteLine($"\nWelcome, {userName}! Let's talk cybersecurity.\n");
        }


        private void StartTextChat()
        {
            while (true)
            {
                Console.WriteLine("Ask me something (type 'exit' to quit): ", ConsoleColor.DarkYellow);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a valid question.", ConsoleColor.Red);
                    continue;
                }

                if (input == "exit")
                {
                    Console.WriteLine("Goodbye! Stay cyber safe, and make good choices.", ConsoleColor.Magenta);
                    break;
                }
                RespondToQuestions(input, userName);
            }
        }
        public static void RespondToQuestions(string input, string userName)
        {
            if (input.Contains("How are you?"))
            {
                Console.WriteLine("I'm great and ready to help you stay safe online!", ConsoleColor.Green);
            }
            else if (input.Contains("Purpose"))
            {
                Console.WriteLine("I'm your assistant to teach you about cybersecurity best practices.", ConsoleColor.Green);
            }
            else if (input.Contains("What can I ask?"))
            {
                Console.WriteLine("You can ask me about phising, password safety, or how to safely browse the internet.", ConsoleColor.Green);
            }
            else if (input.Contains("phising"))
            {
                Console.WriteLine("Phising tricks you into revealing personal information via fake emails or websites.", ConsoleColor.Green);
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("Use strong, unique passwords. Avoid using the same password on multiple places.", ConsoleColor.Green);

            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("A password shouldn’t be the word “password” or the same letter or number repeated", ConsoleColor.Green);

            }

            else if (input.Contains("safely browse "))
            {
                Console.WriteLine("Avoid clicking unknown links and make sure the website uses HTTPS for security.", ConsoleColor.Green);
            }
            else
            {
                Console.WriteLine("Ummm, I didn't catch that. Please rephrase?", ConsoleColor.Red);
            }
        }

    }
}
/*Reference List:
Computer Technicians.2022.Advantages and Disadvantages of Antivirus Software.[online].Available at:<https://computertechnicians.au/advantages-and-disadvantages-of-antivirus-software/>.[Accessed 18 April 2025].
Fortinet.2025.What Does A Firewall Do?[online].Available at:<https://www.fortinet.com/resources/cyberglossary/what-does-a-firewall-do#:~:text=Firewall%20FAQs&text=Basically%2C%20a%20firewall%20is%20a,to%20a%20more%20secure%20environment.>.[Accessed 18 April 2025].
Jetpack. 2025.Password Reuse: A Major Vulnerability You Need to Avoid.[online].Available at:<https://jetpack.com/resources/password-reuse/>.[Accessed 18 April 2025].
Kaspersky. 2025.What is VPN? How It Works, Types of VPN.[online].Available at:<https://www.kaspersky.com/resource-center/definitions/what-is-a-vpn>.[Accessed 18 April 2025].
NordPass. 2025.How to check if a link is safe?[online].Available at:<https://nordpass.com/blog/how-to-check-if-a-link-is-safe/>.[Accessed 18 April 2025].
Proofpoint.2024.What Is Phishing?[online].Available at:<https://www.proofpoint.com/us/threat-reference/phishing>.[Accessed 18 April 2025].
TechTarget.2025a.What is malware? Prevention, detection and how attacks work.[online].Available at:<https://www.techtarget.com/searchsecurity/definition/malware>.[Accessed 18 April 2025].
TechTarget.2025b.What is two-factor authentication (2FA)?[online].Available at:<https://www.techtarget.com/searchsecurity/definition/two-factor-authentication>.[Accessed 18 April 2025].
TechTarget.2025c.5 reasons software updates are important.[online].Available at:<https://www.techtarget.com/whatis/feature/5-reasons-software-updates-are-important>.[Accessed 18 April 2025].
Troelsen,A. and Japikse, P. 2021.Pro C# 9 with .NET 5:Foundational Principles and Practices in Programming. 10th ed.Apress.
*/
