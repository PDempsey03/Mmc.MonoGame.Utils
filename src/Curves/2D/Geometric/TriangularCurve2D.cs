using Microsoft.Xna.Framework;

namespace Mmc.MonoGame.Utils.Curves._2D.Geometric
{
    public class TriangularCurve2D : Curve2D
    {
        public override bool IsSmooth => false;

        public override Vector2 GetPoint(float t)
        {
            throw new NotImplementedException();
        }

        public override Vector2 GetTangent(float t)
        {
            throw new NotImplementedException();
        }
    }
}
