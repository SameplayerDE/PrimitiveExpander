using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrimitiveExpander
{
    public static class PrimitiveRenderer
    {
        public static GraphicsDevice GraphicsDevice;
        public static Effect Effect;
        public static Matrix World, View, Projection;
        
        public static bool EnableTexture;
        public static bool EnableVertexColor;
        public static Texture2D Texture;

        static PrimitiveRenderer()
        {
            EnableTexture = false;
            EnableTexture = true;
        }
        
        #region LineRenderer

        public static void DrawLine(
            Color color,
            Vector3 a, Vector3 b)
        {
            LineRenderer.DrawLine(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                a, b
            );
        }

        public static void DrawLine(
            Color color,
            Vector2 a, Vector2 b,
            float zLayer = 0f)
        {
            LineRenderer.DrawLine(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                a, b,
                zLayer
            );
        }

        #endregion

        #region QuadRenderer

        public static void DrawQuadF(
            Color color,
            Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            QuadRenderer.DrawQuadF(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                a, b, c, d
            );
        }

        public static void DrawQuadF(
            Color color,
            Vector2 position, Vector2 size,
            float zLayer = 0)
        {
            QuadRenderer.DrawQuadF(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                position, size,
                zLayer
            );
        }

        public static void DrawQuadF(
            Color color,
            Point position, Point size,
            float zLayer = 0)
        {
            QuadRenderer.DrawQuadF(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                position, size,
                zLayer
            );
        }

        public static void DrawQuadF(
            Color color,
            Rectangle rectangle,
            float zLayer = 0)
        {
            QuadRenderer.DrawQuadF(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                rectangle,
                zLayer
            );
        }

        public static void DrawQuadH(
            Color color,
            Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            QuadRenderer.DrawQuadH(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                a, b, c, d
            );
        }

        public static void DrawQuadH(
            Color color,
            Vector2 position, Vector2 size,
            float zLayer = 0)
        {
            QuadRenderer.DrawQuadH(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                position, size,
                zLayer
            );
        }

        public static void DrawQuadH(
            Color color,
            Point position, Point size,
            float zLayer = 0)
        {
            QuadRenderer.DrawQuadH(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                position, size,
                zLayer
            );
        }

        public static void DrawQuadH(
            Color color,
            Rectangle rectangle,
            float zLayer = 0)
        {
            QuadRenderer.DrawQuadH(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                rectangle,
                zLayer
            );
        }

        #endregion

        #region TriangleRenderer

        public static void DrawTriangleF(
            Color color,
            Vector3 a, Vector3 b, Vector3 c)
        {
            TriangleRenderer.DrawTriangleF(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                a, b, c
            );
        }

        public static void DrawTriangleF(
            Color color,
            Vector2 a, Vector2 b, Vector2 c,
            float zLayer = 0)
        {
            TriangleRenderer.DrawTriangleF(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                a, b, c,
                zLayer
            );
        }

        public static void DrawTriangleF(
            Color color,
            Point a, Point b, Point c,
            float zLayer = 0)
        {
            TriangleRenderer.DrawTriangleF(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                a, b, c,
                zLayer
            );
        }

        public static void DrawTriangleH(
            Color color,
            Vector3 a, Vector3 b, Vector3 c)
        {
            TriangleRenderer.DrawTriangleH(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                a, b, c
            );
        }

        public static void DrawTriangleH(
            Color color,
            Vector2 a, Vector2 b, Vector2 c,
            float zLayer = 0)
        {
            TriangleRenderer.DrawTriangleH(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                a, b, c,
                zLayer
            );
        }

        public static void DrawTriangleH(
            Color color,
            Point a, Point b, Point c,
            float zLayer = 0)
        {
            TriangleRenderer.DrawTriangleH(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                a, b, c,
                zLayer
            );
        }

        #endregion

        #region CircleRenderer

        public static void DrawCircleF(
            Color color,
            Vector2 center,
            float radius,
            int resolution = 3,
            float zLayer = 0f)
        {
            CircleRender.DrawCircleF(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                center,
                radius,
                resolution,
                zLayer
            );
        }
        
        public static void DrawCircleH(
            Color color,
            Vector2 center,
            float radius,
            int resolution = 3,
            float zLayer = 0f)
        {
            CircleRender.DrawCircleH(
                GraphicsDevice,
                Effect,
                World, View, Projection,
                color,
                center,
                radius,
                resolution,
                zLayer
            );
        }

        #endregion
    }
}