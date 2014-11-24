using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoke.Content
{
    class Camera
    {
        private float scale;
        private static int border = 10;

        public Camera(int width, int heigth)
        {
            int scaleX = (width - border * 2);
            int scaleY = (heigth - border * 2);

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        public Rectangle Scale(float xPosition, float yPosition, float radius)
        {
            int vSize = (int)(radius * scale);

            Vector2 smokeVector = scaleSmokeVector(xPosition, yPosition);

            return new Rectangle((int)smokeVector.X, (int)smokeVector.Y, vSize, vSize);
        }

        public Vector2 scaleSmokeVector(float xPos, float yPos)
        {
            int vX = (int)(xPos * scale + border);
            int vY = (int)(yPos * scale + border);

            return new Vector2(vX, vY);
        }

        public float getScale
        {
            get { return scale; }
        }
    }
}
