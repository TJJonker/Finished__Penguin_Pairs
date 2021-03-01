using System;

namespace Engine
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new JewelJam())
                game.Run();
        }
    }
}
