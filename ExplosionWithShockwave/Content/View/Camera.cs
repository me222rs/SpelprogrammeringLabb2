using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Particles.Content.View
{
    class Camera
    {
        //Höjd och bredd på ritytan

        private float scale;
        private static int borderIndent = 10;

        public Camera(int width, int heigth)
        {
            int scaleX = (width - borderIndent * 2);
            int scaleY = (heigth - borderIndent * 2);

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }


        public Rectangle Splitter(float x, float y, float radius)
        {
            int vSize = (int)(radius * scale);

            int vx = (int)(x * scale);
            int vy = (int)(y * scale);

            return new Rectangle(vx, vy, vSize, vSize);
        }

        public float Scale
        {
            get { return scale; }
        }

        public Vector2 scaleVector(float xPos, float yPos)
        {
            float X = (xPos * scale);
            float Y = (yPos * scale);

            return new Vector2(X, Y);
        }
    }
}

