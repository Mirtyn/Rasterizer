using Rasterizer.Library.Mathmatics;

namespace Rasterizer.UnitTests
{
    public class Vector3UnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyDefaultConstructorTest()
        {
            var a = new Vector3();

            var expected = new Vector3(0.0f, 0.0f, 0.0f);

            Assert.IsTrue(EqualsFuzzy(a, expected));
        }

        [Test]
        public void DefaultConstructorTest()
        {
            var expected = new Vector3(8.265f, 4.5978f, 0.554f);

            var a = new Vector3(expected.X, expected.Y, expected.Z);

            Assert.IsTrue(EqualsFuzzy(a, expected));
        }

        [Test]
        public void Vector3AddTest()
        {
            var otkA = new OpenTK.Mathematics.Vector3(0.0f, 0.0f, 0.0f);
            var otkB = new OpenTK.Mathematics.Vector3(8.1f, 2.14f, 8.9835f);

            var expected = OpenTK.Mathematics.Vector3.Add(otkA, otkB);

            Assert.IsTrue(EqualsFuzzy(expected, new Vector3(otkA.X, otkA.Y, otkA.Z) + new Vector3(otkB.X, otkB.Y, otkB.Z)));
        }

        [Test]
        public void Vector3SubtractTest()
        {
            var otkA = new OpenTK.Mathematics.Vector3(0.0f, 0.0f, 0.0f);
            var otkB = new OpenTK.Mathematics.Vector3(8.1f, 2.14f, 8.9835f);

            var expected = OpenTK.Mathematics.Vector3.Subtract(otkA, otkB);

            Assert.IsTrue(EqualsFuzzy(expected, new Vector3(otkA.X, otkA.Y, otkA.Z) - new Vector3(otkB.X, otkB.Y, otkB.Z)));
        }

        [Test]
        public void Vector3MultiplyTest()
        {
            var otkA = new OpenTK.Mathematics.Vector3(2.1f, 1.78f, 4.89f);
            var otkB = new OpenTK.Mathematics.Vector3(8.1f, 2.14f, 8.9835f);

            var expected = OpenTK.Mathematics.Vector3.Multiply(otkA, otkB);

            Assert.IsTrue(EqualsFuzzy(expected, new Vector3(otkA.X, otkA.Y, otkA.Z) * new Vector3(otkB.X, otkB.Y, otkB.Z)));
        }

        [Test]
        public void Vector3MultiplyWithSingleTest()
        {
            var otkA = new OpenTK.Mathematics.Vector3(2.1f, 1.78f, 4.89f);
            var otkB = 2.145f;

            var expected = OpenTK.Mathematics.Vector3.Multiply(otkA, otkB);

            Assert.IsTrue(EqualsFuzzy(expected, new Vector3(otkA.X, otkA.Y, otkA.Z) * otkB));
        }

        [Test]
        public void Vector3DivideTest()
        {
            var otkA = new OpenTK.Mathematics.Vector3(0.0f, 0.0f, 0.0f);
            var otkB = new OpenTK.Mathematics.Vector3(8.1f, 2.14f, 8.9835f);

            var expected = OpenTK.Mathematics.Vector3.Divide(otkA, otkB);

            Assert.IsTrue(EqualsFuzzy(expected, new Vector3(otkA.X, otkA.Y, otkA.Z) / new Vector3(otkB.X, otkB.Y, otkB.Z)));
        }

        [Test]
        public void Vector3DivideWithSingleTest()
        {
            var otkA = new OpenTK.Mathematics.Vector3(2.1f, 1.78f, 4.89f);
            var otkB = 0.945f;

            var expected = OpenTK.Mathematics.Vector3.Divide(otkA, otkB);

            Assert.IsTrue(EqualsFuzzy(expected, new Vector3(otkA.X, otkA.Y, otkA.Z) * otkB));
        }

        private bool EqualsFuzzy(OpenTK.Mathematics.Vector3 a, Vector3 b, float fuzzy = 0.0001f)
        {
            return EqualsFuzzy(a.X, b.X, fuzzy) && EqualsFuzzy(a.Y, b.Y, fuzzy) && EqualsFuzzy(a.Z, b.Z, fuzzy);
        }

        private bool EqualsFuzzy(Vector3 a, Vector3 b, float fuzzy = 0.0001f)
        {
            return EqualsFuzzy(a.X, b.X, fuzzy) && EqualsFuzzy(a.Y, b.Y, fuzzy) && EqualsFuzzy(a.Z, b.Z, fuzzy);
        }

        private bool EqualsFuzzy(float a, float b, float fuzzy = 0.0001f)
        {
            return Math.Abs(a - b) < fuzzy;
        }
    }
}