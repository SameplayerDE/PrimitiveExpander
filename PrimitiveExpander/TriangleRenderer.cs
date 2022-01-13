using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrimitiveExpander
{
    public static class TriangleRenderer
    {
        private static readonly VertexPositionColorTexture[] _vertices;
        private static readonly int[] _indices;

        static TriangleRenderer()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _vertices = new VertexPositionColorTexture[3];
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _indices = new[]
            {
                0, 1,
                1, 2,
                2, 0
            };
        }

        public static void DrawTriangleF(
            GraphicsDevice graphicsDevice,
            BasicEffect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector3 a, Vector3 b, Vector3 c)
        {
            _vertices[0].Position = a;
            _vertices[0].Color = color;

            _vertices[1].Position = b;
            _vertices[1].Color = color;

            _vertices[2].Position = c;
            _vertices[2].Color = color;

            effect.World = world;
            effect.View = view;
            effect.Projection = projection;

            effect.VertexColorEnabled = true;

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, _vertices, 0, 1);
            }
        }
        
        public static void DrawTriangleF(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector3 a, Vector3 b, Vector3 c)
        {
            _vertices[0].Position = a;
            _vertices[0].Color = color;

            _vertices[1].Position = b;
            _vertices[1].Color = color;

            _vertices[2].Position = c;
            _vertices[2].Color = color;

            effect.Parameters["WorldViewProjection"]
                ?.SetValue(world * view * projection);

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, _vertices, 0, 1);
            }
        }

        public static void DrawTriangleF(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector2 a, Vector2 b, Vector2 c,
            float zLayer = 0)
        {
            var a3 = new Vector3(a, zLayer);
            var b3 = new Vector3(b, zLayer);
            var c3 = new Vector3(c, zLayer);

            DrawTriangleF(
                graphicsDevice,
                effect,
                world, view, projection,
                color,
                a3, b3, c3
            );
        }

        public static void DrawTriangleF(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Point a, Point b, Point c,
            float zLayer = 0)
        {
            DrawTriangleF(
                graphicsDevice,
                effect,
                world, view, projection,
                color,
                a.ToVector2(), b.ToVector2(), c.ToVector2(),
                zLayer
            );
        }

        public static void DrawTriangleH(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector3 a, Vector3 b, Vector3 c)
        {
            _vertices[0].Position = a;
            _vertices[0].Color = color;

            _vertices[1].Position = b;
            _vertices[1].Color = color;

            _vertices[2].Position = c;
            _vertices[2].Color = color;

            effect.Parameters["WorldViewProjection"]
                ?.SetValue(world * view * projection);

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawUserIndexedPrimitives(
                    PrimitiveType.LineList,
                    _vertices, 0, 3,
                    _indices, 0,
                    3
                );
            }
        }

        public static void DrawTriangleH(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector2 a, Vector2 b, Vector2 c,
            float zLayer = 0)
        {
            var a3 = new Vector3(a, zLayer);
            var b3 = new Vector3(b, zLayer);
            var c3 = new Vector3(c, zLayer);

            DrawTriangleH(
                graphicsDevice,
                effect,
                world, view, projection,
                color,
                a3, b3, c3
            );
        }

        public static void DrawTriangleH(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Point a, Point b, Point c,
            float zLayer = 0)
        {
            DrawTriangleH(
                graphicsDevice,
                effect,
                world, view, projection,
                color,
                a.ToVector2(), b.ToVector2(), c.ToVector2(),
                zLayer
            );
        }
    }
}