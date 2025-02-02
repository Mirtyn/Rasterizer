using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Rasterizer.Console
{
    public class Window : GameWindow
    {
        private struct PixelEntry
        {
            public int X;
            public int Y;
            public float R;
            public float G;
            public float B;

            public PixelEntry()
            {
                X = 0; 
                Y = 0; 
                R = 1f; 
                G = 1f; 
                B = 1f;
            }
        }

        private Matrix4 ProjectionMatrix;
        private PixelEntry[] PixelEntryArray;
        private int PixelEntryArrayIndex = 0;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            PixelEntryArray = new PixelEntry[(int)(Size.X * Size.Y)];
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            //Console.WriteLine(GL.GetString(StringName.Vendor));
            //Console.WriteLine(GL.GetString(StringName.Renderer));
            //Console.WriteLine(GL.GetString(StringName.Version));
            //Console.WriteLine(GL.GetString(StringName.ShadingLanguageVersion));

            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.CullFace);
            GL.Disable(EnableCap.Blend);

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            this.VSync = VSyncMode.On;

            Clear();

            SwapBuffers();

            Clear();
        }

        protected override void OnUnload()
        {
            base.OnUnload();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            ProjectionMatrix = Matrix4.CreateOrthographicOffCenter(0, Size.X, 0, -Size.Y, 0.1f, 1000f);

            GL.Viewport(0, 0, Size.X, Size.Y);

            int pixelArrayLength = (int)(Size.X * Size.Y);

            if(pixelArrayLength != PixelEntryArray.Length)
            {
                PixelEntryArray = new PixelEntry[pixelArrayLength];
                PixelEntryArrayIndex = 0;

                for(var i = 0; i < pixelArrayLength; i++)
                {
                    PixelEntryArray[0] = new PixelEntry();
                }
            }
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            if (KeyboardState.IsKeyDown(Keys.C))
            {
                Clear();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref ProjectionMatrix);

            GL.PointSize(1);
            GL.Begin(PrimitiveType.Points);

            for (int i = 0; i < PixelEntryArrayIndex; i++)
            {
                var p = PixelEntryArray[i];

                GL.Color3(p.R, p.G, p.B);
                GL.Vertex3(p.X, p.Y - Size.Y + 1, -10.0f);
            }

            PixelEntryArrayIndex = 0;

            GL.End();

            SwapBuffers();
        }

        public void Clear()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void Pixel(int x, int y, float r = 1f, float g = 1f, float b = 1f)
        {
            PixelEntryArray[PixelEntryArrayIndex].X = x;
            PixelEntryArray[PixelEntryArrayIndex].Y = y;
            PixelEntryArray[PixelEntryArrayIndex].R = r;
            PixelEntryArray[PixelEntryArrayIndex].G = g;
            PixelEntryArray[PixelEntryArrayIndex].B = b;

            PixelEntryArrayIndex++;
        }
    }
}
