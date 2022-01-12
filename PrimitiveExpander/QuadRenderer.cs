using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrimitiveExpander
{
    public static class QuadRenderer
    {
        private static readonly VertexPositionColor[] _vertices;
        private static readonly int[] _indicesF;
        private static readonly int[] _indicesH;

        static QuadRenderer()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _vertices = new VertexPositionColor[4];
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _indicesF = new[]
            {
                0, 1, 2,
                2, 1, 3
            };
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _indicesH = new[]
            {
                0, 1,
                1, 3,
                3, 2,
                2, 0
            };
        }

        public static void DrawQuadF(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            _vertices[0].Position = a;
            _vertices[0].Color = color;

            _vertices[1].Position = b;
            _vertices[1].Color = color;

            _vertices[2].Position = c;
            _vertices[2].Color = color;

            _vertices[3].Position = d;
            _vertices[3].Color = color;

            effect.Parameters["WorldViewProjection"]
                ?.SetValue(world * view * projection);

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphicsDevice.DrawUserIndexedPrimitives(
                    PrimitiveType.TriangleList,
                    _vertices, 0, 4,
                    _indicesF, 0,
                    2
                );
            }
        }

        public static void DrawQuadF(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector2 position, Vector2 size,
            float zLayer = 0f)
        {
            var (x, y) = position;
            var (width, height) = size;

            var a = new Vector3(x, y, zLayer);
            var b = new Vector3(x + width, y, zLayer);
            var c = new Vector3(x, y + height, zLayer);
            var d = new Vector3(x + width, y + height, zLayer);

            DrawQuadF(
                graphicsDevice,
                effect,
                world, view, projection,
                color,
                a, b, c, d);
        }

        public static void DrawQuadF(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Point position, Point size,
            float zLayer = 0f)
        {
            size += position;

            DrawQuadF(
                graphicsDevice,
                effect,
                world, view, projection,
                color,
                position.ToVector2(), size.ToVector2(),
                zLayer
            );
        }

        public static void DrawQuadF(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Rectangle rectangle,
            float zLayer = 0f)
        {
            var position = rectangle.Location;
            var size = rectangle.Size;

            DrawQuadF(
                graphicsDevice,
                effect,
                world, view, projection,
                color,
                position.ToVector2(), size.ToVector2(),
                zLayer
            );
        }

        public static void DrawQuadH(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            _vertices[0].Position = a;
            _vertices[0].Color = color;

            _vertices[1].Position = b;
            _vertices[1].Color = color;

            _vertices[2].Position = c;
            _vertices[2].Color = color;

            _vertices[3].Position = d;
            _vertices[3].Color = color;

            effect.Parameters["WorldViewProjection"]
                ?.SetValue(world * view * projection);

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphicsDevice.DrawUserIndexedPrimitives(
                    PrimitiveType.LineList,
                    _vertices, 0, 4,
                    _indicesH, 0,
                    4
                );
            }
        }

        public static void DrawQuadH(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector2 a, Vector2 b, Vector2 c, Vector2 d,
            float zLayer = 0)
        {
            var a3 = new Vector3(a, zLayer);
            var b3 = new Vector3(b, zLayer);
            var c3 = new Vector3(c, zLayer);
            var d3 = new Vector3(d, zLayer);

            DrawQuadH(
                graphicsDevice,
                effect,
                world, view, projection,
                color,
                a3, b3, c3, d3
            );
        }

        public static void DrawQuadH(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector2 position, Vector2 size,
            float zLayer = 0)
        {
            var (x, y) = position;
            var (width, height) = size;

            var a = new Vector3(x, y, zLayer);
            var b = new Vector3(x + width, y, zLayer);
            var c = new Vector3(x, y + height, zLayer);
            var d = new Vector3(x + width, y + height, zLayer);

            DrawQuadH(
                graphicsDevice,
                effect,
                world, view, projection,
                color,
                a, b, c, d);
        }

        public static void DrawQuadH(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Point position, Point size,
            float zLayer = 0)
        {
            size += position;

            DrawQuadH(
                graphicsDevice,
                effect,
                world, view, projection,
                color,
                position.ToVector2(), size.ToVector2());
        }

        public static void DrawQuadH(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Rectangle rectangle,
            float zLayer = 0)
        {
            var position = rectangle.Location;
            var size = rectangle.Size;

            DrawQuadH(
                graphicsDevice,
                effect,
                world, view, projection,
                color,
                position.ToVector2(), size.ToVector2(),
                zLayer
            );
        }
    }
}