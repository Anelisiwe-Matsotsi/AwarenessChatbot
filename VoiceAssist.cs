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

        static VoiceAssist()
        {
            //Set the voice to the default system voice
            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
        }
        public static void PlayVoiceGreeting()
        {
            SoundPlayer player = new SoundPlayer("C:\\Users\\ST10328767\\source\\repos\\CyberAwarenessChatbot_Part1\\CyberAwarenessChatbot_Part1\\Resources\\Cybersecurity Bot welcome.wav");
            player.PlaySync();

        }
        public static void StartRecognition(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[Voice Mode] Speak now...");

            using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine())
            {
                recognizer.LoadGrammar(new DictationGrammar());
                recognizer.SetInputToDefaultAudioDevice();

                recognizer.SpeechRecognized += (s, e) =>
                {
                    string input = e.Result.Text.ToLower();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"You said: {input}");
                    ChatBot chatbot = new ChatBot();
                    chatbot.RespondToQuestions(input);
                };

                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                Console.ReadLine();
                recognizer.RecognizeAsyncStop();
            }
        }
    }
}
