using OpenTK.Mathematics;
using Rasterizer.Library.Mathmatics;

namespace Rasterizer.UnitTests
{
    public class Matrix4x4UnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MatrixMultiplicationTest()
        {
            bool trueOrFalse = true;

            var _position = new Rasterizer.Library.Mathmatics.Vector3(4, 7, 13);
            var translation = Matrix4x4.CreateTranslation(_position);


            // creating the far, near, fov, ratio for the perspective matrix
            float near = 0.1f;
            float far = 1000f;
            float fov = 90f;
            float aspectRatio = 500 / 500;
            float fovRad = 1f / MathF.Tan(fov * 0.5f / 180 * MathF.PI);

            var perspective = Matrix4x4.CreateProjectionMatrix(fov, aspectRatio, near, far);

            Matrix4.CreateTranslation(_position.X, _position.Y, _position.Z, out Matrix4 openTKTranslation);
            var openTKPerspective = Matrix4.CreatePerspectiveFieldOfView(fovRad, aspectRatio, near, far);

            var result = translation * perspective;
            var openTKResult = openTKTranslation * openTKPerspective;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0;  j < 4; j++)
                {
                    if (result[i, j] != openTKResult[i, j])
                    {
                        trueOrFalse = false;
                    }
                }
            }

            Assert.IsTrue(trueOrFalse);
        }
    }
}