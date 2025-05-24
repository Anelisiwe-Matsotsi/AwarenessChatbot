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
        private string lastTopic = "";
        private Dictionary<string, List<string>> keywordResponses; /*Stackoverflow,*/
        private SpeechSynthesizer synthesizer;
        public ChatBot()
        {
            synthesizer = new SpeechSynthesizer();
            keywordResponses = new Dictionary<string, List<string>>
            {
               {"password", new List<string>
                    {
                        "Use strong, unique passwords for each account.",
                        "Avoid using the same password on multiple sites.",
                        "Consider using a password manager to keep track of your passwords."
                    }
               },

               {"scam", new List<string>
                    {
                        "Be cautious of unsolicited emails or messages asking for personal information.",
                        "Always verify the sender's identity  before responding.",
                        "Look out for spelling mistakes and urgent requests in scam messages."
                    }
               },

               {"privacy", new List<string>
                    {
                        "Review your privacy settings regularly on social media.",
                        "Be careful about what personal information you share online.",
                        "Enable two-factor authentication to protect your accounts."
                    }
               },
                {"phishing", new List<string>
                    {
                        "Phishing tricks you into revealing personal information via fake emails or websites.",
                        "Check email addresses carefully, phishing emails often look similar to legitimate ones.",
                        "Never click on suspicious links or download unexpected attachments."
                    }
                }

            };
        }
        public void Start() 
        {
            AskForUserName();
            StartTextChat();
        }

        private void AskForUserName()
        {
            Console.WriteLine("What is your name?", ConsoleColor.Green);
            userName = Console.ReadLine();

           if (string.IsNullOrEmpty(userName))
            {
               Console.WriteLine("Name cannot be empty. Please insert name.\n");
               AskForUserName();
               return;
            }
            Console.WriteLine($"\nWelcome, {userName}! Let's talk cybersecurity.\n");
            synthesizer.Speak($"Welcome, {userName}! Let's talk cybersecurity");
        }


        private void StartTextChat()
        {
            while (true)
          {
             Console.WriteLine("Ask me something (type 'exit' to quit): ", ConsoleColor.DarkYellow);
             string input = Console.ReadLine();

             if (string.IsNullOrEmpty(input))
             {
                 Console.WriteLine("Please enter something meaningful.", ConsoleColor.Red);
                 continue;
             }

            if (input == "exit")
            {
               Console.WriteLine($"Goodbye! {userName}! Stay cyber safe and aware!", ConsoleColor.Magenta);
                    synthesizer.Speak($"Goodbye! {userName}! Stay cyber safe and aware!");
               break;
            }
            RespondToQuestions(input);

          }
        }
        public static void RespondToQuestions(string input, string userName)
        //{
        //    if (input.Contains("How are you?"))
        //    {
        //        Console.WriteLine("I'm great and ready to help you stay safe online!", ConsoleColor.Green);
        //    }
        //    else if (input.Contains("Purpose"))
        //    {
        //        Console.WriteLine("I'm your assistant to teach you about cybersecurity best practices.", ConsoleColor.Green);
        //    }
        //    else if (input.Contains("What can I ask?"))
        //    {
        //        Console.WriteLine("You can ask me about phising, password safety, or how to safely browse the internet.", ConsoleColor.Green);
        //    }
        //    else if (input.Contains("phishing"))
        //    {
        //        /*Proofpoint, 2024*/
        //        Console.WriteLine("Phishing tricks you into revealing personal information via fake emails or websites.", ConsoleColor.Green);
        //    }
        //    else if (input.Contains("password"))
        //    {
        //        /*Jetpack, 2025*/
        //        Console.WriteLine("Use strong, unique passwords. Avoid using the same password on multiple places.", ConsoleColor.Green);

        //    }

        //    else if (input.Contains("safely browse"))
        //    {
        //        /*TechTarget, 2025*/
        //        Console.WriteLine("Avoid clicking unknown links and make sure the website uses HTTPS for security.", ConsoleColor.Green);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ummm, I didn't catch that. Please rephrase?", ConsoleColor.Red);
        //    }
        //}

    }
}
/*Reference List:
Jetpack. 2025.Password Reuse: A Major Vulnerability You Need to Avoid.[online].Available at:<https://jetpack.com/resources/password-reuse/>.[Accessed 18 April 2025].
Proofpoint.2024.What Is Phishing?[online].Available at:<https://www.proofpoint.com/us/threat-reference/phishing>.[Accessed 18 April 2025].
TechTarget.2025c.5 reasons software updates are important.[online].Available at:<https://www.techtarget.com/whatis/feature/5-reasons-software-updates-are-important>.[Accessed 18 April 2025].
Troelsen,A. and Japikse, P. 2021.Pro C# 9 with .NET 5:Foundational Principles and Practices in Programming. 10th ed.Apress.
*/
