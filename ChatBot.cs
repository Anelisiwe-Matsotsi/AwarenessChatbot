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
        private readonly VoiceAssist voice;
        private string userName; 
        private string lastTopic;//tracks the last discussed topic
        private string favouriteTopic;
        private bool favouriteTipGiven = false;//ensures the favourite tip is only given once
        private Dictionary<string, List<string>> keywordResponses; /*Stackoverflow,2020*/
        private Random random = new Random();
        private Dictionary<string, int> lastResponseIndex = new Dictionary<string, int>();//tracks last response index for each topic so that repeast are avoided

        //Delegate for handling responses
        private delegate void ResponseHandler(string topic);/*Troelsen and Japikse, 2021*/
        public ChatBot(VoiceAssist voiceAssist)
        {
            voice = voiceAssist;

            //Constructor initializes the keywordResponses dictionary with tips
            //Cybersecurity tips from CISA (CISA, 2022)
            //Dictionary from Stackoverflow, 2020
            keywordResponses = new Dictionary<string, List<string>>
            {
               {"password", new List<string>
                    { /*CISA, 2022*/
                        "Make each password unique for each account.",
                        "Don't use names or easy guesses like '1 2 3 4 5 6' or 'password1 2 3'.",
                        "Consider getting a password manager to help you generate and store strong passwords securely."
                    }
               },

               {"scam", new List<string>
                    { /*CISA, 2022*/
                        "Be cautious of unsolicited emails or messages asking for personal information.",
                        "Always verify the sender's identity  before responding.",
                        "Look out for spelling mistakes and urgent requests in scam messages."
                    }
               },

               {"privacy", new List<string>
                    { /*CISA, 2022*/
                        "Review your privacy settings regularly on social media.",
                        "Be careful about what personal information you share online.",
                        "Enable two-factor authentication to protect your accounts."
                    }
               },

               {"phishing", new List<string>
                    { /*CISA, 2022*/
                        "Phishing tricks you into revealing personal information via fake emails or websites.So if you get a suspicious email or message, don't click it.",
                        "Check email addresses carefully, phishing emails often look similar to legitimate ones.",
                        "Watch out for signs like bad grammar, odd-looking emails or too good to be true deals."
                    }
               }

            };
            this.voice = voice;
        }

        //Starts the chatbot conersation
        public void Start() 
        {
            
            AskForUserName();
            AskForFavouriteTopic();
            StartTextChat();
        }

        //Prompts the user for their name and greets them
        private void AskForUserName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("What is your name?");
            voice.Speak("What is your name?");
            userName = Console.ReadLine();

           if (string.IsNullOrEmpty(userName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name cannot be empty. Please insert name.\n");
                voice.Speak("Name cannot be empty. Please insert name");
                AskForUserName();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nWelcome, {userName}! Let's talk cybersecurity.\n");
            voice.Speak($"Welcome, {userName}! Let's talk cybersecurity");
        }

        //Asks the user for their favourite topic

        private void AskForFavouriteTopic()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What is your favourite cybersecurity topic? (e.g., password, scam, privacy, phishing)");
            voice.Speak("What is your favourite cybersecurity topic? For example, password, scam, privacy or phishing.");
            favouriteTopic = Console.ReadLine()?.ToLower();

            //if the topic is recognized, it is acknowledged
            if (!string.IsNullOrEmpty(favouriteTopic) && keywordResponses.ContainsKey(favouriteTopic))/*Stackoverflow, 2017*/
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Great! I'll remember that you're interested in {favouriteTopic}.");
                voice.Speak($"Great! I'll remember that you're interested in {favouriteTopic}.");
            }
            else
            { 
                // if not recognized
                favouriteTopic = null;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No problem! You can ask me any cybersecurity topic.");
                voice.Speak("No problem! You can ask me any cybersecurity topic");
            }

        }


        //this handles user input as well as conversation flow between user and chatbot
        private void StartTextChat()
        {
            while (true)
          {
             Console.ForegroundColor = ConsoleColor.DarkYellow;
             Console.WriteLine("Ask me something (type 'exit' to quit): ");
             voice.Speak("Ask me something or type 'exit' to quit: ");
             string input = Console.ReadLine();

             if (string.IsNullOrEmpty(input))
             {
                 Console.ForegroundColor = ConsoleColor.Red;
                 Console.WriteLine("Please enter something meaningful.");
                 voice.Speak("Please enter something meaningful.");
                 continue;
             }

            if (input.ToLower() == "exit")
            {
                    //Remind user of the last topic before exiting the program
                    if(!string.IsNullOrEmpty(lastTopic))
                    {
                        Console.WriteLine($"Before you go, remember what we discussed about {lastTopic}.");
                        voice.Speak($"Before you go, remember what we discussed about {lastTopic}.");
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Goodbye! {userName}! Stay cyber safe and aware!");
                    voice.Speak($"Goodbye! {userName}! Stay cyber safe and aware!");
                    break;
            }

            RespondToQuestions(input);

          }
        }

        //Responsible for processing user questions and provide appropriate responses
        public  void RespondToQuestions(string input)
        {
            string inputLower = input.ToLower();


            //To check if the bot remembers the user's favourite cybersecurity topic (Memory recall)
            if (inputLower.Contains("what is my favourite cybersecurity topic"))
            {
                if(!string.IsNullOrEmpty(favouriteTopic))
                {
                    Console.WriteLine($"Your favourite cybersecurity topic is {favouriteTopic}.");
                    voice.Speak($"Your favourite cybersecurity topic is {favouriteTopic}.");
                }
                else
                {
                    Console.WriteLine("You haven't told me your favourite topic yet.");
                    voice.Speak("You haven't told me your favourite topic yet.");
                }
                return;
            }

            //To check if the bot rememebers the user's name (Memory recall)
            if(inputLower.Contains("what is my name?"))
            {
                if(!string.IsNullOrEmpty(userName))
                {
                    Console.WriteLine($"Your name is {userName}.");
                    voice.Speak($"Your name is {userName}.");
                }
                else
                {
                    Console.WriteLine("You haven't told me your name yet.");
                    voice.Speak("You haven't told me your name yet.");
                }
                return;
            }
            /*Troelsen and Japikse, 2021*/
            //Sentiment detection, using basic keyword-based mood recognition
            if (inputLower.Contains("worried"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("It's understandable to feel worried. Let me help you stay safe.");
                voice.Speak("It's understandable to feel worried. Let me help you stay safe.");
                return;
            }
            else if (inputLower.Contains("curious"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Curiosity is great! Ask me anything about cybersecurity.");
                voice.Speak("Curiosity is great! Ask me anything about cybersecurity.");
                return;
            }
            else if (inputLower.Contains("frustrated"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("I understand it can be frustrating. Let me assist you.");
                voice.Speak("I understand it can be frustrating. Let me assist you.");
                return;
            }
            else if (inputLower.Contains("excited"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("I'm glad you're excited! Let's learn together.");
                voice.Speak("I'm glad you're excited! Let's learn together.");
                return;
            }

            //If user asks for more information on the last topic
            if (!string.IsNullOrEmpty(lastTopic) && inputLower.Contains("more"))
            {
                Console.WriteLine($"Sure, {userName}, here's another fact about {lastTopic}:");
                voice.Speak($"Sure, {userName}, here's another fact about {lastTopic}:");
                RespondWithTopic(lastTopic);
                return;
            }

            //if user wants to switch to another topic
            if (inputLower.Contains("another topic") || inputLower.Contains("different topic") || inputLower.Contains("next topic"))
            {
                Console.WriteLine("Here are some topics you can ask about: password, scam, privacy, phishing. Which one interests you?");
                voice.Speak("Here are some topics you can ask about: password, scam, privacy, phishing. Which one interests you?");
                return;
            }

            //Check for keyword recognition and response using delegate
            bool foundKeyword = false;
            foreach (var keyword in keywordResponses.Keys)/*Troelsen and Japikse, 2021*/
            {
                if (inputLower.Contains(keyword))
                {
                    lastTopic = keyword;
                    foundKeyword = true;

                    Console.WriteLine($"You mentioned {keyword}, let's dive into that.");
                    voice.Speak($"You mentioned {keyword}, let's dive into that.");

                    //If favourite topic matches, show topic before moving to the main answer
                    if (keyword == favouriteTopic && !favouriteTipGiven)
                    {
                        Console.WriteLine($"Since you like {favouriteTopic}, here's a tip: you might want to pay extra attention to this topic.");
                        voice.Speak($"Since you like {favouriteTopic}, here's a tip: you might want to pay extra attention to this topic.");
                        favouriteTipGiven = true;
                    }
                    
                    //Use delegate to call the topic response method
                    ResponseHandler handler = RespondWithTopic;
                    handler(keyword);
                    Console.WriteLine("Would you like to hear more about this or ask about another topic?");
                    voice.Speak("Would you like to hear more about this or ask about another topic?");
                    break;
                }
            }
            //if there is no keyword matched, ask the user to rephrase
                if (!foundKeyword)
                {
                    Console.WriteLine("I'm not sure I understand. Can you try rephrasing or ask about another cybersecurity topic?");
                    voice.Speak("I'm not sure I understand. Can you try rephrasing or ask about another cybersecurity topic?");
                }
            }
        
        //Delegate target method for responding to a topic and avoids immediate repeats
        private void RespondWithTopic(string topic)
        { 
            var responses = keywordResponses[topic];
            int index = random.Next(responses.Count); /*Microsoft,2025*/

            //To prevent repeat of the same tip in a row for a topic
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
            voice.Speak(response);
        }
    }
}
/*Reference List:
CISA (Cybersecurity & Infrastructure Security Acency). 2022.4 Things You Can Do To Keep Yourself Cyber Safe/[online].Available at:<https://www.cisa.gov/news-events/news/4-things-you-can-do-keep-yourself-cyber-safe >.[Accessed 23 May 2025].
Microsoft.2025.Random.Next Method.[online].Available at:<https://learn.microsoft.com/en-us/dotnet/api/system.random.next?view=net-9.0>.[Accessed 24 May 2025].
Stackoverlow.2020. Convert a Dictionary<string,List<string>> into a List<string,string>.[online].Available at:<https://stackoverflow.com/questions/62470884/convert-a-dictionarystring-liststring-into-a-liststring-string>.[Accessed 23 May 2025].
Stackoverflow. 2017. Incrementing a numerical value in a dictionary.[online]. Available at:<https://stackoverflow.com/questions/7132738/incrementing-a-numerical-value-in-a-dictionary>.[Accessed 24 May 2025].
Troelsen, A. and Japikse, P. 2021.Pro C# 9 with .NET 5:Foundational Principles and Practices in Programming. 10th ed.Apress.
*/
