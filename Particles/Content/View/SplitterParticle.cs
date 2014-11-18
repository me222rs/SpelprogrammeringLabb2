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
        private float radius;
        private Vector2 velocity;
        private Vector2 acceleration;
        

        public SplitterParticle(Vector2 position, Vector2 direction, float radius) {
            this.position = position;
            this.radius = radius;
            this.velocity = direction;
            acceleration = new Vector2(0, 1f);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D splitterTexture, Camera camera)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(splitterTexture, camera.Splitter(position.X, position.Y, radius), Color.White);
            spriteBatch.End();
        }
        public void Update(float timeElapsed)
        {
            
        }



    }
}
