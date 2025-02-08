using OpenTK.Graphics.ES11;
using Rasterizer.Library;
using Rasterizer.Library.Mathmatics;

namespace Rasterizer.Console.Rasterizers
{
    internal class RotatingCubeRasterizer : AbstractRasterizer
    {
        Random random = new Random();

        Vector3 LeftTopFront = new Vector3();
        Vector3 RightTopFront = new Vector3();
        Vector3 LeftTopBack = new Vector3();
        Vector3 RightTopBack = new Vector3();
        Vector3 LeftBottomFront = new Vector3();
        Vector3 RightBottomFront = new Vector3();
        Vector3 LeftBottomBack = new Vector3();
        Vector3 RightBottomBack = new Vector3();

        Vector3[]? Points = null;

        Vector3 _position = new Vector3(0, 0, 0);
        Vector3 _rotation = new Vector3(0, 0, 0);
        Vector3 _scale = new Vector3(1, 1, 1);

        float _cubeWidth = 1.0f;
        float _cubeHeight = 1.0f;
        float _cubeDepth = 1.0f;

        Vector3 MoveSpeed = new Vector3(0.25f, 0.125f, 0.05f);
        Vector3 RotateSpeed = new Vector3(MathF.PI * 0.10f, MathF.PI * 0.10f, MathF.PI * 0.10f);
        Vector3 ScaleSpeed = new Vector3(25, 25, 25);

        Vector3 MoveDirection = new Vector3(1, 1, 1);
        Vector3 RotateDirection = new Vector3(1, 1, 1);
        Vector3 ScaleDirection = new Vector3(1, 1, 1);

        Mesh mesh = new Mesh();

        // note: Only works on Mirtyn's laptop
        string meshPath = "Media//monkey.obj";

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

        public RotatingCubeRasterizer()
        {
            SizeCube();

            Points = new Vector3[]
            {
                LeftTopFront,
                RightTopFront,
                LeftTopBack,
                RightTopBack,
                LeftBottomFront,
                RightBottomFront,
                LeftBottomBack,
                RightBottomBack,
            };

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


        public override void Load()
        {
            System.IO.Directory.GetCurrentDirectory();
            mesh = ObjReader.Run(meshPath);
        }


        public override void Render()
        {
            Clear();

            var translation = Matrix4x4.CreateTranslation(_position);

            var rotationZ = Matrix4x4.CreateRotationZ(MathF.PI);

            var rotationY = Matrix4x4.CreateRotationY(_rotation.Y);

            var rotationX = Matrix4x4.CreateRotationX(_rotation.X);

            //var perspectiveTranform = Matrix4x4.PerspectiveMatrix(fov, aspect, near, far);

            var transformed = new Vector3[mesh.Vertices.Length];

            for(var i = 0; i < mesh.Vertices.Length; i++)
            {
                transformed[i] = Matrix4x4.RotateVector(mesh.Vertices[i], rotationY);
                //transformed[i] = Matrix4x4.RotateVector(transformed[i], rotationX);
                transformed[i] = Matrix4x4.RotateVector(transformed[i], rotationZ);
                //transformed[i] = Matrix4x4.TranslateVector(transformed[i], translation);


                // perspective transform !!!
                //transformed[i] = Matrix4x4.TransformVector(transformed[i], perspectiveTranform);


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

            //DrawLine(transformed[0], transformed[1]);
            //DrawLine(transformed[2], transformed[3]);

            //DrawLine(transformed[0], transformed[2]);
            //DrawLine(transformed[1], transformed[3]);

            //DrawLine(transformed[4], transformed[5]);
            //DrawLine(transformed[6], transformed[7]);

            //DrawLine(transformed[4], transformed[6]);
            //DrawLine(transformed[5], transformed[7]);

            //DrawLine(transformed[0], transformed[4]);
            //DrawLine(transformed[1], transformed[5]);

            //DrawLine(transformed[2], transformed[6]);
            //DrawLine(transformed[3], transformed[7]);
        }

        public override void Update()
        {
            if (_position.X > 1 || _position.X < -1)
            {
                MoveDirection.X = -MoveDirection.X;
            }

            if (_position.Y > 1 || _position.Y < -1)
            {
                MoveDirection.Y = -MoveDirection.Y;
            }

            if (_position.Z > 1 || _position.Z < -1)
            {
                MoveDirection.Z = -MoveDirection.Z;
            }

            _position += MoveDirection * ElapsedTime * MoveSpeed;
            _rotation += RotateDirection * ElapsedTime * RotateSpeed;
        }
    }
}
