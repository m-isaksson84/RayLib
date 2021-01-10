using System;
using Raylib_cs;
using System.Numerics;

namespace GFX
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Raylib.InitWindow(2000 , 1200 , "Game Thing! :D");
            Texture2D SD = Raylib.LoadTexture("character.png");
            Vector2 mousePos = Raylib.GetMousePosition();
            float posX = 1800;
            float posY = 80;

            // position x-previous resp y-previous.
            float posXP = posX;
            float posYP = posY;

            // standardhastighet för spelaren, SpeedN = SpeedNegative.
            float xSpeed = 0.3f;
            float ySpeed = 0.3f;
            float xSpeedN = 0.3f;
            float ySpeedN = 0.3f;
            bool gameStarted;
            bool startLevel1;
            bool startLevel2;

            // Knappar för menyn.
            Rectangle startGame = new Rectangle(840, 400, 260, 90);
            Rectangle options = new Rectangle(800, 600, 330, 90);

            // Hitboxes för spelet
            Rectangle obstacle = new Rectangle(400, 300, 1600, 600);
            Rectangle obstacle2 = new Rectangle(0, 0, 100, 1200);
            Rectangle obstacleLevel2 = new Rectangle(1600, 400, 300, 500);
            Rectangle finishLineLevel1 = new Rectangle(1800, 1000, 100, 200);
            
            gameStarted = false;
            startLevel1 = false;
            startLevel2 = false;
        
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
                    posX = 1800;
                    posY = 80;
                    xSpeed = 0.3f;
                    ySpeed = 0.3f;
                    xSpeedN = 0.3f;
                    ySpeedN = 0.3f;


                    mousePos = Raylib.GetMousePosition();

                
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
                            startLevel1 = true;
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
                

                    if (gameStarted == true) {
                        
                        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && posY < height - 150)
                        {
                            yMovement = ySpeed;
                        }

                        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && posY > 0)
                        {
                            yMovementN = -ySpeedN;
                        }

                        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && posX < width - 113)
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
                            startLevel1 = false;
                            startLevel2 = false;
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
                        Vector2 characterCollisionBox2 = new Vector2(posX, posY+150); // vektorn går från posX till PosY+150 vilket skapar en diagonal linje
                        Vector2 characterCollisionBox3 = new Vector2(posX+113, posY); // vektorn går från PosX+113 till posY vilket skapar en diagonal linje

                        if (startLevel1 == true) 
                        {

                            bool characterCollide = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacle);
                            bool characterCollide1 = Raylib.CheckCollisionPointRec(characterCollisionBox1, obstacle);
                            bool characterCollide2 = Raylib.CheckCollisionPointRec(characterCollisionBox2, obstacle);
                            bool characterCollide3 = Raylib.CheckCollisionPointRec(characterCollisionBox3, obstacle);

                            bool test = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacle2);
                            bool test1 = Raylib.CheckCollisionPointRec(characterCollisionBox1, obstacle2);
                            bool test2 = Raylib.CheckCollisionPointRec(characterCollisionBox2, obstacle2);
                            bool test3 = Raylib.CheckCollisionPointRec(characterCollisionBox3, obstacle2);

                            bool finishLevel = Raylib.CheckCollisionPointRec(characterCollisionBox, finishLineLevel1);
                            bool finishLevel1 = Raylib.CheckCollisionPointRec(characterCollisionBox1, finishLineLevel1);

                            if (test || test1 || test2 || test3 == true)
                            {
                                posX = posXP;
                                posY = posYP;
                            }

                            if (characterCollide || characterCollide1 || characterCollide2 || characterCollide3 == true)
                            {            
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

                            if (finishLevel || finishLevel1 == true)
                            {
                                startLevel1 = false;
                                startLevel2 = true;
                                posX = 1800;
                                posY = 80;
                                xSpeed = 0.3f;
                                ySpeed = 0.3f;
                                xSpeedN = 0.3f;
                                ySpeedN = 0.3f;
                            }

                            Raylib.DrawRectangle(400, 300, 1600, 600, Color.WHITE);
                            Raylib.DrawRectangle(0, 0, 100, 1200, Color.WHITE);
                            Raylib.DrawText("Use WASD to move and navigate to the red square :D", 680, 500, 40, Color.BLACK);
                            Raylib.DrawRectangle(1800, 1000, 100, 100, Color.RED);
                            Raylib.DrawRectangle(1800, 80, 10, 10, Color.RED);
                            Raylib.DrawTextureEx(SD, new Vector2(posX, posY), 0f, 0.25f, Color.WHITE);
                        }


                        if (startLevel2 == true) 
                        {
                            bool characterCollideLVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacleLevel2);
                            bool characterCollide1LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox1, obstacleLevel2);
                            bool characterCollide2LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox2, obstacleLevel2);
                            bool characterCollide3LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox3, obstacleLevel2);

                            if (characterCollideLVL2 || characterCollide1LVL2 || characterCollide2LVL2 || characterCollide3LVL2 == true)
                            {            
                                posX = posXP;
                                posY = posYP;
                            }


                            Raylib.ClearBackground(Color.RED);
                            Raylib.DrawRectangle(1600, 400, 300, 500, Color.WHITE);

            
                            Raylib.DrawRectangle(1800, 1000, 100, 100, Color.RED);

                            Raylib.DrawRectangle(1800, 80, 10, 10, Color.RED);
                            Raylib.DrawTextureEx(SD, new Vector2(posX, posY), 0f, 0.25f, Color.WHITE);
                        }



                        // logga senaste x och y position
                        posXP = posX;
                        posYP = posY;

                        // bool areOverlapping = Raylib.CheckCollisionPointRec(mousePos, SD);
                        Raylib.ClearBackground(Color.BROWN);
                        Raylib.DrawText("B - Back to menu", 5, 5, 20, Color.BLACK);
                        Raylib.DrawText("Q - Quit game", 5, 25, 20, Color.BLACK);
                        Raylib.EndDrawing();
                    }
                }
            }
        }
    }
}
