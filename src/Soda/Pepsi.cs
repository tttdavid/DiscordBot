using System;

namespace src
{
    public static class Pepsi
    {
        public static string Get(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
    }
}
