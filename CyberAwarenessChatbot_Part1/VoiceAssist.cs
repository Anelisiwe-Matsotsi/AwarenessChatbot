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
    /*Troelsen and Japikse, 2021*/
    public static class VoiceAssist
    {
        
        public static SpeechSynthesizer synth = new SpeechSynthesizer();

        //Static constructor sets up the default voice
        static VoiceAssist()
        {
            //Set the voice to the default system voice
            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
        }

        /*Stackoverflow, 2022*/
        //Plays the wav greeting audio when the app starts
        public static void PlayVoiceGreeting()
        {
            SoundPlayer player = new SoundPlayer("C:\\Users\\ST10328767\\source\\repos\\CyberAwarenessChatbot_Part1\\CyberAwarenessChatbot_Part1\\Resources\\ChatBot Welcome.wav");
            player.PlaySync(); //is there to make sure the audio finishes before continuing
        }
    }
}
/*Referenece List:
 Stackoverflow.2022.Is there a way to publish a C# console app running on the .NET Framework with System.media Soundplayer? [online].Available at:<https://stackoverflow.com/questions/72754912/is-there-a-way-to-publish-a-c-sharp-console-app-running-on-the-net-framework-wi>.[Accessed 14 April 2025]. 
 Troelsen,A. and Japikse, P. 2021.Pro C# 9 with .NET 5:Foundational Principles and Practices in Programming. 10th ed.Apress. 
 */
