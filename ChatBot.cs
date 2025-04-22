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
        //variable that stores the user's name
        private string userName;

        //SpeechSynthesizer allows the chatbot to speak
        private SpeechSynthesizer synth;

        //array of keywords the bot will recognize when asked
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

        //array of responses that matches to each keyword in the questions array
        private string[] responses =
        {
            "I'm great and ready to help you stay safe online!",
            "I'm your assistant to teach you about cybersecurity best practices.",
            "You can ask me about phishing, passwords, malware, firewalls, and more!",
            "Phishing tricks you into revealing personal info via fake emails or websites.", /*Proofpoint, 2024*/
            "Use strong , unique passwords. Avoid reusing them across multiple sites.",/*Jetpack, 2025*/
            "Avoid clicking unknown links. Always check for HTTPS in the URL.",/*NordPass, 2025*/
            "Malware is malicious software that can harm your computer or steal data.",/*TechTarget, 2025a*/
            "Antivirus software helps detect and remove malicious software from your system.",/*Computer Technicians, 2022*/
            "A firewall blocks unauthorised access to your computer network.",/*Fortinet, 2025*/
            "A VPN secures your internet connection and hides your IP address.",/*Kaspersky, 2025*/
            "Two-factor authentication adds a second layer of security to your logins.",/*TechTarget, 2025b*/
            "Keep your software updated to patch security vulnerabilities."/*TechTarget, 2025c*/
        };

        //Sets up the speech synthesizer with a voice
        public ChatBot()
        {
            synth = new SpeechSynthesizer();
            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
        }

        //Starts the interaction with user to ask for user
        public void Start()
        {
            AskForUserName();
            StartTextChat();
        }
        
        //Asks the user to input their name and then greets them
        private void AskForUserName()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("What is your name? ");
            userName = Console.ReadLine();

            if(string.IsNullOrEmpty(userName))
            {
                //Show error in red and repeat if the name is empty
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name cannot be empty. Please enter your name.\n");
                AskForUserName();
            }
            else
            {
                //Greet user with both text and speech
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nWelcome, {userName}! Let's talk about cybersecurity.\n");
                synth.SpeakAsync($"\nWelcome, {userName}! Let's talk about cybersecurity.\n");
            }
        }

        //Handles the text based chat loop
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
                    //Exit the loop if the user types the word "exit"
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Goodbye! Stay cyber safe, and make good choices.");
                    synth.SpeakAsync("Goodbye! Stay cyber safe, and make good choices.");
                    break;
                }
                //Check and respond to the user's questions
                RespondToQuestions(input);
            }
        }

        //Matches user input to a question and gives a response
        public void RespondToQuestions( string input)
        {
            for(int i = 0; i < cyberQuestions.Length; i++)
            {
                if (input.Contains(cyberQuestions[i]))
                {
                    //Responds with matching message
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(responses[i]);
                    synth.SpeakAsync(responses[i]);
                    return;
                }
            }

            //Default response if no match is found
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ummm, I didn't catch that. Please rephrase?");
            synth.SpeakAsync("Ummm, I didn't catch that. Please rephrase?");
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
