using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoke.Content
{
    class SmokeParticle
    {
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 speed;
        private static float maxSpeed = 0.2f;

        private float timeLived = 0;
        private float size = 0;
        private float maxTimeToLive = 3.0f;
        private float lifePercent;
        private float minSize = 3f;
        private float maxSize = 8f;
        private float rotation = 0;


        public SmokeParticle()
        {
            speed = new Vector2(0, -0.4f);
            Respawn();
        }

        public void Update(float timeElapsed)
        {
            rotation += 0.01f;

            timeLived += timeElapsed;
            lifePercent = timeLived / maxTimeToLive;
            size = minSize + lifePercent * maxSize;

            Vector2 newPosition = new Vector2();
            Vector2 newVelocity = new Vector2();

            newVelocity.X = velocity.X + timeElapsed * speed.X;
            newVelocity.Y = velocity.Y + timeElapsed * speed.Y;

            newPosition.X = position.X + timeElapsed * velocity.X;
            newPosition.Y = position.Y + timeElapsed * velocity.Y;

            velocity = newVelocity;
            position = newPosition;
        }

        public void Respawn()
        {
            //Längst ner i mitten
            position = new Vector2(0.6f, 0.7f);

            Random rand = new Random();
            velocity = new Vector2(((float)rand.NextDouble() - 0.5f), ((float)rand.NextDouble() - 0.5f));
            velocity.Normalize();
            velocity = velocity * ((float)rand.NextDouble() * maxSpeed);
        }

        public bool Dead()
        {
            return timeLived >= maxTimeToLive;
        }


        public void Draw(SpriteBatch spriteBatch, Texture2D smokeTexture, Camera camera)
        {
            float t = timeLived / maxTimeToLive;
            if (t > 1.0f)
            {
                t = 1.0f;
            }

            float startValue = 1.0f;
            float endValue = 0.0f;

            float fade = endValue * t + (1.0f - t) * startValue;

            Color color = new Color(fade, fade, fade, fade);

            Vector2 origin = new Vector2(smokeTexture.Bounds.Width / 2, smokeTexture.Bounds.Height / 2);

            spriteBatch.Begin();
            spriteBatch.Draw(smokeTexture, camera.scaleSmokeVector(position.X, position.Y), new Rectangle(0, 0, smokeTexture.Bounds.Width, smokeTexture.Bounds.Height), color, rotation, origin, size, SpriteEffects.None, 0);
            spriteBatch.End();
        }



    }
}
