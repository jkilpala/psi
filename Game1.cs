using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace psi2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        EnemyManager enemyManager;
        //List<Texture2D> alienList;
        //List<GameObject> aliensList;
        Texture2D shipImage;
        Texture2D alienImage;
        Vector2 shipPosition;

        // int numberOfColumns = 10;
        // int numberOfRows = 5;

        List<Bullet> bulletList;
        List<Bullet> bulletsToDestroy;
        Texture2D storedPewPewImage;
        bool hasShot = false;

        float shootDelay = 0.4f;
        float shootTimer = 0.0f;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            enemyManager = new EnemyManager();
            enemyManager.Initialize();
            // TODO: Add your initialization logic here
            shipPosition = new Vector2(100, 150);
            //alienList = new List<Texture2D>();
            //aliensList = new List<GameObject>();
            bulletList = new List<Bullet>();
            bulletsToDestroy = new List<Bullet>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            shipImage = Content.Load<Texture2D>("Ship");
            alienImage = Content.Load<Texture2D>("Alien");
            storedPewPewImage = Content.Load<Texture2D>("PewPew");
            enemyManager.LoadContent(Content);
            // var tempTexture = Content.Load<Texture2D>("Alien");
            // for(int i = 0; i < numberOfRows; i++)
            // {
            //     for(int n = 0; n < numberOfColumns; n++)
            //     {
            //         var tempGameObject = new GameObject();
            //         Color tempColor = Color.White;
            //         if(i == 0)
            //             tempColor = Color.Yellow;
            //         else if(i == 1)
            //             tempColor = Color.Red;
            //         else if(i == 2)
            //             tempColor = Color.HotPink;
            //         else if(i == 3)
            //             tempColor = Color.Green;
            //         else if(i == 4)
            //             tempColor = Color.Blue;
            //         else if(i == 5)
            //             tempColor = Color.BlueViolet;


            //         tempGameObject.LoadGameObject(tempTexture, new Vector2(n * 40, i * 40), tempColor);
            //         aliensList.Add(tempGameObject);
            //         //alienList.Add(tempTexture);
            //     }
            // }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            enemyManager.Update(gameTime);
            foreach(var bullet in bulletList)
            {
                bullet.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            // foreach(var alien in aliensList)
            // {
            //     alien.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            // }


            // TODO: Add your update logic here
            if(Keyboard.GetState().IsKeyDown(Keys.A))
            {
                shipPosition.X -= 100.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                shipPosition.X += 100.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.W))
            {
                shipPosition.Y -= 100.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.S))
            {
                shipPosition.Y += 100.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            
            // if(Keyboard.GetState().IsKeyDown(Keys.Space))
            // {
            //     //Shoot();
            //     hasShot = true;
            // }
            // if(Keyboard.GetState().IsKeyUp(Keys.Space))
            // {
            //     if(hasShot)
            //     {
            //         Shoot();
            //         hasShot = false;
            //     }
            //     //Shoot();
            // }
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                shootTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if(shootTimer <= 0.0f)
                {
                    Shoot();
                    shootTimer = shootDelay;
                }
            }
            if(Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                shootTimer = 0.0f;
            }

            foreach(var bullet in bulletList)
            {
                if(!bullet.IsAlive())
                {
                    bulletsToDestroy.Add(bullet);
                }
            }
            if(bulletsToDestroy.Count > 0)
            {
                foreach(var bullet in bulletsToDestroy)
                {
                    bulletList.Remove(bullet);
                }
                bulletsToDestroy.Clear();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkOrchid);

            _spriteBatch.Begin();
            enemyManager.Draw(_spriteBatch);

            foreach(var bullet in bulletList)
            {
                bullet.Draw(_spriteBatch);
            }
            // foreach(var alien in aliensList)
            // {
            //     alien.Draw(_spriteBatch);
            // }

            //_spriteBatch.Draw(alienImage, Vector2.Zero, Color.Yellow);
            _spriteBatch.Draw(shipImage, shipPosition, Color.White);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void Shoot()
        {
            bulletList.Add(new Bullet(storedPewPewImage, shipPosition));
        }
    }
}
