using Rasterizer.Library.Mathmatics;

namespace Rasterizer.UnitTests
{
    public class Matrix4x4UnitTest : AbstractUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MatrixMultiplicationTest()
        {
            var _position = new Rasterizer.Library.Mathmatics.Vector3(4, 7, 13);
            var translation = Matrix4x4.CreateTranslation(_position);


            // creating the far, near, fov, ratio for the perspective matrix
            float near = 0.1f;
            float far = 1000f;
            float fov = 90f;
            float aspectRatio = 500 / 500;
            float fovRad = MyMath.DegreesToRadians(fov);

            var perspective = Matrix4x4.CreateProjectionMatrix(fov, aspectRatio, near, far);

            OpenTK.Mathematics.Matrix4.CreateTranslation(_position.X, _position.Y, _position.Z, out OpenTK.Mathematics.Matrix4 openTKTranslation);
            var openTKPerspective = OpenTK.Mathematics.Matrix4.CreatePerspectiveFieldOfView(fovRad, aspectRatio, near, far);

            var result = translation * perspective;
            var openTKResult = openTKTranslation * openTKPerspective;

            Assert.IsTrue(EqualsFuzzy(openTKResult, result));
        }

        [Test]
        public void TransformationRotationYMatrixTest()
        {
            var _position = new Vector3(4, 7, 13);

            var translation = Matrix4x4.CreateTranslation(_position);

            OpenTK.Mathematics.Matrix4.CreateTranslation(_position.X, _position.Y, _position.Z, out OpenTK.Mathematics.Matrix4 openTKTranslation);

            var radians = MyMath.DegreesToRadians(23f);

            var rotation = Matrix4x4.CreateRotationY(radians);

            var openTKRotation = OpenTK.Mathematics.Matrix4.CreateRotationY(radians);

            var result = rotation * translation;

            var openTkResult = openTKRotation * openTKTranslation;

            Assert.IsTrue(EqualsFuzzy(openTkResult, result));
        }

        [Test]
        public void TransformationMatrixTest()
        {
            var _position = new Vector3(4, 7, 13);

            var translation = Matrix4x4.CreateTranslation(_position);

            OpenTK.Mathematics.Matrix4.CreateTranslation(_position.X, _position.Y, _position.Z, out OpenTK.Mathematics.Matrix4 openTKTranslation);

            Assert.IsTrue(EqualsFuzzy(openTKTranslation, translation));
        }

        [Test]
        public void RotateXMatrixTest()
        {
            var radians = MyMath.DegreesToRadians(45f);

            var translation = Matrix4x4.CreateRotationX(radians);

            var openTKTranslation = OpenTK.Mathematics.Matrix4.CreateRotationX(radians);

            Assert.IsTrue(EqualsFuzzy(openTKTranslation, translation));
        }

        [Test]
        public void RotateYMatrixTest()
        {
            var radians = MyMath.DegreesToRadians(23f);

            var translation = Matrix4x4.CreateRotationY(radians);

            var openTKTranslation = OpenTK.Mathematics.Matrix4.CreateRotationY(radians);

            Assert.IsTrue(EqualsFuzzy(openTKTranslation, translation));
        }

        [Test]
        public void RotateZMatrixTest()
        {
            var radians = MyMath.DegreesToRadians(52f);

            var translation = Matrix4x4.CreateRotationZ(radians);

            var openTKTranslation = OpenTK.Mathematics.Matrix4.CreateRotationZ(radians);

            Assert.IsTrue(EqualsFuzzy(openTKTranslation, translation));
        }

        [Test]
        public void PerspectiveTest()
        {
            // creating the far, near, fov, ratio for the perspective matrix
            float near = 0.1f;
            float far = 1000f;
            float fov = 90f;
            float aspectRatio = 500 / 500;
            float fovRad = MyMath.DegreesToRadians(fov);

            var perspective = Matrix4x4.CreateProjectionMatrix(fovRad, aspectRatio, near, far);

            var openTKPerspective = OpenTK.Mathematics.Matrix4.CreatePerspectiveFieldOfView(fovRad, aspectRatio, near, far);

            Assert.IsTrue(EqualsFuzzy(openTKPerspective, perspective));
        }
    }
}