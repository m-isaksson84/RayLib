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
            Texture2D Character = Raylib.LoadTexture("character.png");
            Vector2 mousePos = Raylib.GetMousePosition();
            float posX = 1800;
            float posY = 80;

            // position x-previous resp y-previous.
            float posXP = posX;
            float posYP = posY;

            int gun1posY = 0;

            // standardhastighet för spelaren, SpeedN = SpeedNegative.
            float xSpeed = 0.3f;
            float ySpeed = 0.3f;
            float xSpeedN = 0.3f;
            float ySpeedN = 0.3f;

            int gunSpeedY = 1;

            bool gameStarted;
            bool startLevel1;
            bool startLevel2;

            // Knappar för menyn.
            Rectangle startGame = new Rectangle(840, 400, 260, 90);
            Rectangle options = new Rectangle(800, 600, 330, 90);

            // Hitboxes för spelet
            Rectangle obstacle = new Rectangle(400, 300, 1600, 600);
            //Rectangle obstacle2 = new Rectangle(0, 0, 100, 1200);
            Rectangle finishLineLevel1 = new Rectangle(1800, 1000, 100, 200);

            Rectangle obstacleLevel2 = new Rectangle(400, 250, 1800, 150);
            Rectangle obstacle2Level2 = new Rectangle(0, 250, 200, 150);

            Rectangle obstacle3Level2 = new Rectangle(0, 650, 1600, 150);
            Rectangle obstacle4Level2 = new Rectangle(1800, 650, 200, 150);

            Rectangle obstacle5Level2 = new Rectangle(300, 1050, 1300, 150);
            Rectangle obstacle6Level2 = new Rectangle(0, 1050, 200, 150);

            Rectangle finishLineLevel2 = new Rectangle(100, 1050, 200, 150);

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

                gun1posY += gunSpeedY;

                if (gun1posY > 4000) {
                    gun1posY = 0;
                }


                if (gameStarted == false) {

                    startLevel1 = false;
                    startLevel2 = false;
                
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

                        //Vector2 gun1CollisionBox = new Vector2(gun1posX, gun1posY);
                        //Vector2 gun2CollisionBox = new Vector2(gun2posX, gun2posY);

                        if (startLevel1 == true) 
                        {

                            bool characterCollide = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacle);
                            bool characterCollide1 = Raylib.CheckCollisionPointRec(characterCollisionBox1, obstacle);
                            bool characterCollide2 = Raylib.CheckCollisionPointRec(characterCollisionBox2, obstacle);
                            bool characterCollide3 = Raylib.CheckCollisionPointRec(characterCollisionBox3, obstacle);
/*
                            bool test = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacle2);
                            bool test1 = Raylib.CheckCollisionPointRec(characterCollisionBox1, obstacle2);
                            bool test2 = Raylib.CheckCollisionPointRec(characterCollisionBox2, obstacle2);
                            bool test3 = Raylib.CheckCollisionPointRec(characterCollisionBox3, obstacle2);
*/
                            bool finishLevel = Raylib.CheckCollisionPointRec(characterCollisionBox, finishLineLevel1);
                            bool finishLevel1 = Raylib.CheckCollisionPointRec(characterCollisionBox1, finishLineLevel1);

/*
                            if (test || test1 || test2 || test3 == true)
                            {
                                posX = posXP;
                                posY = posYP;
                            }
*/
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
                            Raylib.DrawText("Use WASD to move and navigate to the red square :D", 680, 500, 40, Color.BLACK);
                            Raylib.DrawRectangle(1800, 1000, 100, 100, Color.RED);
                            Raylib.DrawRectangle(1800, 80, 10, 10, Color.RED);
                            Raylib.DrawTextureEx(Character, new Vector2(posX, posY), 0f, 0.25f, Color.WHITE);
                        }


                        if (startLevel2 == true) 
                        {

                            Rectangle gun1 = new Rectangle(1040, gun1posY, 115, 20);

                            bool characterCollideLVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacleLevel2);
                            bool characterCollide1LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox1, obstacleLevel2);
                            bool characterCollide2LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox2, obstacleLevel2);
                            bool characterCollide3LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox3, obstacleLevel2);

                            bool characterCollide4LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacle2Level2);
                            bool characterCollide5LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox1, obstacle2Level2);
                            bool characterCollide6LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox2, obstacle2Level2);
                            bool characterCollide7LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox3, obstacle2Level2);

                            bool characterCollide8LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacle3Level2);
                            bool characterCollide9LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox1, obstacle3Level2);
                            bool characterCollide10LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox2, obstacle3Level2);
                            bool characterCollide11LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox3, obstacle3Level2);

                            bool characterCollide12LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacle4Level2);
                            bool characterCollide13LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox1, obstacle4Level2);
                            bool characterCollide14LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox2, obstacle4Level2);
                            bool characterCollide15LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox3, obstacle4Level2);

                            bool characterCollide16LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacle5Level2);
                            bool characterCollide17LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox1, obstacle5Level2);
                            bool characterCollide18LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox2, obstacle5Level2);
                            bool characterCollide19LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox3, obstacle5Level2);

                            bool characterCollide20LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox, obstacle6Level2);
                            bool characterCollide21LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox1, obstacle6Level2);
                            bool characterCollide22LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox2, obstacle6Level2);
                            bool characterCollide23LVL2 = Raylib.CheckCollisionPointRec(characterCollisionBox3, obstacle6Level2);

                            bool characterShot = Raylib.CheckCollisionPointRec(characterCollisionBox, gun1);
                            bool characterShot1 = Raylib.CheckCollisionPointRec(characterCollisionBox1, gun1);
                            bool characterShot2 = Raylib.CheckCollisionPointRec(characterCollisionBox2, gun1);
                            bool characterShot3 = Raylib.CheckCollisionPointRec(characterCollisionBox3, gun1);

                            bool finishLevel3 = Raylib.CheckCollisionPointRec(characterCollisionBox, finishLineLevel2);
                            bool finishLevel4 = Raylib.CheckCollisionPointRec(characterCollisionBox1, finishLineLevel2);

                            //bool shotByGun1 = Raylib.CheckCollisionPointRec(characterCollisionBox, gun1CollisionBox);

                            if (characterCollideLVL2 || characterCollide1LVL2 || characterCollide2LVL2 || characterCollide3LVL2 == true)
                            {            
                                posX = posXP;
                                posY = posYP;
                            }

                            if (characterCollide4LVL2 || characterCollide5LVL2 || characterCollide6LVL2 || characterCollide7LVL2 == true)
                            {            
                                posX = posXP;
                                posY = posYP;
                            }

                            if (characterCollide8LVL2 || characterCollide9LVL2 || characterCollide10LVL2 || characterCollide11LVL2 == true)
                            {            
                                posX = posXP;
                                posY = posYP;
                            }

                            if (characterCollide12LVL2 || characterCollide13LVL2 || characterCollide14LVL2 || characterCollide15LVL2 == true)
                            {            
                                posX = posXP;
                                posY = posYP;
                            }

                            if (characterCollide16LVL2 || characterCollide17LVL2 || characterCollide18LVL2 || characterCollide19LVL2 == true)
                            {            
                                posX = posXP;
                                posY = posYP;
                            }

                            if (characterCollide20LVL2 || characterCollide21LVL2 || characterCollide22LVL2 || characterCollide23LVL2 == true)
                            {            
                                posX = posXP;
                                posY = posYP;
                            }

                            if (characterShot || characterShot1 || characterShot2 || characterShot3 == true)
                            {            
                                gameStarted = false;
                            }

                            if (finishLevel3 || finishLevel4 == true)
                            {
                                gameStarted = false;
                                posX = 1800;
                                posY = 80;
                                xSpeed = 0.3f;
                                ySpeed = 0.3f;
                                xSpeedN = 0.3f;
                                ySpeedN = 0.3f;
                            }


                            Raylib.ClearBackground(Color.RED);
                            Raylib.DrawRectangle(400, 250, 600, 150, Color.WHITE);
                            Raylib.DrawRectangle(1100, 250, 1000, 150, Color.WHITE);
                            Raylib.DrawRectangle(0, 250, 200, 150, Color.WHITE);

                            Raylib.DrawRectangle(0, 650, 1000, 150, Color.WHITE);
                            Raylib.DrawRectangle(1100, 650, 500, 150, Color.WHITE);
                            Raylib.DrawRectangle(1800, 650, 200, 150, Color.WHITE);


                            Raylib.DrawRectangle(300, 1050, 1800, 150, Color.WHITE);
                            Raylib.DrawRectangle(0, 1050, 200, 150, Color.WHITE);

            
                            Raylib.DrawRectangle(100, 1050, 200, 150, Color.RED);

                            Raylib.DrawRectangle(1800, 80, 10, 10, Color.RED);
                            Raylib.DrawTextureEx(Character, new Vector2(posX, posY), 0f, 0.25f, Color.WHITE);

                            Raylib.DrawRectangle(1040, gun1posY, 20, 20, Color.RED);

                            //Raylib.DrawTextureEx(SD, new Vector2(gun1posX, gun1posY), 0.1f, 0.1f, Color.WHITE);
                            //Raylib.DrawTextureEx(SD, new Vector2(gun2posX, gun2posY), 0.1f, 0.1f, Color.WHITE);
                        }



                        // logga senaste x och y position
                        posXP = posX;
                        posYP = posY;

                        // bool areOverlapping = Raylib.CheckCollisionPointRec(mousePos, SD);
                        Raylib.ClearBackground(Color.LIGHTGRAY);
                        Raylib.DrawText("B - Back to menu", 5, 5, 20, Color.BLACK);
                        Raylib.DrawText("Q - Quit game", 5, 25, 20, Color.BLACK);
                        Raylib.EndDrawing();
                    }
                }
            }
        }
    }
}
