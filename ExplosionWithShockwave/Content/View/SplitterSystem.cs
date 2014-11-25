using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Particles.Content.View
{
    class SplitterSystem
    {
        
        private Camera camera;

        private SplitterParticle[] particleArray;
        private int numberOfParticles = 100;
        private float time = 0;
        private static float timeBetweenSplitter = 2;
        private static float speed = 0.3f;
        private Vector2 position;


        //State
        public float m_life = 0;

        private void Respawn()
        {
            Random rand = new Random();

            for (int i = 0; i < numberOfParticles; i++)
            {
                Vector2 direction = new Vector2(((float)rand.NextDouble() - 0.5f), (float)rand.NextDouble() - 0.5f);
                direction.Normalize();
                direction = direction * ((float)rand.NextDouble() * speed);

                particleArray[i] = new SplitterParticle(direction, position);
            }
        }

        public SplitterSystem(Viewport viewPort, Vector2 position)
        {
            this.position = position;
            camera = new Camera(viewPort.Width, viewPort.Height);

            particleArray = new SplitterParticle[numberOfParticles];

            Respawn();
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
       
            for (int i = 0; i < 100; i++)
            {
                particleArray[i].Draw(spriteBatch, texture, camera);
            }
        }


        internal void Update(float elapsedTime)
        {
            time += elapsedTime;

            for (int i = 0; i < numberOfParticles; i++)
            {
                particleArray[i].Update(elapsedTime);
            }

            if (time > timeBetweenSplitter)
            {
                time = 0;
                Respawn();
            }
        }





    
    }
}
