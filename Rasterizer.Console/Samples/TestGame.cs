using OpenTK.Graphics.OpenGL;
using Rasterizer.Core;
using Rasterizer.Library;
using Rasterizer.Library.Mathmatics;

namespace Rasterizer.Console.Samples
{
    public class TestGame : Game
    {
        private Color4 color = Color4.Black;
        private Random rnd = new Random();

        Mesh cube = new Mesh();
        private Matrix4x4 projectionMatrix;

        public TestGame(string windowName, int initialWindowHeight, int initialWindowWidth) : base(windowName, initialWindowHeight, initialWindowWidth)
        {
        }

        protected override void Initialize()
        {
            cube.triangles = new Triangle[12];
            cube.triangles[0].Points = [new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0)];
            cube.triangles[1].Points = [new Vector3(0, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0)];

            cube.triangles[2].Points = [new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 1, 1)];
            cube.triangles[3].Points = [new Vector3(1, 0, 0), new Vector3(1, 1, 1), new Vector3(1, 0, 1)];

            cube.triangles[4].Points = [new Vector3(1, 0, 1), new Vector3(1, 1, 1), new Vector3(0, 1, 1)];
            cube.triangles[5].Points = [new Vector3(1, 0, 1), new Vector3(0, 1, 1), new Vector3(0, 0, 1)];

            cube.triangles[6].Points = [new Vector3(0, 0, 1), new Vector3(0, 1, 1), new Vector3(0, 1, 0)];
            cube.triangles[7].Points = [new Vector3(0, 0, 1), new Vector3(0, 1, 0), new Vector3(0, 0, 0)];

            cube.triangles[8].Points = [new Vector3(0, 1, 0), new Vector3(0, 1, 1), new Vector3(1, 1, 1)];
            cube.triangles[9].Points = [new Vector3(0, 1, 0), new Vector3(1, 1, 1), new Vector3(1, 1, 0)];

            cube.triangles[10].Points = [new Vector3(1, 0, 1), new Vector3(0, 0, 1), new Vector3(0, 0, 0)];
            cube.triangles[11].Points = [new Vector3(1, 0, 1), new Vector3(0, 0, 0), new Vector3(1, 0, 0)];

            float near = 0.1f;
            float far = 1000f;
            float fov = 90f;
            float aspectRatio = 600 / 800;
            float fovRad = 1f / MathF.Tan(fov * 0.5f / 180 * MathF.PI);

            projectionMatrix.Matrix[0, 0] = aspectRatio * fovRad;
            projectionMatrix.Matrix[1, 1] = fovRad;
            projectionMatrix.Matrix[2, 2] = far / (far - near);
            projectionMatrix.Matrix[3, 2] = (-far * near) / (far - near);
            projectionMatrix.Matrix[2, 3] = 1f;
            projectionMatrix.Matrix[3, 3] = 0f;
        }

        protected override void LoadContent()
        {
            
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

            foreach (var tri in cube.triangles)
            {
                Triangle triProjected = new Triangle();
                Matrix4x4.MultiplyMatrixVector(tri.Points[0], out triProjected.Points[0], projectionMatrix);
                Matrix4x4.MultiplyMatrixVector(tri.Points[1], out triProjected.Points[1], projectionMatrix);
                Matrix4x4.MultiplyMatrixVector(tri.Points[2], out triProjected.Points[2], projectionMatrix);

            }
        }
    }
}
