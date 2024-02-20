using System;

namespace rps2
{
    class Program
    {
        static void Main()
        {
            Interface.GiveWelcomeMessage();
            Array array = Interface.mainMenu(); 
        }
    }
}