using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace psi2
{
    class GameObject
    {
        Texture2D image;
        public Vector2 position;
        Color color;
        float speed = 50;


        public void LoadGameObject(Texture2D texture, Vector2 position, Color color)
        {
            image = texture;
            this.position = position;
            this.color = color;
        }

        public void Update(float deltaTime)
        {
            position.X += 50 * deltaTime;
        }
        public bool Update(float deltaTime, bool moveRight)
        {
            if(moveRight)
            {
                position.X += speed * deltaTime;
                if(position.X + image.Width > 800)
                {
                    return true;
                }
                return false;

            }
            else
            {
               position.X -= speed * deltaTime;
               if(position.X < 0)
                    return true;
               return false;
            }
        }
        public void StepDown()
        {
            position.Y += image.Height * 0.5f;
            speed += 10;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, color);
        }
    }
}