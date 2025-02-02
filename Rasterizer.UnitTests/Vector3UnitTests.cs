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
        public void NewVector3EqualsZero()
        {
            var a = new Vector3();

            var b = new Vector3();

            b.X = 0;
            b.Y = 0;

            Assert.IsTrue(EqualsFuzzy(a, b));
        }

        [Test]
        public void Vector3Addition()
        {
            var a = new Vector3(0.0f, 0.0f);

            var b = new Vector3(2.0f, 1.0f);

            var expected = new Vector3(2.0f, 1.0f);

            Assert.IsTrue(EqualsFuzzy(expected, a + b));


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