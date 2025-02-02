
using Rasterizer.Library.Mathmatics;

namespace Rasterizer.Console
{
    internal class MovingPixelRasterizer : AbstractRasterizer
    {
        Random random = new Random();

        //Vector3 Direction = new Vector3(1f, 0f, 0f);

        Vector3[] DirectionArray;

        Vector3[] PositionArray;

        int Speed = 125;

        private int _numberOfPixels = 100;

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
            for(var i = 0; i < PositionArray.Length; i++)
            {
                DirectionArray[i].X = 1.0f;
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
                PositionArray[i] += DirectionArray[i] * ElapsedTime * Speed;

                if (PositionArray[i].X >= Width || PositionArray[i].X < 0)
                {
                    DirectionArray[i].X = -DirectionArray[i].X;
                    PositionArray[i].X = PositionArray[i].X < 0 ? 0 : Width - 1;
                    PositionArray[i].Y = random.Next(Height);
                }
            }
        }
    }
}
