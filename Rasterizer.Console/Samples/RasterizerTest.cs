using OpenTK.Graphics.OpenGL;
using Rasterizer.Core;
using Rasterizer.Library.Mathmatics;

namespace Rasterizer.Console.Samples
{
    public class Rasterizer : Game
    {
        Random random = new Random();

        //Vector3 Direction = new Vector3(1f, 0f, 0f);

        Vector3[] DirectionArray;

        Vector3[] PositionArray;

        int HorizontalSpeed = 125;

        int VerticalSpeed = 75;

        private int _numberOfPixels = 400;

        public Rasterizer(string windowName, int initialWindowHeight, int initialWindowWidth) : base(windowName, initialWindowHeight, initialWindowWidth)
        {
            DirectionArray = new Vector3[_numberOfPixels];
            PositionArray = new Vector3[_numberOfPixels];
        }

        public int NumberOfPixels
        {
            get { return _numberOfPixels; }
            set
            {
                _numberOfPixels = value;

                if (PositionArray.Length != _numberOfPixels)
                {
                    PositionArray = new Vector3[_numberOfPixels];
                }
            }
        }

        protected override void Initialize()
        {
            
        }

        protected override void LoadContent()
        {
            for (var i = 0; i < PositionArray.Length; i++)
            {
                DirectionArray[i].X = random.Next(0, 2) == 0 ? 1.0f : -1.0f;
                DirectionArray[i].Y = random.Next(0, 2) == 0 ? 1.0f : -1.0f;
                PositionArray[i].X = random.Next(800);
                PositionArray[i].Y = random.Next(600);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        protected override void Render(GameTime gameTime)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            for (var i = 0; i < PositionArray.Length; i++)
            {
            }
        }
    }
}
