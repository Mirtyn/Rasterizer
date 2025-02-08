using Rasterizer.Library.Mathmatics;

namespace Rasterizer.Console.Rasterizers
{
    internal class MovingCubeRasterizer : AbstractRasterizer
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

        Vector3 _position = new Vector3(0, 0, 0);
        Vector3 _rotation = new Vector3(0, 0, 0);
        Vector3 _scale = new Vector3(1, 1, 1);

        int _cubeWidth = 200;
        int _cubeHeight = 200;
        int _cubeDepth = 200;

        Vector3 MoveSpeed = new Vector3(125, 75, 50);
        Vector3 RotateSpeed = new Vector3(125, 125, 125);
        Vector3 ScaleSpeed = new Vector3(25, 25, 25);

        Vector3 MoveDirection = new Vector3(1, 1, 1);
        Vector3 RotateDirection = new Vector3(1, 1, 1);
        Vector3 ScaleDirection = new Vector3(1, 1, 1);

        public int CubeWidth
        {
            get { return _cubeWidth; }
            set
            {
                _cubeWidth = value;
                SizeCube();
            }
        }

        public int CubeHeight
        {
            get { return _cubeHeight; }
            set
            {
                _cubeHeight = value;
                SizeCube();
            }
        }

        public int CubeDepth
        {
            get { return _cubeDepth; }
            set
            {
                _cubeDepth = value;
                SizeCube();
            }
        }

        public MovingCubeRasterizer()
        {
            SizeCube();
        }

        private void SizeCube()
        {
            var front = -_cubeDepth / 2;
            var back = _cubeDepth / 2;

            var left = -_cubeWidth / 2;
            var right = _cubeWidth / 2;

            var top = -_cubeHeight / 2;
            var bottom = _cubeHeight / 2;

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

        }


        public override void Render()
        {
            Clear();

            var translation = Matrix4x4.CreateTranslation(_position);

            DrawLine(Matrix4x4.RotateVector(LeftTopFront, translation), Matrix4x4.RotateVector(RightTopFront, translation));
            DrawLine(Matrix4x4.RotateVector(LeftBottomFront, translation), Matrix4x4.RotateVector(RightBottomFront, translation));

            DrawLine(Matrix4x4.RotateVector(LeftTopFront, translation), Matrix4x4.RotateVector(LeftBottomFront, translation));
            DrawLine(Matrix4x4.RotateVector(RightTopFront, translation), Matrix4x4.RotateVector(RightBottomFront, translation));

            DrawLine(Matrix4x4.RotateVector(LeftTopBack, translation), Matrix4x4.RotateVector(RightTopBack, translation));
            DrawLine(Matrix4x4.RotateVector(LeftBottomBack, translation), Matrix4x4.RotateVector(RightBottomBack, translation));

            DrawLine(Matrix4x4.RotateVector(LeftTopBack, translation), Matrix4x4.RotateVector(LeftBottomBack, translation));
            DrawLine(Matrix4x4.RotateVector(RightTopBack, translation), Matrix4x4.RotateVector(RightBottomBack, translation));
        }

        public override void Update()
        {
            if (_position.X >= Width || _position.X < 0)
            {
                MoveDirection.X = -MoveDirection.X;
            }

            if (_position.Y >= Height || _position.Y < 0)
            {
                MoveDirection.Y = -MoveDirection.Y;
            }

            if (_position.Z >= Height || _position.Z < 0)
            {
                MoveDirection.Z = -MoveDirection.Z;
            }

            _position += MoveDirection * ElapsedTime * MoveSpeed;
        }
    }
}
