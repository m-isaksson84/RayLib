using System;
using Raylib_cs;
using System.Numerics;

namespace GFX
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Raylib.InitWindow(2000 , 1200 , "bildtest");
            Texture2D SD = Raylib.LoadTexture("character.png");
            float posX = 10;
            float posY = 10;
            float Speed = 0.3f;
            bool gameStarted;
            gameStarted = false;
            Vector2 mousePos = Raylib.GetMousePosition();
        
            while (!Raylib.WindowShouldClose())
            {
                float width = 2000;
                float height = 1200;
                float xMovement = 0;
                float yMovement = 0;

                if (gameStarted == false) {

                    // resettar spelarens potition (gör till en metod som resettar allt)
                    posX = 10;
                    posY = 10;
                    Speed = 0.3f;


                    mousePos = Raylib.GetMousePosition();
                    Rectangle startGame = new Rectangle(620, 400, 620, 90);
                    bool areOverlapping = Raylib.CheckCollisionPointRec(mousePos, startGame); 
                    bool leftMousePressed = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON);

                    Raylib.ClearBackground(Color.RED);     
                    Raylib.DrawText("Spel!", 800, 200, 100, Color.ORANGE);
                    Raylib.DrawText("Starta Spelet", 620, 400, 90, Color.ORANGE);

                    if (areOverlapping == true)
                    {
                        Raylib.DrawText("Starta Spelet", 620, 400, 90, Color.YELLOW);

                        if (leftMousePressed == true)
                        {
                            gameStarted = true;
                        }
                    }   

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_X))
                    {
                        gameStarted = true;
                    }
                    Raylib.EndDrawing();  
                }

                if (gameStarted == true) {
                    
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && posY < height - 150)
                    {
                        yMovement = Speed;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && posY > 0)
                    {
                        yMovement = -Speed;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && posX < width - 112.5)
                    {
                        xMovement = Speed;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && posX > 0)
                    {
                        xMovement = -Speed;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_B))
                    {
                        gameStarted = false;
                    }

                    posX += xMovement;
                    
                    posY += yMovement;
                    Raylib.BeginDrawing();
                    Raylib.SetExitKey(KeyboardKey.KEY_Q);

                    Raylib.DrawTextureEx(SD, new Vector2(posX, posY), 0f, 0.25f, Color.WHITE);

                // bool areOverlapping = Raylib.CheckCollisionPointRec(mousePos, SD);
                    
                    Raylib.ClearBackground(Color.BEIGE);
                    Raylib.EndDrawing();
                }
           }
        }
    }
}
