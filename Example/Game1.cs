using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PrimitiveExpander;

namespace Example
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;

        private Effect _effect;

        private Vector3 _offset;

        public Game1()
        {
            Content.RootDirectory = "Content";

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _graphicsDeviceManager = new GraphicsDeviceManager(this);

            if (GraphicsDevice == null)
            {
                _graphicsDeviceManager.ApplyChanges();
            }

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            _effect = Content.Load<Effect>("VertexPC");


            PrimitiveRenderer.GraphicsDevice = GraphicsDevice;
            PrimitiveRenderer.Effect = _effect;
        }

        protected override void Update(GameTime gameTime)
        {
            if (!IsActive) return;

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var totalTime = (float)gameTime.TotalGameTime.TotalSeconds;

            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            var (w, h) = GraphicsDevice.Viewport.Bounds.Size;
            var (hw, hh) = GraphicsDevice.Viewport.Bounds.Size.ToVector2() / 2;

            var world = Matrix.Identity;
            var viewPosition = _offset + new Vector3(hw, hh, 0);
            var view = Matrix.CreateLookAt(viewPosition + Vector3.Backward, viewPosition + Vector3.Forward, Vector3.Up);
            var projection = Matrix.CreateOrthographic(w / 1, -h / 1, 0.1f, 10f);

            PrimitiveRenderer.World = world;
            PrimitiveRenderer.View = view;
            PrimitiveRenderer.Projection = projection;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var (x, y) = Mouse.GetState().Position;

            var a = new Vector3(x, y, 0);
            var b = new Vector3(x + 10, y, 0);
            var c = new Vector3(x, y + 10, 0);
            var d = new Vector3(x + 10, y + 10, 0);
            
            PrimitiveRenderer.DrawQuadF(
                Color.White,
                a, b, c, d
            );
        }
    }
}