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
    public  class VoiceAssist
    {

        private readonly SpeechSynthesizer synth; /*Microsoft, 2025*/

        //Static constructor sets up the default voice
        public VoiceAssist()
        {
            synth = new SpeechSynthesizer();
            //Set the voice to the default system voice
            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
        }

        public void Speak(string text)
        {
            synth.Speak(text);
        }

        /*Stackoverflow, 2022*/
        //Plays the wav greeting audio when the app starts
        public  void PlayVoiceGreeting()
        {
            SoundPlayer player = new SoundPlayer("Resources/Botty.wav");
            player.PlaySync(); //is there to make sure the audio finishes before continuing
        }
    }
}
/*Referenece List:
 Microsoft.2025.SpeechSynthesizer Class. [online].Available at:< https://learn.microsoft.com/en-us/dotnet/api/system.speech.synthesis.speechsynthesizer?view=net-9.0-pp >.[Accessed 22 May 2025].
 Stackoverflow.2022.Is there a way to publish a C# console app running on the .NET Framework with System.media Soundplayer? [online].Available at:<https://stackoverflow.com/questions/72754912/is-there-a-way-to-publish-a-c-sharp-console-app-running-on-the-net-framework-wi>.[Accessed 14 April 2025]. 
 Troelsen,A. and Japikse, P. 2021.Pro C# 9 with .NET 5:Foundational Principles and Practices in Programming. 10th ed.Apress. 
 */
