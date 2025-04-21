using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessChatbot_Part1
{

    public static class VoiceAssist
    {
        
        public static SpeechSynthesizer synth = new SpeechSynthesizer();

        //Static constructor sets up the default voice
        static VoiceAssist()
        {
            //Set the voice to the default system voice
            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
        }

        //Plays the wav greeting audio when the app starts
        public static void PlayVoiceGreeting()
        {
            SoundPlayer player = new SoundPlayer("C:\\Users\\ST10328767\\source\\repos\\CyberAwarenessChatbot_Part1\\CyberAwarenessChatbot_Part1\\Resources\\Cybersecurity Bot welcome.wav");
            player.PlaySync(); //is there to make sure the audio finishes before continuing

        }

        //Starts the voice recognition input from the user
        public static void StartRecognition(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[Voice Mode] Speak now...");

            using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine())
            {
                //Loads the default grammar
                recognizer.LoadGrammar(new DictationGrammar());

                //Sets the microphone as the audio input
                recognizer.SetInputToDefaultAudioDevice();

                //when speech is recognized ooutput and respond
                recognizer.SpeechRecognized += (s, e) =>
                {
                    string input = e.Result.Text.ToLower();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"You said: {input}");
                    
                    //use a new instance of the bot to respond
                    ChatBot chatbot = new ChatBot();
                    chatbot.RespondToQuestions(input);
                };

                //Begin listening
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                
                //keeps listening until Enter is pressed
                Console.ReadLine();
                recognizer.RecognizeAsyncStop();
            }
        }
    }
}
