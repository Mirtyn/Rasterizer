using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Rasterizer.Library;
using Rasterizer.Library.Mathmatics;
using System;
using Vector2 = Rasterizer.Library.Mathmatics.Vector2;
using Vector3 = Rasterizer.Library.Mathmatics.Vector3;

namespace Rasterizer.Console.Rasterizers
{
    internal class TestRasterizer : AbstractRasterizer
    {
        private Color4 color = Color4.Black;
        private Random rnd = new Random();

        Mesh cube = new Mesh();
        private Matrix4x4 projectionMatrix;

        public override void Load()
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

        public override void Update()
        {
            System.Console.WriteLine("GameTime: " + TotalGameTime);
            System.Console.WriteLine("ElapsedTIme: " + ElapsedTime);

            color.R += (float)rnd.NextDouble() * ElapsedTime;
            color.G += (float)rnd.NextDouble() * ElapsedTime;
            color.B += (float)rnd.NextDouble() * ElapsedTime;

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

        public override void Render()
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
