using Microsoft.Xna.Framework;
using Mmc.MonoGame.Utils.Curves._2D;
using Mmc.MonoGame.Utils.Curves._2D.Polynomial;
using System.Reflection;

namespace Mmc.MonoGame.Utils.Tests;

[TestClass]
public class CurveTests
{
    [TestMethod]
    public void TestQuadraticCurve2D()
    {
        QuadraticCurve2D test = new QuadraticCurve2D(new Vector2(-10, 10), new Vector2(10, 10), Vector2.Zero, .5f);

        Curve2DVisualizationSettings settings = new Curve2DVisualizationSettings()
        {
            Curve = test,
            SamplePoints = 51,
            FileName = $"{MethodBase.GetCurrentMethod()?.Name ?? "ERROR"}.png"
        };

        Curve2DVisualizer.VisualizeCurve(settings);
    }

    [TestMethod]
    public void TestQuadraticCurve2DWithTangents()
    {
        QuadraticCurve2D test = new QuadraticCurve2D(new Vector2(-10, 10), new Vector2(10, 10), Vector2.Zero, .5f);

        Curve2DVisualizationSettings settings = new Curve2DVisualizationSettings()
        {
            Curve = test,
            SamplePoints = 51,
            FileName = $"{MethodBase.GetCurrentMethod()?.Name ?? "ERROR"}.png",
            ShowTangents = true
        };

        Curve2DVisualizer.VisualizeCurve(settings);
    }

    [TestMethod]
    public void TestQuadraticCurve2DWithNormals()
    {
        QuadraticCurve2D test = new QuadraticCurve2D(new Vector2(-10, 10), new Vector2(10, 10), Vector2.Zero, .5f);

        Curve2DVisualizationSettings settings = new Curve2DVisualizationSettings()
        {
            Curve = test,
            SamplePoints = 51,
            FileName = $"{MethodBase.GetCurrentMethod()?.Name ?? "ERROR"}.png",
            ShowNormals = true,
        };

        Curve2DVisualizer.VisualizeCurve(settings);
    }

    [TestMethod]
    public void TestQuadraticCurve2DWithNormalsAndTangents()
    {
        QuadraticCurve2D test = new QuadraticCurve2D(new Vector2(-10, 10), new Vector2(10, 10), Vector2.Zero, .5f);

        Curve2DVisualizationSettings settings = new Curve2DVisualizationSettings()
        {
            Curve = test,
            SamplePoints = 51,
            FileName = $"{MethodBase.GetCurrentMethod()?.Name ?? "ERROR"}.png",
            ShowTangents = true,
            ShowNormals = true
        };

        Curve2DVisualizer.VisualizeCurve(settings);
    }

    [TestMethod]
    public void TestLinearCurve2D()
    {
        LinearCurve2D test = new LinearCurve2D(Vector2.Zero, new Vector2(10, 10));

        Curve2DVisualizationSettings settings = new Curve2DVisualizationSettings()
        {
            Curve = test,
            SamplePoints = 11,
            FileName = $"{MethodBase.GetCurrentMethod()?.Name ?? "ERROR"}.png"
        };

        Curve2DVisualizer.VisualizeCurve(settings);
    }

    [TestMethod]
    public void TestLinearCurve2DWithNormals()
    {
        LinearCurve2D test = new LinearCurve2D(Vector2.Zero, new Vector2(10, 10));

        Curve2DVisualizationSettings settings = new Curve2DVisualizationSettings()
        {
            Curve = test,
            SamplePoints = 11,
            FileName = $"{MethodBase.GetCurrentMethod()?.Name ?? "ERROR"}.png",
            ShowNormals = true
        };

        Curve2DVisualizer.VisualizeCurve(settings);
    }

    [TestMethod]
    public void TestCircularCurve2D()
    {
        CircularCurve2D test = new CircularCurve2D(Vector2.Zero, 5, 0, 360);

        Curve2DVisualizationSettings settings = new Curve2DVisualizationSettings()
        {
            Curve = test,
            SamplePoints = 50,
            FileName = $"{MethodBase.GetCurrentMethod()?.Name ?? "ERROR"}.png",
        };

        Curve2DVisualizer.VisualizeCurve(settings);
    }

    [TestMethod]
    public void TestCircularCurve2DWithNormals()
    {
        CircularCurve2D test = new CircularCurve2D(Vector2.Zero, 5, 0, 360);

        Curve2DVisualizationSettings settings = new Curve2DVisualizationSettings()
        {
            Curve = test,
            SamplePoints = 50,
            FileName = $"{MethodBase.GetCurrentMethod()?.Name ?? "ERROR"}.png",
            ShowNormals = true,
        };

        Curve2DVisualizer.VisualizeCurve(settings);
    }
}
