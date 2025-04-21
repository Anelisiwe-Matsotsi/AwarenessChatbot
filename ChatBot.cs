using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessChatbot_Part1
{
    public class ChatBot
    {
        private string userName;
        private SpeechSynthesizer synth;

        private string[] cyberQuestions =
        {
            "how are you",
            "purpose",
            "what can I ask",
            "phishing",
            "password",
            "safely browse",
            "malware",
            "antivirus",
            "firewall",
            "vpn",
            "two factor",
            "update software"
        };
        private string[] responses =
{
            "I'm great and ready to help you stay safe online!",
            "I'm your assistant to teach you about cybersecurity best practices.",
            "wYou ca ask me about phishing, passwords, malware, firewalls, and more!",
            "Phishing tricks you into revealing personal info via fake emails or websites.",
            "Use strong , unique passwords. Avoid reusing them across multiple sites.",
            "Avoid clicking unknown links. Always check for HTTPS in the URL.",
            "Malware is malicious software that can harm your computer or steal data.",
            "Antivirus software helps detect and remove malicious software from your system.",
            "A firewall blocks unathorised access to your computeror network.",
            "A VPN secures your internet connection and hides your IP address.",
            "Two-factor authentication adds a second layer of security to your logins.",
            "Keep your software updated to patch security vulnerabilities."
        };
        public ChatBot()
        {
            synth = new SpeechSynthesizer();
            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
        }
        public void Start()
        {
            AskForUserName();
            ChooseInputMethod();
        }
        
        private void AskForUserName()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("What is your name? ");
            userName = Console.ReadLine();

            if(string.IsNullOrEmpty(userName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name cannot be empty. Please enter your name.\n");
                AskForUserName();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nWelcome, {userName}! Let's talk aboout cybersecurity.\n");
                synth.SpeakAsync($"\nWelcome, {userName}! Let's talk aboout cybersecurity.\n");
            }
        }

        private void ChooseInputMethod()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Choose input method");
            Console.WriteLine("1. Type");
            Console.WriteLine("2. Speak");

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
        public void StartTextChat()
        {
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Ask me something about cybersecurity (type 'exit' to quit): ");
                string input = Console.ReadLine();

                if(string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid question");
                    continue;
                }
                if(input == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Goodbye! Stay cyber safe, and make good choices.");
                    synth.SpeakAsync("Goodbye! Stay cyber safe, and make good choices.");
                    break;
                }
                RespondToQuestions(input);
            }
        }
        public void RespondToQuestions( string input)
        {
            for(int i = 0; i < cyberQuestions.Length; i++)
            {
                if (input.Contains(cyberQuestions[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(responses[i]);
                    synth.SpeakAsync(responses[i]);


                    return;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ummm, I didn't catch that. Please rephrase?");
            synth.SpeakAsync("Ummm, I didn't catch that. Please rephrase?");
        }
    }
}
 