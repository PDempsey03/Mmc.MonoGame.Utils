using Microsoft.Xna.Framework;
using Mmc.MonoGame.Utils.Curves._2D.Polynomial;

namespace Mmc.MonoGame.Utils.Curves._2D.Geometric
{
    public class TriangularCurve2D : CompoundCurve2D
    {
        private Vector2 _vertex1;
        private Vector2 _vertex2;
        private Vector2 _vertex3;

        public override bool IsSmooth => false;

        public Vector2 Vertex1
        {
            get => _vertex1;
            set
            {
                _vertex1 = value;
                RebuildTriangularCurve();
            }
        }

        public Vector2 Vertex2
        {
            get => _vertex2;
            set
            {
                _vertex2 = value;
                RebuildTriangularCurve();
            }
        }

        public Vector2 Vertex3
        {
            get => _vertex3;
            set
            {
                _vertex3 = value;
                RebuildTriangularCurve();
            }
        }

        public TriangularCurve2D(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3)
        {
            _vertex1 = vertex1;
            _vertex2 = vertex2;
            _vertex3 = vertex3;
            RebuildTriangularCurve();
        }

        protected virtual void RebuildTriangularCurve()
        {
            Curves.Clear();
            Curves.Add(new LinearCurve2D(Vertex1, Vertex2));
            Curves.Add(new LinearCurve2D(Vertex2, Vertex3));
            Curves.Add(new LinearCurve2D(Vertex3, Vertex1));
        }
    }
}
