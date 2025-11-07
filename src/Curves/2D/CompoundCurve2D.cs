using Microsoft.Xna.Framework;

namespace Mmc.MonoGame.Utils.Curves._2D
{
    public class CompoundCurve2D : Curve2D
    {
        public List<Curve2D> Curves { get; private init; } = [];

        public CompoundCurve2D(params Curve2D[] curves)
        {
            Curves.AddRange(curves);
        }

        public override Vector2 GetPoint(float t)
        {
            if (Curves.Count == 0) return Vector2.Zero;

            (int curveIndex, float localT) = ConvertGlobalToLocalT(t);

            Curve2D targetCurve = Curves[curveIndex];

            return targetCurve.GetPoint(localT);
        }

        public override Vector2 GetTangent(float t)
        {
            if (Curves.Count == 0) return Vector2.Zero;

            (int curveIndex, float localT) = ConvertGlobalToLocalT(t);

            Curve2D targetCurve = Curves[curveIndex];

            return targetCurve.GetTangent(localT);
        }

        protected virtual (int curveIndex, float curveT) ConvertGlobalToLocalT(float t)
        {
            int curveIndex = Math.Clamp((int)(t * Curves.Count), 0, Curves.Count - 1);
            float localT = t * Curves.Count - curveIndex;

            return (curveIndex, localT);
        }
    }
}
