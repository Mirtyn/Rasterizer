using Rasterizer.Library.Mathmatics;

namespace Rasterizer.Console.Rasterizers
{
    internal class MovingPixelRasterizer : AbstractRasterizer
    {
        Random random = new Random();

        //Vector3 Direction = new Vector3(1f, 0f, 0f);

        Vector3[] DirectionArray;

        Vector3[] PositionArray;

        int HorizontalSpeed = 125;

        int VerticalSpeed = 75;

        private int _numberOfPixels = 400;

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

        public MovingPixelRasterizer()
        {
            DirectionArray = new Vector3[_numberOfPixels];
            PositionArray = new Vector3[_numberOfPixels];
        }


        public override void Load()
        {
            for (var i = 0; i < PositionArray.Length; i++)
            {
                DirectionArray[i].X = random.Next(0, 2) == 0 ? 0.25f + random.NextSingle() * 0.75f : -0.25f - random.NextSingle() * 0.75f;
                DirectionArray[i].Y = random.Next(0, 2) == 0 ? 0.25f + random.NextSingle() * 0.75f : -0.25f - random.NextSingle() * 0.75f;
                PositionArray[i].X = random.Next(Width);
                PositionArray[i].Y = random.Next(Height);
            }
        }


        public override void Render()
        {
            Clear();

            for (var i = 0; i < PositionArray.Length; i++)
            {
                Pixel(PositionArray[i]);
            }
        }

        public override void Update()
        {
            for (var i = 0; i < PositionArray.Length; i++)
            {
                PositionArray[i].X += DirectionArray[i].X * ElapsedTime * HorizontalSpeed;
                PositionArray[i].Y += DirectionArray[i].Y * ElapsedTime * VerticalSpeed;

                if (PositionArray[i].X >= Width || PositionArray[i].X < 0)
                {
                    DirectionArray[i].X = PositionArray[i].X < 0 || PositionArray[i].X >= Width ? -DirectionArray[i].X : DirectionArray[i].X;
                    DirectionArray[i].Y = PositionArray[i].Y < 0 || PositionArray[i].Y >= Height ? -DirectionArray[i].Y : DirectionArray[i].Y;
                    PositionArray[i].X = PositionArray[i].X < 0 ? 0 : Width - 1;
                    PositionArray[i].Y = PositionArray[i].Y < 0 ? 0 : Height - 1;
                    PositionArray[i].Y = random.Next(Height);
                }
            }
        }
    }
}
