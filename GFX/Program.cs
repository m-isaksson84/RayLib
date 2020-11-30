using System;
using Raylib_cs;

namespace GFX
{
    class Program
    {
        static void Main(string[] args)
        {

            Raylib.InitWindow(800, 600, "bildtest");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.BEIGE);

                Raylib.EndDrawing();
            }
        }
    }
}
