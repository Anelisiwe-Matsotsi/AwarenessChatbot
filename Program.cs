namespace CyberAwarenessChatbot_Part1
{
     class Program
    {
        static void Main(string[] args)
        {
            //Play the greeting using wav file accessed through VoiceAssist class
            VoiceAssist.PlayVoiceGreeting();
            
            //Display the chatbot's welcome art
            AsciiArt.Display();

            //Create an instance of the ChatBot claas in order to access information and display it
            ChatBot chatbot = new ChatBot();
            
            chatbot.Start();     
        }
    }
}
