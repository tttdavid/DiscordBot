using System;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            DotNetEnv.Env.Load("../build/");
            var Bot = new Bot();
            Bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}