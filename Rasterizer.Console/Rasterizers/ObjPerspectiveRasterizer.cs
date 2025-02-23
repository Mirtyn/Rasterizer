using OpenTK.Graphics.ES11;
using Rasterizer.Library;
using Rasterizer.Library.Mathmatics;
using Rasterizer.Library.Utility;
using System;

namespace Rasterizer.Console.Rasterizers
{
    internal class ObjPerspectiveRasterizer : AbstractRasterizer
    {
        Random random = new Random();

        public Vector3 Position = new Vector3(0, 0, 0);
        public Vector3 Rotation = new Vector3(0, 0, 0);
        public Vector3 Scale = new Vector3(1, 1, 1);

        float _cubeWidth = 1.0f;
        float _cubeHeight = 1.0f;
        float _cubeDepth = 1.0f;

        public Vector3 MoveSpeed = new Vector3(0.25f, 0.125f, 0.05f);
        public Vector3 RotateSpeed = new Vector3(MathF.PI * 0.10f, MathF.PI * 0.10f, MathF.PI * 0.10f);
        public Vector3 ScaleSpeed = new Vector3(5, 5, 5);

        public Vector3 MoveDirection = new Vector3(1, 1, 1);
        public Vector3 RotateDirection = new Vector3(1, 1, 1);
        public Vector3 ScaleDirection = new Vector3(1, 1, 1);

        Mesh mesh = new Mesh();

        string meshPath = "Media//monkey.obj";

        public ObjPerspectiveRasterizer()
        {
            MoveSpeed = new Vector3(random.NextSingle(0.005f, 0.075f), random.NextSingle(0.005f, 0.075f), random.NextSingle(0.005f, 0.075f));
            RotateSpeed = new Vector3(MathF.PI * random.NextSingle(0.005f, 0.025f), MathF.PI * random.NextSingle(0.005f, 0.025f), MathF.PI * random.NextSingle(0.005f, 0.025f));
            ScaleSpeed = new Vector3(random.NextSingle(0.025f, 0.2f), random.NextSingle(0.025f, 0.2f), random.NextSingle(0.025f, 0.2f));
            MoveDirection.X = random.NextBool() ? 1 : -1;
            MoveDirection.Y = random.NextBool() ? 1 : -1;
            MoveDirection.Z = random.NextBool() ? 1 : -1;

            RotateDirection.X = random.NextBool() ? 1 : -1;
            RotateDirection.Y = random.NextBool() ? 1 : -1;
            RotateDirection.Z = random.NextBool() ? 1 : -1;

            ScaleDirection.X = random.NextBool() ? 1 : -1;
            ScaleDirection.Y = random.NextBool() ? 1 : -1;
            ScaleDirection.Z = random.NextBool() ? 1 : -1;
        }

        public override void Load()
        {
            mesh = ObjReader.Run(meshPath);
        }


        public override void Render()
        {
            Clear();

            var scale = Matrix4x4.CreateScale(Scale);

            var translation = Matrix4x4.CreateTranslation(Position);

            var rotationZ = Matrix4x4.CreateRotationZ(Rotation.Z);

            var rotationY = Matrix4x4.CreateRotationY(Rotation.Y);

            var rotationX = Matrix4x4.CreateRotationX(Rotation.X);

            //var perspectiveTranform = Matrix4x4.PerspectiveMatrix(fov, aspect, near, far);

            float near = 0.1f;
            float far = 1000f;
            float fov = 90f;
            float aspectRatio = Height / Width;
            float fovRad = MyMath.DegreesToRadians(fov);

            var perspective = Matrix4x4.CreateProjectionMatrix(fovRad, aspectRatio, near, far);

            var transformed = new Vector3[mesh.Vertices.Length];

            for (var i = 0; i < mesh.Vertices.Length; i++)
            {
                transformed[i] = Matrix4x4.ScaleVector(mesh.Vertices[i], scale);
                transformed[i] = Matrix4x4.RotateVector(transformed[i], rotationY);
                transformed[i] = Matrix4x4.RotateVector(transformed[i], rotationX);
                transformed[i] = Matrix4x4.RotateVector(transformed[i], rotationZ);
                transformed[i] = Matrix4x4.TranslateVector(transformed[i], translation);
                transformed[i] = Matrix4x4.MultiplyPerspectiveMatrixVector(transformed[i], perspective);

                transformed[i].X += 1.0f;
                transformed[i].Y += 1.0f;

                transformed[i].X *= 0.5f * Width;
                transformed[i].Y *= 0.5f * Height;
            }

            for (int i = 0; i < mesh.Vertices.Length; i += 3)
            {
                DrawLine(transformed[i], transformed[i + 1]);
                DrawLine(transformed[i + 1], transformed[i + 2]);
                DrawLine(transformed[i + 2], transformed[i]);
            }
        }

        public override void Update()
        {
            if (Position.X > 1 || Position.X < -1)
            {
                MoveDirection.X = -MoveDirection.X;
            }

            if (Position.Y > 1 || Position.Y < -1)
            {
                MoveDirection.Y = -MoveDirection.Y;
            }

            if (Position.Z > 1 || Position.Z < -1)
            {
                MoveDirection.Z = -MoveDirection.Z;
            }

            if (Scale.X > 1 || Scale.X < 0.25)
            {
                ScaleDirection.X = -ScaleDirection.X;
            }

            if (Scale.Y > 1 || Scale.Y < 0.25)
            {
                ScaleDirection.Y = -ScaleDirection.Y;
            }

            if (Scale.Z > 1 || Scale.Z < 0.25)
            {
                ScaleDirection.Z = -ScaleDirection.Z;
            }

            Position += MoveDirection * ElapsedTime * MoveSpeed;
            Rotation += RotateDirection * ElapsedTime * RotateSpeed;
            Scale += ScaleDirection * ElapsedTime * ScaleSpeed;
        }
    }
}
