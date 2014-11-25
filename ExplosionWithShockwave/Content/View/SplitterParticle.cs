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
        private static float radius = 0.02f;
        private Vector2 velocity;
        private Vector2 acceleration;
        private float rotation = 0;
        private float rotation2 = 0;
        private float size = 0;
        

        public SplitterParticle(Vector2 velocity, Vector2 position) {
            this.position = position;
            this.velocity = velocity;
            acceleration = new Vector2(0, 0);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D splitterTexture, Camera camera)
        {
            Vector2 origin = new Vector2(splitterTexture.Bounds.Width / 2, splitterTexture.Bounds.Height / 2);
            spriteBatch.Begin();
            spriteBatch.Draw(splitterTexture, camera.Splitter(position.X, position.Y, radius), new Rectangle(0, 0, splitterTexture.Bounds.Width, splitterTexture.Bounds.Height), Color.White, rotation, origin, SpriteEffects.None, 0);
            //spriteBatch.Draw(splitterTexture, camera.Splitter(position.X, position.Y, radius), new Rectangle(0, 0, splitterTexture.Bounds.Width, splitterTexture.Bounds.Height), Color.White, rotation2, origin, SpriteEffects.None, 0);
            //spriteBatch.Draw(splitterTexture, camera.Splitter(position.X, position.Y, radius), Color.White);
            spriteBatch.End();
        }
        public void Update(float timeElapsed)
        {
            rotation += 0.1f;

            //rotation2 -= 0.1f;
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
