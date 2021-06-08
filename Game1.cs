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


        List<Texture2D> alienList;
        Texture2D shipImage;
        Texture2D alienImage;
        Vector2 shipPosition;



        int numberOfColumns = 5;
        int numberOfRows = 5;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            shipPosition = new Vector2(100, 150);
            alienList = new List<Texture2D>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            shipImage = Content.Load<Texture2D>("Ship");
            alienImage = Content.Load<Texture2D>("Alien");

            var tempTexture = Content.Load<Texture2D>("Alien");
            for(int i = 0; i < numberOfRows; i++)
            {
                for(int n = 0; n < numberOfColumns; n++)
                {
                    alienList.Add(tempTexture);
                }
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
            
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkOrchid);

            _spriteBatch.Begin();

            _spriteBatch.Draw(alienImage, Vector2.Zero, Color.Yellow);
            _spriteBatch.Draw(shipImage, shipPosition, Color.White);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
