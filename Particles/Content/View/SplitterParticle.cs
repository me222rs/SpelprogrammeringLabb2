using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Particles.Content.View
{
    class SplitterParticle
    {
        private Vector2 position;
        private static float radius = 0.03f;
        private Vector2 velocity;
        private Vector2 acceleration;
        

        public SplitterParticle(Vector2 velocity) {
            position = new Vector2(0.5f, 0.4f);
            this.velocity = velocity;
            acceleration = new Vector2(0, 2f);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D splitterTexture, Camera camera)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(splitterTexture, camera.Splitter(position.X, position.Y, radius), Color.White);
            spriteBatch.End();
        }
        public void Update(float timeElapsed)
        {
            Vector2 newPosition = new Vector2();
            Vector2 newVelocity = new Vector2();

            newVelocity.X = velocity.X + timeElapsed * acceleration.X;
            newVelocity.Y = velocity.Y + timeElapsed * acceleration.Y;

            newPosition.X = position.X + timeElapsed * velocity.X;
            newPosition.Y = position.Y + timeElapsed * velocity.Y;

            velocity = newVelocity;
            position = newPosition;
        }



    }
}
