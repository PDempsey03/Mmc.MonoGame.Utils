using Microsoft.Xna.Framework;

namespace Mmc.MonoGame.Utils.Curves._2D.Polynomial
{
    public class LinearCurve2D : Curve2D
    {
        public Vector2 Start { get; set; }

        public Vector2 End { get; set; }

        public override bool IsSmooth => true;

        public LinearCurve2D(Vector2 start, Vector2 end)
        {
            Start = start;
            End = end;
        }

        public LinearCurve2D(float slope, float length, Vector2 middlePoint, bool leftSideIsStart = true)
        {
            Vector2 normalizedSlope = Vector2.Normalize(new Vector2(1, slope));
            float halfLength = length / 2;
            Vector2 scaledSlope = halfLength * normalizedSlope;

            Vector2 localStart = middlePoint - scaledSlope;
            Vector2 localEnd = middlePoint + scaledSlope;

            if (leftSideIsStart)
            {
                Start = localStart;
                End = localEnd;
            }
            else
            {
                Start = localEnd;
                End = localStart;
            }
        }

        public override Vector2 GetPoint(float t)
        {
            return Vector2.Lerp(Start, End, t);
        }

        public override Vector2 GetTangent(float t)
        {
            return End - Start;
        }
    }
}
