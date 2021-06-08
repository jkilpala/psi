using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace psi2
{
    class GameObject
    {
        Texture2D image;
        Vector2 position;
        Color color;


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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, color);
        }
    }
}