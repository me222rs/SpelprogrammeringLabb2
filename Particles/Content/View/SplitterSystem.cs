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
        public static Vector2 GRAVITY = new Vector2(0, -2.3f);
        public static float MAX_LIFE = 1.0f;
        public static float DELAY_MAX = 1.0f;
        public static float MIN_SPEED = 0.1f;
        public static float MAX_SPEED = 0.3f;
        private static Random m_rand = new Random();
        private Camera camera;
        

        //State
        public float m_life = 0;
        public float m_delay;
        public Vector2 m_position;
        private Vector2 m_particleSpeed;
        private float time;

        private SplitterParticle[] particles;
        private float maxSpeed = 0.7f;

        Random rand;
        public SplitterSystem(Viewport viewPort)
        {
            rand = new Random();
            camera = new Camera(viewPort.Width, viewPort.Height);
            particles = new SplitterParticle[100];
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
       
            for (int i = 0; i < 100; i++)
            {
                particles[i].Draw(spriteBatch, texture, camera);
            }
        }

        public Vector2 GetRandomDirection() {
            Vector2 randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            //normalize to get it spherical vector with length 1.0
            randomDirection.Normalize();
            //add random length between 0 to maxSpeed
            randomDirection = randomDirection * ((float)rand.NextDouble() * maxSpeed);
            return randomDirection;
        }

        private void Respawn(Vector2 a_position, int a_randomSeed)
        {
            Random r = new Random(a_randomSeed);

            m_delay = (float)r.NextDouble() * DELAY_MAX;
            m_life = MAX_LIFE;
            m_position = a_position;
            m_particleSpeed = GetRandomSpeed(a_randomSeed);
        }


        /**
         * Partikeln ska ritas ut ifall den har m_life kvar  
         * 
         */
        public bool IsAlive()
        {
            return m_life > 0;
        }

        internal void Update(float elapsedTime)
        {
            time = elapsedTime;
            for (int i = 0; i < 100; i++)
            {
                particles[i].Update(elapsedTime);
            }

            //particles[i].Update(elapsedTime);
        }


        private Vector2 GetRandomSpeed(int a_randomSeed)
        {
            //skapa en random utifrån seed
            Random rand = new Random(a_randomSeed);

            //x och yield får värden mellan -1 och 1
            float x = (float)(rand.NextDouble() * 2.0 - 1.0);
            float y = (float)(rand.NextDouble() * 2.0 - 1.0);

            //skapa och normalisera en vektor
            Vector2 ret = new Vector2(x, y);
            ret.Normalize(); // Vektorn får längden 1.

            //slumpa hastighet mellan 0.1
            float speed = (float)rand.NextDouble();

            //hastighet mellan MIN_SPEED och MAX_SPEED
            ret = ret * (MIN_SPEED + speed * (MAX_SPEED - MIN_SPEED));

            return ret;
        }

        //minskar i synlighet och fadar ut
        public float GetVisibility()
        {
            return m_life / MAX_LIFE;
        }


    
    }
}
