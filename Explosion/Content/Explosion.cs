using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Explosion.Content
{
    class AnimateExplosion
    {
        Texture2D explosion;
        private Vector2 position;
        private float timeElapsed;
        private float maxTime = 0.9f;
        private int frameRate = 24;
        private int numberOfFrames = 4;
        private int size;


        public AnimateExplosion(Texture2D texture, Viewport viewPort)
        {
            explosion = texture;
            size = explosion.Bounds.Width / numberOfFrames;

            position = new Vector2((viewPort.Width - size) / 2, (viewPort.Height - size) / 2);
        }

        public void Draw(SpriteBatch spriteBatch, float elapsedTime)
        {

            if (timeElapsed >= maxTime)
            {
                timeElapsed = 0;
            }
            timeElapsed += elapsedTime;
            float percentAnimated = timeElapsed / maxTime;
            int frame = (int)(percentAnimated * frameRate);
            int frameX = frame % numberOfFrames;
            int frameY = frame / numberOfFrames;

            spriteBatch.Begin();
            spriteBatch.Draw(explosion, position, new Rectangle(frameX * size, frameY * size, size, size), Color.White);
            spriteBatch.End();
        }
    }
}
