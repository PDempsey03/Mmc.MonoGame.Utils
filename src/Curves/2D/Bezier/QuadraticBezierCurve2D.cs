using Microsoft.Xna.Framework;

namespace Mmc.MonoGame.Utils.Curves._2D.Bezier
{
    public class QuadraticBezierCurve2D : Curve2D
    {
        public Vector2 P0 { get; set; }

        public Vector2 P1 { get; set; }

        public Vector2 P2 { get; set; }

        public QuadraticBezierCurve2D(Vector2 p0, Vector2 p1, Vector2 p2)
        {
            P0 = p0;
            P1 = p1;
            P2 = p2;
        }

        public override Vector2 GetPoint(float t)
        {
            Vector2 P0P1Lerp = Vector2.Lerp(P0, P1, t);
            Vector2 P1P2Lerp = Vector2.Lerp(P1, P2, t);

            Vector2 finalLerp = Vector2.Lerp(P0P1Lerp, P1P2Lerp, t);

            return finalLerp;
        }

        public override Vector2 GetTangent(float t)
        {
            Vector2 p0Comp = -2 * t * P0;
            Vector2 p1Comp = 2 * (1 - 2 * t) * P1;
            Vector2 p2Comp = 2 * t * P2;

            Vector2 total = p0Comp + p1Comp + p2Comp;

            return total;
        }
    }
}
