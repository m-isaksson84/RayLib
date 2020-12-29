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
            float xSpeed = 0.3f;
            float ySpeed = 0.3f;
            float xSpeedN = 0.3f;
            float ySpeedN = 0.3f;
            bool gameStarted;
            gameStarted = false;
            Vector2 mousePos = Raylib.GetMousePosition();
        
            while (!Raylib.WindowShouldClose())
            {
                float width = 2000;
                float height = 1200;
                float xMovement = 0;
                float yMovement = 0;
                float xMovementN = 0;
                float yMovementN = 0;

                if (gameStarted == false) {

                    // resettar spelarens potition (gör till en metod som resettar allt)
                    posX = 10;
                    posY = 10;
                    xSpeed = 0.3f;
                    ySpeed = 0.3f;
                    xSpeedN = 0.3f;
                    ySpeedN = 0.3f;


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
                        yMovement = ySpeed;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && posY > 0)
                    {
                        yMovementN = -ySpeedN;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && posX < width - 112.5)
                    {
                        xMovement = xSpeed;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && posX > 0)
                    {
                        xMovementN = -xSpeedN;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_B))
                    {
                        gameStarted = false;
                    }

                    posX += xMovement;
                    posY += yMovement;

                    posX += xMovementN;
                    posY += yMovementN;

                    Raylib.BeginDrawing();
                    Raylib.SetExitKey(KeyboardKey.KEY_Q);


                    // sätter upp kollosioner för karaktären genom att testa ifall vector2 (characterCollisionBox) kolliderar med obstacle, returnerar true om de överlappar (kolliderar)
                    Vector2 characterCollisionBox = new Vector2(posX, posY);
                    Rectangle obstacle = new Rectangle(500, 500, 1000, 400);
                    bool characterCollide = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacle); 

                    if (characterCollide == true)
                    {

                            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                            {
                                ySpeedN = 0;
                            }

                            else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                            {
                                xSpeed = 0;
                            }

                            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                            {
                                ySpeed = 0;
                            } 

                            else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                            {
                                xSpeedN = 0;
                            }
                    }

                    else 
                    {
                        xSpeed = 0.3f;
                        ySpeed = 0.3f;
                        xSpeedN = 0.3f;
                        ySpeedN = 0.3f;
                    }

                    Raylib.DrawRectangle(500, 500, 1000, 400, Color.WHITE);
                    Raylib.DrawTextureEx(SD, new Vector2(posX, posY), 0f, 0.25f, Color.WHITE);

                // bool areOverlapping = Raylib.CheckCollisionPointRec(mousePos, SD);
                    
                    Raylib.ClearBackground(Color.BEIGE);
                    Raylib.EndDrawing();
                }
           }
        }
    }
}
