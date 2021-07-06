using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace psi2
{
    class EnemyManager
    {
        List<GameObject> aliensList;
        List<GameObject> aliensToDestroyList;
        int numberOfColumns = 10;
        int numberOfRows = 5;

        bool movingRight = true;
        bool changeDirection = false;

        public void Initialize()
        {
            aliensList = new List<GameObject>();
            aliensToDestroyList = new List<GameObject>();
        }

        public void LoadContent(ContentManager content)
        {
            var tempTexture = content.Load<Texture2D>("Alien");
            for(int i = 0; i < numberOfRows; i++)
            {
                for(int n = 0; n < numberOfColumns; n++)
                {
                    var tempGameObject = new GameObject();
                    Color tempColor = Color.White;
                    if(i == 0)
                        tempColor = Color.Yellow;
                    else if(i == 1)
                        tempColor = Color.Red;
                    else if(i == 2)
                        tempColor = Color.HotPink;
                    else if(i == 3)
                        tempColor = Color.Green;
                    else if(i == 4)
                        tempColor = Color.Blue;
                    else if(i == 5)
                        tempColor = Color.BlueViolet;


                    tempGameObject.LoadGameObject(tempTexture, new Vector2(n * 40, i * 40), tempColor);
                    aliensList.Add(tempGameObject);
                    //alienList.Add(tempTexture);
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            if(changeDirection)
            {
                changeDirection = false;
                movingRight = !movingRight;

                foreach(var alien in aliensList)
                {
                    alien.StepDown();
                }
            }
            foreach(var alien in aliensList)
            {
                bool change = alien.Update((float)gameTime.ElapsedGameTime.TotalSeconds, movingRight);
                if(change)
                {
                    changeDirection = true;
                }
            }

            if(aliensToDestroyList.Count > 0)
            {
                foreach(var alien in aliensToDestroyList)
                {
                    aliensList.Remove(alien);
                }
                aliensToDestroyList.Clear();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var alien in aliensList)
            {
                alien.Draw(spriteBatch);
            }
        }

        public bool checkCollision(Vector2 pos, float distance)
        {
            foreach(var alien in aliensList)
            {
                if(Vector2.Distance(alien.position, pos) < distance)
                {
                    aliensToDestroyList.Add(alien);
                    return true;
                }
            }
            return false;
        }

    }
}