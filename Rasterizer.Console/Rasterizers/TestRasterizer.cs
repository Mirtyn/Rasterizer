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
        private Color4 bgColor = Color4.Black;
        private Color4 fgColor = Color4.White;
        private Random rnd = new Random();

        Mesh cube = new Mesh();
        private Matrix4x4 projectionMatrix = new Matrix4x4(Matrix4x4.Identity);
        private Matrix4x4 RotationZMatrix = new Matrix4x4(Matrix4x4.Identity);
        private Matrix4x4 RotationXMatrix = new Matrix4x4(Matrix4x4.Identity);

        float fTheta;

        public override void Load()
        {
            //cube.triangles = new Triangle[12];
            //cube.triangles[0].Points = [new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0)];
            //cube.triangles[1].Points = [new Vector3(0, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0)];

            //cube.triangles[2].Points = [new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 1, 1)];
            //cube.triangles[3].Points = [new Vector3(1, 0, 0), new Vector3(1, 1, 1), new Vector3(1, 0, 1)];

            //cube.triangles[4].Points = [new Vector3(1, 0, 1), new Vector3(1, 1, 1), new Vector3(0, 1, 1)];
            //cube.triangles[5].Points = [new Vector3(1, 0, 1), new Vector3(0, 1, 1), new Vector3(0, 0, 1)];

            //cube.triangles[6].Points = [new Vector3(0, 0, 1), new Vector3(0, 1, 1), new Vector3(0, 1, 0)];
            //cube.triangles[7].Points = [new Vector3(0, 0, 1), new Vector3(0, 1, 0), new Vector3(0, 0, 0)];

            //cube.triangles[8].Points = [new Vector3(0, 1, 0), new Vector3(0, 1, 1), new Vector3(1, 1, 1)];
            //cube.triangles[9].Points = [new Vector3(0, 1, 0), new Vector3(1, 1, 1), new Vector3(1, 1, 0)];

            //cube.triangles[10].Points = [new Vector3(1, 0, 1), new Vector3(0, 0, 1), new Vector3(0, 0, 0)];
            //cube.triangles[11].Points = [new Vector3(1, 0, 1), new Vector3(0, 0, 0), new Vector3(1, 0, 0)];

            float near = 0.1f;
            float far = 1000f;
            float fov = 90f;
            float aspectRatio = Height / Width;
            float fovRad = MyMath.DegreesToRadians(fov);

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

            //color.R += (float)rnd.NextDouble() * ElapsedTime;
            //color.G += (float)rnd.NextDouble() * ElapsedTime;
            //color.B += (float)rnd.NextDouble() * ElapsedTime;

            //if (color.R > 1f)
            //{
            //    color.R = 0f;
            //}
            //if (color.G > 1f)
            //{
            //    color.G = 0f;
            //}
            //if (color.B > 1f)
            //{
            //    color.B = 0f;
            //}
        }

        public override void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(bgColor);

            fTheta += 1f + ElapsedTime;

            Matrix4x4.CreateRotationZ(fTheta, out RotationZMatrix);

            //RotationZMatrix.Matrix[0,0] = MathF.Cos(fTheta);
            //RotationZMatrix.Matrix[0,1] = MathF.Sin(fTheta);
            //RotationZMatrix.Matrix[1,0] = -MathF.Sin(fTheta);
            //RotationZMatrix.Matrix[1,1] = MathF.Cos(fTheta);
            //RotationZMatrix.Matrix[2,2] = 1;
            //RotationZMatrix.Matrix[3,3] = 1;

            Matrix4x4.CreateRotationX(fTheta, out RotationZMatrix);

            //RotationXMatrix.Matrix[0, 0] = 1f;
            //RotationXMatrix.Matrix[1, 1] = MathF.Cos(0.5f * fTheta);
            //RotationXMatrix.Matrix[1, 2] = MathF.Sin(0.5f * fTheta);
            //RotationXMatrix.Matrix[2, 1] = -MathF.Sin(0.5f * fTheta);
            //RotationXMatrix.Matrix[2, 2] = -MathF.Cos(0.5f * fTheta);
            //RotationXMatrix.Matrix[3, 3] = 1;

            //foreach (var tri in cube.triangles)
            //{
            //    Triangle triProjected = new Triangle();
            //    Triangle triTranslated = new Triangle();
            //    Triangle triRotatedZX = new Triangle();
            //    Triangle triRotatedZ = new Triangle();

            //    // 
            //    Matrix4x4.RotateVector(tri.Points[0], out triRotatedZ.Points[0], RotationZMatrix);
            //    Matrix4x4.RotateVector(tri.Points[1], out triRotatedZ.Points[1], RotationZMatrix);
            //    Matrix4x4.RotateVector(tri.Points[2], out triRotatedZ.Points[2], RotationZMatrix);

            //    // 
            //    Matrix4x4.RotateVector(triRotatedZ.Points[0], out triRotatedZX.Points[0], RotationXMatrix);
            //    Matrix4x4.RotateVector(triRotatedZ.Points[1], out triRotatedZX.Points[1], RotationXMatrix);
            //    Matrix4x4.RotateVector(triRotatedZ.Points[2], out triRotatedZX.Points[2], RotationXMatrix);

            //    triTranslated = triRotatedZX;
            //    triTranslated.Points[0].Z = triRotatedZX.Points[0].Z + 3f;
            //    triTranslated.Points[1].Z = triRotatedZX.Points[1].Z + 3f;
            //    triTranslated.Points[2].Z = triRotatedZX.Points[2].Z + 3f;

            //    Matrix4x4.RotateVector(triTranslated.Points[0], out triProjected.Points[0], projectionMatrix);
            //    Matrix4x4.RotateVector(triTranslated.Points[1], out triProjected.Points[1], projectionMatrix);
            //    Matrix4x4.RotateVector(triTranslated.Points[2], out triProjected.Points[2], projectionMatrix);

            //    triProjected.Points[0].X += 1f;
            //    triProjected.Points[0].Y += 1f;

            //    triProjected.Points[1].X += 1f;
            //    triProjected.Points[1].Y += 1f;

            //    triProjected.Points[2].X += 1f;
            //    triProjected.Points[2].Y += 1f;

            //    triProjected.Points[0].X *= 0.5f * Width;
            //    triProjected.Points[0].Y *= 0.5f * Height;

            //    triProjected.Points[1].X *= 0.5f * Width;
            //    triProjected.Points[1].Y *= 0.5f * Height;

            //    triProjected.Points[2].X *= 0.5f * Width;
            //    triProjected.Points[2].Y *= 0.5f * Height;

            //    DrawTriangle(triProjected.Points[0], triProjected.Points[1], triProjected.Points[2], fgColor.R, fgColor.G, fgColor.B);
            //}
        }
    }
}
