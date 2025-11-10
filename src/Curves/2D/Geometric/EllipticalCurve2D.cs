using Microsoft.Xna.Framework;

namespace Mmc.MonoGame.Utils.Curves._2D.Geometric
{
    public class EllipticalCurve2D : Curve2D
    {
        public Vector2 Center { get; set; }

        public Vector2 Radius { get; set; }

        public float StartingAngle { get; set; }

        public float EndingAngle { get; set; }

        public override bool IsSmooth => true;

        public EllipticalCurve2D(Vector2 center, Vector2 radius, float startingAngle, float endingAngle)
        {
            Center = center;
            Radius = radius;
            StartingAngle = startingAngle;
            EndingAngle = endingAngle;
        }

        public override Vector2 GetPoint(float t)
        {
            float targetAngle = MathHelper.Lerp(StartingAngle, EndingAngle, t);

            float xOffset = Radius.X * MathF.Cos(MathHelper.ToRadians(targetAngle));
            float yOffset = Radius.Y * MathF.Sin(MathHelper.ToRadians(targetAngle));

            return Center + new Vector2(xOffset, yOffset);
        }

        public override Vector2 GetTangent(float t)
        {
            float targetAngle = MathHelper.Lerp(StartingAngle, EndingAngle, t);

            float dx = MathF.Cos(MathHelper.ToRadians(targetAngle));
            float dy = MathF.Sin(MathHelper.ToRadians(targetAngle));

            return new Vector2(-dy, dx);
        }
    }
}
