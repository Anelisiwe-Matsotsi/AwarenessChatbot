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
        private string lastTopic;
        private string favouriteTopic;
        private bool favouriteTipGiven = false;
        private Dictionary<string, List<string>> keywordResponses; /*Stackoverflow,*/
        private Random random = new Random();
        private Dictionary<string, int> lastResponseIndex = new Dictionary<string, int>();

        //Delegate for handling responses
        private delegate void ResponseHandler(string topic);/*Troelsen and Japikse, 2021*/
        public ChatBot()
        {
            
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
            AskForFavouriteTopic();
            StartTextChat();
        }

        private void AskForUserName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("What is your name?");
            VoiceAssist.synth.Speak("What is your name?");
            userName = Console.ReadLine();

           if (string.IsNullOrEmpty(userName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name cannot be empty. Please insert name.\n");
                VoiceAssist.synth.Speak("Name cannot be empty. Please insert name");
                AskForUserName();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nWelcome, {userName}! Let's talk cybersecurity.\n");
            VoiceAssist.synth.Speak($"Welcome, {userName}! Let's talk cybersecurity");
        }

        private void AskForFavouriteTopic()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What is your favourite cybersecurity topic? (e.g., password, scam, privacy, phishing");
            VoiceAssist.synth.Speak("What is your favourite cybersecurity topic? For example, password, scam, privacy or phishing.");
            favouriteTopic = Console.ReadLine()?.ToLower();

            if (!string.IsNullOrEmpty(favouriteTopic) && keywordResponses.ContainsKey(favouriteTopic))/*Stackoverflow, 2017*/
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Great! I'll remember that you're interested in {favouriteTopic}.");
                VoiceAssist.synth.Speak($"Great! I'll remember that you're interested in {favouriteTopic}.");
            }
            else
            { 
                favouriteTopic = null;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No problem! You can ask me any cybersecurity topic.");
                VoiceAssist.synth.Speak("No problem! You can ask me any cybersecurity topic");
            }

        }


        private void StartTextChat()
        {
            while (true)
          {
             Console.ForegroundColor = ConsoleColor.DarkYellow;
             Console.WriteLine("Ask me something (type 'exit' to quit): ");
             VoiceAssist.synth.Speak("Ask me something or type 'exit' to quit: ");
             string input = Console.ReadLine();

             if (string.IsNullOrEmpty(input))
             {
                 Console.ForegroundColor = ConsoleColor.Red;
                 Console.WriteLine("Please enter something meaningful.");
                 VoiceAssist.synth.Speak("Please enter something meaningful.");
                 continue;
             }

            if (input.ToLower() == "exit")
            {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Goodbye! {userName}! Stay cyber safe and aware!");
                    VoiceAssist.synth.Speak($"Goodbye! {userName}! Stay cyber safe and aware!");
               break;
            }

            RespondToQuestions(input);

          }
        }
        public  void RespondToQuestions(string input)
        {
            string inputLower = input.ToLower();

            //To check if the bot remembers the user's favourite cybersecurity topic (Memory recall)
            if (inputLower.Contains("what is my favourite cybersecurity topic"))
            {
                if(!string.IsNullOrEmpty(favouriteTopic))
                {
                    Console.WriteLine($"Your favourite cybersecurity topic is {favouriteTopic}.");
                    VoiceAssist.synth.Speak($"Your favourite cybersecurity topic is {favouriteTopic}.");
                }
                else
                {
                    Console.WriteLine("You haven't told me your favourite topic yet.");
                    VoiceAssist.synth.Speak("You haven't told me your favourite topic yet.");
                }
                return;
            }

            //To check if the bot rememebers the user's name (Memory recall)
            if(inputLower.Contains("what is my name?"))
            {
                if(!string.IsNullOrEmpty(userName))
                {
                    Console.WriteLine($"Your name is {userName}.");
                    VoiceAssist.synth.Speak($"Your name is {userName}.");
                }
                else
                {
                    Console.WriteLine("You haven't told me your name yet.");
                    VoiceAssist.synth.Speak("You haven't told me your name yet.");
                }
                return;
            }

            //Sentiment detection
            if(inputLower.Contains("worried"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("It's understandable to feel worried. Let me help you stay safe.");
                VoiceAssist.synth.Speak("It's understandable to feel worried. Let me help you stay safe.");
                return;
            }
            else if (inputLower.Contains("curious"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Curiosity is great! Ask me anything about cybersecurity.");
                VoiceAssist.synth.Speak("Curiosity is great! Ask me anything about cybersecurity.");
                return;
            }
            else if (inputLower.Contains("frustrated"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("I understand it can be frustrating. Let me assist you.");
                VoiceAssist.synth.Speak("I understand it can be frustrating. Let me assist you.");
                return;
            }
            else if (inputLower.Contains("excited"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("I'm glad you're excited! Let's learn together.");
                VoiceAssist.synth.Speak("I'm glad you're excited! Let's learn together.");
                return;
            }

            //If user asks for more information on the last topic
            if (!string.IsNullOrEmpty(lastTopic) && inputLower.Contains("more"))
            {
                RespondWithTopic(lastTopic);
                return;
            }


            //Check for keyword recognition and response using delegate
            bool foundKeyword = false;
            foreach (var keyword in keywordResponses.Keys)
            {
                if (inputLower.Contains(keyword))
                {
                    lastTopic = keyword;
                    foundKeyword = true;


                    //If favourite topic matches, show topic before moving to the main answer
                    if (keyword == favouriteTopic && !favouriteTipGiven)
                    {
                        Console.WriteLine($"Since you like {favouriteTopic}, here's a tip: you might want to pay extra attention to this topic.");
                        VoiceAssist.synth.Speak($"Since you like {favouriteTopic}, here's a tip: you might want to pay extra attention to this topic.");
                        favouriteTipGiven = true;
                    }
                    ResponseHandler handler = RespondWithTopic;
                    handler(keyword);
                    break;
                }
            }
                if (!foundKeyword)
                {
                    Console.WriteLine("I'm not sure I understand. Can you try rephrasing or ask about another cybersecurity topic?");
                    VoiceAssist.synth.Speak("I'm not sure I understand. Can you try rephrasing or ask about another cybersecurity topic?");
                }
            }
        
        //Delegate target method for responding to a topic
        private void RespondWithTopic(string topic)
        { 
            var responses = keywordResponses[topic];
            int index = random.Next(responses.Count);

            //To prevent repeat for this topic
            if(lastResponseIndex.ContainsKey(topic) && responses.Count > 1) /*Stackoverflow, 2017*/
            {
                int lastIndex = lastResponseIndex[topic];
                if(index == lastIndex)
                {
                    //Pick the next index
                    index = index + 1;
                    if(index >= responses.Count)
                    {
                        index = 0;
                    }
                }
            }
            lastResponseIndex[topic] = index;
            string response = responses[index];
            Console.WriteLine(response);
            VoiceAssist.synth.Speak(response);
        }
    }
}
/*Reference List:
Stackoverflow. 2017. Incrementing a numerical value in a dictionary.[online]. Available at:<https://stackoverflow.com/questions/7132738/incrementing-a-numerical-value-in-a-dictionary>.[Accessed 24 May 2025].
Troelsen, A. and Japikse, P. 2021.Pro C# 9 with .NET 5:Foundational Principles and Practices in Programming. 10th ed.Apress.
*/
