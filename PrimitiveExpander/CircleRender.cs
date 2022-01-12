using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrimitiveExpander
{
    public class CircleRender
    {

        public static void DrawCircleF()
        {
        }

        public static void DrawCircleF(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector2 center,
            float radius,
            int resolution = 3,
            float zLayer = 0)
        {
            var last = Vector2.UnitX * radius;
            var lastP = Perpendicular(last);

            for (var i = 1; i <= resolution; i++)
            {
                var at = AngleToVector(i * MathHelper.PiOver2 / resolution, radius);
                var atP = Perpendicular(at);


                TriangleRenderer.DrawTriangleF(
                    graphicsDevice,
                    effect,
                    world, view, projection,
                    color,
                    new Vector3(center + last, zLayer), new Vector3(center + at, zLayer), new Vector3(center, zLayer)
                );
                TriangleRenderer.DrawTriangleF(
                    graphicsDevice,
                    effect,
                    world, view, projection,
                    color,
                    new Vector3(center - last, zLayer), new Vector3(center - at, zLayer), new Vector3(center, zLayer)
                );
                TriangleRenderer.DrawTriangleF(
                    graphicsDevice,
                    effect,
                    world, view, projection,
                    color,
                    new Vector3(center + lastP, zLayer), new Vector3(center + atP, zLayer), new Vector3(center, zLayer)
                );
                TriangleRenderer.DrawTriangleF(
                    graphicsDevice,
                    effect,
                    world, view, projection,
                    color,
                    new Vector3(center - lastP, zLayer), new Vector3(center - atP, zLayer), new Vector3(center, zLayer)
                );

                last = at;
                lastP = atP;
            }
        }

        public static void DrawCircleH(
            GraphicsDevice graphicsDevice,
            Effect effect,
            Matrix world, Matrix view, Matrix projection,
            Color color,
            Vector2 center,
            float radius,
            int resolution = 3,
            float zLayer = 0f)
        {
            var last = Vector2.UnitX * radius;
            var lastP = Perpendicular(last);

            for (var i = 1; i <= resolution; i++)
            {
                var at = AngleToVector(i * MathHelper.PiOver2 / resolution, radius);
                var atP = Perpendicular(at);


                LineRenderer.DrawLine(
                    graphicsDevice,
                    effect,
                    world, view, projection,
                    color,
                    new Vector3(center + last, zLayer), new Vector3(center + at, zLayer)
                );
                LineRenderer.DrawLine(
                    graphicsDevice,
                    effect,
                    world, view, projection,
                    color,
                    new Vector3(center - last, zLayer), new Vector3(center - at, zLayer)
                );
                LineRenderer.DrawLine(
                    graphicsDevice,
                    effect,
                    world, view, projection,
                    color,
                    new Vector3(center + lastP, zLayer), new Vector3(center + atP, zLayer)
                );
                LineRenderer.DrawLine(
                    graphicsDevice,
                    effect,
                    world, view, projection,
                    color,
                    new Vector3(center - lastP, zLayer), new Vector3(center - atP, zLayer)
                );

                last = at;
                lastP = atP;
            }
        }

        private static Vector2 Perpendicular(Vector2 vector)
        {
            var (x, y) = vector;
            return new Vector2(-y, x);
        }

        private static Vector2 AngleToVector(float angleRadians, float length)
        {
            return new Vector2((float)Math.Cos(angleRadians) * length, (float)Math.Sin(angleRadians) * length);
        }
    }
}