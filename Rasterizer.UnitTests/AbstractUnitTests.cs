using Rasterizer.Library.Mathmatics;

namespace Rasterizer.UnitTests
{
    public abstract class AbstractUnitTests
    {
        protected bool EqualsFuzzy(OpenTK.Mathematics.Matrix4 a, Matrix4x4 b, float fuzzy = 0.0001f)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!EqualsFuzzy(a[i, j], b[i, j], fuzzy))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        protected bool EqualsFuzzy(OpenTK.Mathematics.Vector3 a, Vector3 b, float fuzzy = 0.0001f)
        {
            return EqualsFuzzy(a.X, b.X, fuzzy) && EqualsFuzzy(a.Y, b.Y, fuzzy) && EqualsFuzzy(a.Z, b.Z, fuzzy);
        }

        protected bool EqualsFuzzy(Vector3 a, Vector3 b, float fuzzy = 0.0001f)
        {
            return EqualsFuzzy(a.X, b.X, fuzzy) && EqualsFuzzy(a.Y, b.Y, fuzzy) && EqualsFuzzy(a.Z, b.Z, fuzzy);
        }

        protected bool EqualsFuzzy(float a, float b, float fuzzy = 0.0001f)
        {
            return Math.Abs(a - b) < fuzzy;
        }
    }
}