namespace CyberAwarenessChatbot_Part1
{
     class Program
    {
        static void Main(string[] args)
        {
            VoiceAssist.PlayVoiceGreeting();
            AsciiArt.Display();
            ChatBot chatbot = new ChatBot();
            chatbot.Start();     
        }
    }
}
