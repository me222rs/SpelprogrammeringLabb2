using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoke.Content
{
    class SmokeSystem
    {
        
        Camera camera;
        private List<SmokeParticle> smoke = new List<SmokeParticle>();
        private float time = 0;
        private static float delay = 0.3f;


        public SmokeSystem(Viewport viewPort)
        {
            // TODO: Complete member initialization
            camera = new Camera(viewPort.Width, viewPort.Height);
        }


        internal void Draw(SpriteBatch spriteBatch, Texture2D smokeTexture)
        {
            for (int i = 0; i < smoke.Count; i++)
            {
                smoke[i].Draw(spriteBatch, smokeTexture, camera);
            }
        }

        public void Update(float timeElapsed)
        {
            time += timeElapsed;

            if (time >= delay)
            {
                time = 0;

                smoke.Add(new SmokeParticle());
            }

            for (int i = 0; i < smoke.Count; i++)
            {
                smoke[i].Update(timeElapsed);

                if (smoke[i].Dead())
                {
                    smoke[i].Respawn();
                }
            }
        }

    }
}
