using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace psi2
{
    class Bullet
    {
        Texture2D image;
        Vector2 position;

        bool isAlive = true;


        public Bullet(Texture2D image, Vector2 position)
        {
            this.image = image;
            this.position = position;
        }

        public void Update(float deltaTime)
        {
            position.Y -= 100 * deltaTime;

            if(position.Y < 50)
                isAlive = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, Color.White);
        }

        public bool IsAlive()
        {
            return isAlive;
        }
    }
}