using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Rasterizer.Core;
using Rasterizer.Library;

namespace Rasterizer.Console.Samples
{
    public class TestGame : Game
    {
        private Color4 color = Color4.Black;
        private Random rnd = new Random();

        Mesh cube = new Mesh();

        public TestGame(string windowName, int initialWindowHeight, int initialWindowWidth) : base(windowName, initialWindowHeight, initialWindowWidth)
        {
        }

        protected override void Initialize()
        {

        }

        protected override void LoadContent()
        {
         //   var 
         //   cube.triangles = {
         //       { }
	        //};
        }
        

        protected override void Update(GameTime gameTime)
        {
            System.Console.WriteLine("GameTime: " + gameTime.TotalGameTime.TotalSeconds);
            System.Console.WriteLine("ElapsedTIme: " + gameTime.ElapsedGameTime.Milliseconds);

            color.R += (float)rnd.NextDouble() / 300f;
            color.G += (float)rnd.NextDouble() / 300f;
            color.B += (float)rnd.NextDouble() / 300f;

            if (color.R > 1f)
            {
                color.R = 0f;
            }
            if (color.G > 1f)
            {
                color.G = 0f;
            }
            if (color.B > 1f)
            {
                color.B = 0f;
            }
        }

        protected override void Render(GameTime gameTime)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(color);
        }
    }
}
