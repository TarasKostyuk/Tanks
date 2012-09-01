using System;

namespace TanksGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Tanks game = new Tanks())
            {
                game.Run();
            }
        }
    }
#endif
}

