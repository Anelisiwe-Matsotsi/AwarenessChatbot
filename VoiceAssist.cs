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
    }
}
