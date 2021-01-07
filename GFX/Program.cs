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
            Vector2 mousePos = Raylib.GetMousePosition();
            float posX = 10;
            float posY = 10;
            // position x-previous resp y-previous
            float posXP = posX;
            float posYP = posY;
            float xSpeed = 0.3f;
            float ySpeed = 0.3f;
            float xSpeedN = 0.3f;
            float ySpeedN = 0.3f;
            bool gameStarted;
            
            gameStarted = false;
        
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
                    Rectangle startGame = new Rectangle(840, 400, 260, 90);
                    Rectangle options = new Rectangle(800, 600, 330, 90);
                    bool areOverlappingStart = Raylib.CheckCollisionPointRec(mousePos, startGame);
                    bool areOverlappingOptions = Raylib.CheckCollisionPointRec(mousePos, options);
                    bool leftMousePressed = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON);

                    Raylib.ClearBackground(Color.RED);     
                    Raylib.DrawText("Game thing! :D", 650, 200, 100, Color.ORANGE);
                    Raylib.DrawText("Start", 840, 400, 90, Color.ORANGE);
                    Raylib.DrawText("Options", 800, 600, 90, Color.ORANGE);

                    if (areOverlappingStart == true)
                    {
                        Raylib.DrawText("Start", 840, 400, 90, Color.YELLOW);

                        if (leftMousePressed == true)
                        {
                            gameStarted = true;
                        }
                    }

                     if (areOverlappingOptions == true)
                    {
                        Raylib.DrawText("Options", 800, 600, 90, Color.YELLOW);

                        if (leftMousePressed == true)
                        {
                            
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
                    Vector2 characterCollisionBox1 = new Vector2(posX+113, posY+150);
                    Rectangle obstacle = new Rectangle(500, 500, 1000, 400);
                    bool characterCollide = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacle);
                    bool characterCollide1 = Raylib.CheckCollisionPointRec(characterCollisionBox1, obstacle);

                    if (characterCollide || characterCollide1 == true)
                    {
/*
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
                            */


                            /*
                            if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && Raylib.IsKeyDown(KeyboardKey.KEY_W))
                            {
                                posX = posXP;
                                Raylib.ClearBackground(Color.BEIGE);
                            }
                            */

                            /*

                            ----------- SLIDE ------------

                            if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_S))
                            {
                                posY = posYP;
                            }

                            else if (Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_A))
                            {
                                posX = posXP;
                            }

                            */
                            
                            posX = posXP;
                            posY = posYP;
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

                    // logga senaste x och y position
                    posXP = posX;
                    posYP = posY;

                    // bool areOverlapping = Raylib.CheckCollisionPointRec(mousePos, SD);
                    Raylib.ClearBackground(Color.BEIGE);
                    Raylib.EndDrawing();
                }
            }
        }
    }
}
