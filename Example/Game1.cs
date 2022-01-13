using System;
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

        private Vector2 _clicked;
        private bool _animate;
        private float _process;

        public Game1()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _graphicsDeviceManager = new GraphicsDeviceManager(this);

            if (GraphicsDevice == null)
            {
                _graphicsDeviceManager.ApplyChanges();
            }

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            PrimitiveRenderer.Initialise(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (!IsActive) return;

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var totalTime = (float)gameTime.TotalGameTime.TotalSeconds;

            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            
            if (mouseState.LeftButton == ButtonState.Pressed && !_animate)
            {
                _clicked = mouseState.Position.ToVector2();
                _animate = true;
            }

            if (_animate)
            {
                if (_process >= 1)
                {
                    _process = 0;
                    _animate = false;
                }
                else
                {
                    _process += 1f * deltaTime; 
                }
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

            var (x, y) = _clicked;

            if (_animate)
            {
                
                PrimitiveRenderer.DrawCircleF(
                    null,
                    Color.Black,
                    new Vector2(x, y),
                    (float)Math.Sin(_process) * 60f,
                    5
                );
                PrimitiveRenderer.DrawCircleF(
                    null,
                    Color.White,
                    new Vector2(x, y),
                    (float)Math.Sin(_process) * 50f,
                    5
                );
            }
        }
    }
}