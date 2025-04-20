using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessChatbot_Part1
{
    public class ChatBot
    {
        private string userName;
        public void Start()
        {
            AskForUserName();
            ChooseInputMethod();
        }
        private void AskForUserName()
        {
            Console.WriteLine("What is your name?", ConsoleColor.Green);
            userName = Console.ReadLine();

            if(userName == null || userName == "")
            {
                Console.WriteLine("Name cannot be empty. Please insert name.\n");
                AskForUserName();
            }
            Console.WriteLine($"\nWelcome, {userName}! Let's talk cybersecurity.\n");
        }
        private void ChooseInputMethod()
        {
            Console.WriteLine("Choose input method:");
            Console.WriteLine("1. Type");
            Console.WriteLine("2. Voice");

            string choice = Console.ReadLine();

            if(choice == "2")
            {
                VoiceAssist.StartRecognition(userName);
            }
            else
            {
                StartTextChat();
            }
        }
        private void StartTextChat()
        {
            while(true)
            {
                Console.WriteLine("Ask me something (type 'exit' to quit): ", ConsoleColor.DarkYellow);
                string input = Console.ReadLine();
                
                if(string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a valid question.", ConsoleColor.Red);
                    continue;
                }

                if(input == "exit")
                {
                    Console.WriteLine("Goodbye! Stay cyber safe, and make good choices.", ConsoleColor.Magenta);
                    break;
                }
                RespondToQuestions(input, userName);
            }
        }
        public static void RespondToQuestions(string input, string userName)
        {
            if(input.Contains("How are you?"))
            {
                Console.WriteLine("I'm great and ready to help you stay safe online!", ConsoleColor.Green);
            }
            else if(input.Contains("Purpose"))
            {
                Console.WriteLine("I'm your assistant to teach you about cybersecurity best practices.", ConsoleColor.Green);
            }
            else if(input.Contains("What can I ask?"))
            {
                Console.WriteLine("You can ask me about phising, password safety, or how to safely browse the internet.", ConsoleColor.Green);
            }
            else if(input.Contains("Phising"))
            {
                Console.WriteLine("Phising tricks you into revealing personal information via fake emails or websites.", ConsoleColor.Green);
            }
            else if(input.Contains("Password"))
            {
                Console.WriteLine("Use strong, unique passwords. Avoid using the same password on multiple places.", ConsoleColor.Green);
            }
            else if(input.Contains("Safely browse the internet"))
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
