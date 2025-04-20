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
        public static void PlayVoiceGreeting()
        {
            SoundPlayer player = new SoundPlayer("C:\\Users\\ST10328767\\source\\repos\\CyberAwarenessChatbot_Part1\\CyberAwarenessChatbot_Part1\\Resources\\Cybersecurity Bot welcome.wav");
            player.PlaySync();

        }
        public static void StartRecognition(string userName)
        {
            Console.WriteLine("\n[Voice Mode] Speak now...", ConsoleColor.Cyan);
            using(SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine())
            {
                recognizer.LoadGrammar(new DictationGrammar());
                recognizer.SetInputToDefaultAudioDevice();

                recognizer.SpeechRecognized += (s, e) =>
                {
                    string input = e.Result.Text;
                    Console.WriteLine($"You said: {input}", ConsoleColor.DarkBlue);
                    ChatBot.RespondToQuestions(input.ToLower(), userName);
                };
                recognizer.RecognizeCompleted += (s, e) =>
                {
                    Console.WriteLine("Recognition ended.\n", ConsoleColor.DarkGray);
                };
                recognizer.RecognizeAsync(RecognizeMode.Single);
                Console.WriteLine("Press Enter to stop listening...", ConsoleColor.DarkGray);
                Console.ReadLine();
                recognizer.RecognizeAsyncStop();

            }
        }
    }
}
