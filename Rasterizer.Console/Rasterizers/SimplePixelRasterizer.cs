namespace Rasterizer.Console.Rasterizers
{
    internal class SimplePixelRasterizer : AbstractRasterizer
    {
        Random random = new Random();

        public override void Load()
        {

        }

        public override void Render()
        {
            Clear();

            for (var i = 0; i < 100; i++)
            {
                Pixel(random.Next(0, Width), random.Next(0, Height));
            }
        }

        public override void Update()
        {

        }
    }
}
