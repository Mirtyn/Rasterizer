using Rasterizer.Library.Mathmatics;
using Rasterizer.Library.Utility;
using System;
using System.Reflection;

namespace Rasterizer.Console.Rasterizers
{
    internal class MovingRotatingScalingCubeRasterizer : AbstractRasterizer
    {
        Random random = new Random();

        public int CubeCount = 24;

        List<Cube> CubeList;

        private class Cube
        {
            Vector3 LeftTopFront = new Vector3();
            Vector3 RightTopFront = new Vector3();
            Vector3 LeftTopBack = new Vector3();
            Vector3 RightTopBack = new Vector3();
            Vector3 LeftBottomFront = new Vector3();
            Vector3 RightBottomFront = new Vector3();
            Vector3 LeftBottomBack = new Vector3();
            Vector3 RightBottomBack = new Vector3();

            public Vector3[] Points;

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

            public float CubeWidth
            {
                get { return _cubeWidth; }
                set
                {
                    _cubeWidth = value;
                    SizeCube();
                }
            }

            public float CubeHeight
            {
                get { return _cubeHeight; }
                set
                {
                    _cubeHeight = value;
                    SizeCube();
                }
            }

            public float CubeDepth
            {
                get { return _cubeDepth; }
                set
                {
                    _cubeDepth = value;
                    SizeCube();
                }
            }

            public Cube()
            {
                SizeCube();

                Points =
                [
                    LeftTopFront,
                    RightTopFront,
                    LeftTopBack,
                    RightTopBack,
                    LeftBottomFront,
                    RightBottomFront,
                    LeftBottomBack,
                    RightBottomBack,
                ];
            }

            private void SizeCube()
            {
                var front = -_cubeDepth / 2.0f;
                var back = _cubeDepth / 2.0f;

                var left = -_cubeWidth / 2.0f;
                var right = _cubeWidth / 2.0f;

                var top = -_cubeHeight / 2.0f;
                var bottom = _cubeHeight / 2.0f;

                LeftTopFront = new Vector3(left, top, front);
                RightTopFront = new Vector3(right, top, front);
                LeftTopBack = new Vector3(left, top, back);
                RightTopBack = new Vector3(right, top, back);

                LeftBottomFront = new Vector3(left, bottom, front);
                RightBottomFront = new Vector3(right, bottom, front);
                LeftBottomBack = new Vector3(left, bottom, back);
                RightBottomBack = new Vector3(right, bottom, back);
            }
        }

        public MovingRotatingScalingCubeRasterizer()
        {
            CubeList = new List<Cube>(CubeCount);

            for (int i = 0; i < CubeCount; i++)
            {
                var cube = new Cube();

                cube.CubeWidth = cube.CubeHeight = cube.CubeDepth = random.Next(25, 100);
                cube.MoveSpeed = new Vector3(random.NextSingle(0.05f, 0.75f), random.NextSingle(0.05f, 0.75f), random.NextSingle(0.05f, 0.75f));
                cube.RotateSpeed = new Vector3(MathF.PI * random.NextSingle(0.05f, 0.25f), MathF.PI * random.NextSingle(0.05f, 0.25f), MathF.PI * random.NextSingle(0.05f, 0.25f));
                cube.ScaleSpeed = new Vector3(random.NextSingle(0.25f, 2f), random.NextSingle(0.25f, 2f), random.NextSingle(0.25f, 2f));

                cube.MoveDirection.X = random.NextBool() ? 1 : -1;
                cube.MoveDirection.Y = random.NextBool() ? 1 : -1;
                cube.MoveDirection.Z = random.NextBool() ? 1 : -1;

                cube.RotateDirection.X = random.NextBool() ? 1 : -1;
                cube.RotateDirection.Y = random.NextBool() ? 1 : -1;
                cube.RotateDirection.Z = random.NextBool() ? 1 : -1;

                cube.ScaleDirection.X = random.NextBool() ? 1 : -1;
                cube.ScaleDirection.Y = random.NextBool() ? 1 : -1;
                cube.ScaleDirection.Z = random.NextBool() ? 1 : -1;

                CubeList.Add(cube);
            }
        }
    

        public override void Load()
        {

        }


        public override void Render()
        {
            Clear();

            foreach(var cube in CubeList) 
            {
                RenderCube(cube);
            }
        }

        public override void Update()
        {
            foreach (var cube in CubeList)
            {
                UpdateCube(cube);
            }
        }

        void RenderCube(Cube cube)
        {
            Clear();

            var scale = Matrix4x4.CreateScale(cube.Scale);

            var translation = Matrix4x4.CreateTranslation(cube.Position);

            var rotationZ = Matrix4x4.CreateRotationZ(cube.Rotation.Z);

            var rotationY = Matrix4x4.CreateRotationY(cube.Rotation.Y);

            var rotationX = Matrix4x4.CreateRotationX(cube.Rotation.X);

            var transformed = new Vector3[8];

            for (var i = 0; i < cube.Points.Length; i++)
            {
                transformed[i] = Matrix4x4.ScaleVector(cube.Points[i], scale);
                transformed[i] = Matrix4x4.RotateVector(transformed[i], rotationY);
                transformed[i] = Matrix4x4.RotateVector(transformed[i], rotationX);
                transformed[i] = Matrix4x4.RotateVector(transformed[i], rotationZ);
                transformed[i] = Matrix4x4.TranslateVector(transformed[i], translation);

                transformed[i].X += 1.0f;
                transformed[i].Y += 1.0f;

                transformed[i].X *= 0.5f * Width;
                transformed[i].Y *= 0.5f * Height;
            }

            DrawLine(transformed[0], transformed[1]);
            DrawLine(transformed[2], transformed[3]);

            DrawLine(transformed[0], transformed[2]);
            DrawLine(transformed[1], transformed[3]);

            DrawLine(transformed[4], transformed[5]);
            DrawLine(transformed[6], transformed[7]);

            DrawLine(transformed[4], transformed[6]);
            DrawLine(transformed[5], transformed[7]);

            DrawLine(transformed[0], transformed[4]);
            DrawLine(transformed[1], transformed[5]);

            DrawLine(transformed[2], transformed[6]);
            DrawLine(transformed[3], transformed[7]);
        }

        void UpdateCube(Cube cube)
        {
            if (cube.Position.X > 1 || cube.Position.X < -1)
            {
                cube.MoveDirection.X = -cube.MoveDirection.X;
            }

            if (cube.Position.Y > 1 || cube.Position.Y < -1)
            {
                cube.MoveDirection.Y = -cube.MoveDirection.Y;
            }

            if (cube.Position.Z > 1 || cube.Position.Z < -1)
            {
                cube.MoveDirection.Z = -cube.MoveDirection.Z;
            }

            if (cube.Scale.X > 1 || cube.Scale.X < 0.25)
            {
                cube.ScaleDirection.X = -cube.ScaleDirection.X;
            }

            if (cube.Scale.Y > 1 || cube.Scale.Y < 0.25)
            {
                cube.ScaleDirection.Y = -cube.ScaleDirection.Y;
            }

            if (cube.Scale.Z > 1 || cube.Scale.Z < 0.25)
            {
                cube.ScaleDirection.Z = -cube.ScaleDirection.Z;
            }

            cube.Position += cube.MoveDirection * ElapsedTime * cube.MoveSpeed;
            cube.Rotation += cube.RotateDirection * ElapsedTime * cube.RotateSpeed;
            cube.Scale += cube.ScaleDirection * ElapsedTime * cube.ScaleSpeed;
        }
    }
}
