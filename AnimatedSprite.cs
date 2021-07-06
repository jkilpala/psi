using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace psi2
{
    class AnimatedSprite
    {
        Texture2D spriteSheet;
        Vector2 position;
        int tileWidth;
        int tileHeight;
        float durationOfAnimation;
        int numberOfFrames;
        bool loop;
        int currentFrame = 0;
        float frameLenght;
        float frameTimer = 0;

        public AnimatedSprite(Texture2D sheet, Vector2 pos, int tWidth, int tHeight, float animationLenght, int frames, bool loop)
        {
            spriteSheet = sheet;
            position = pos;
            tileHeight = tHeight;
            tileWidth = tWidth;
            durationOfAnimation = animationLenght;
            numberOfFrames = frames;
            this.loop = loop;

            frameLenght = animationLenght / numberOfFrames;
        }
        public bool Update(float deltaTime)
        {
            frameTimer += deltaTime;
            if(frameTimer >= frameLenght)
            {
                currentFrame += 1;
                if(currentFrame > numberOfFrames-1)
                {
                    if(loop)
                    {
                        currentFrame = 0;
                    }
                    else
                    {
                        currentFrame = numberOfFrames -1;
                        return true;
                    }                    
                }
                frameTimer = 0;
            }
            return false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, position, new Rectangle(currentFrame*tileWidth, 0,tileWidth, tileHeight), Color.White);
        }

    }
}