using Microsoft.Xna.Framework;

namespace Mmc.MonoGame.Utils.Curves._2D
{
    public abstract class Curve2D
    {
        public abstract Vector2 GetPoint(float t);

        public abstract Vector2 GetTangent(float t);

        public virtual Vector2 GetNormal(float t, bool clockwise = true)
        {
            Vector2 tangent = GetTangent(t);

            if (tangent == Vector2.Zero) return Vector2.Zero;

            tangent.Normalize();

            return clockwise
                ? new Vector2(tangent.Y, -tangent.X)
                : new Vector2(-tangent.Y, tangent.X);
        }

        public virtual float GetLength(int samples = 25)
        {
            float length = 0;

            Vector2 prev = GetPoint(0);
            for (int i = 1; i < samples; i++)
            {
                float t = i / samples;
                Vector2 curr = GetPoint(t);
                length += Vector2.Distance(prev, curr);
                prev = curr;
            }

            return length;
        }

        public virtual Vector2[] GetPoints(int numPoints)
        {
            Vector2[] points = new Vector2[numPoints];

            for (int i = 0; i < numPoints; i++)
            {
                float t = i / (numPoints - 1f);
                points[i] = GetPoint(t);
            }

            return points;
        }
    }
}
