using System;

namespace Example
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            using var game = new Game1();
            game.Run();
        }
    }
}