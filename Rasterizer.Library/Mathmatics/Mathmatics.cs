namespace Rasterizer.Library.Mathmatics
{
    public struct Vector3
    {
        public float X, Y, Z;

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(float x, float y)
        {
            X = x;
            Y = y;
            Z = 0f;
        }

        public Vector3(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        public Vector3(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }
        public Vector3(Vector2 v2)
        {
            X = v2.X;
            Y = v2.Y;
            Z = 0f;
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            lhs.X += rhs.X;
            lhs.Y += rhs.Y;
            lhs.Z += rhs.Z;
            return lhs;
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            lhs.X -= rhs.X;
            lhs.Y -= rhs.Y;
            lhs.Z -= rhs.Z;
            return lhs;
        }

        public static Vector3 operator -(Vector3 vec)
        {
            vec.X = -vec.X;
            vec.Y = -vec.Y;
            vec.Z = -vec.Z;
            return vec;
        }

        public static Vector3 operator *(Vector3 lhs, Vector3 rhs)
        {
            lhs.X *= rhs.X;
            lhs.Y *= rhs.Y;
            lhs.Z *= rhs.Z;
            return lhs;
        }

        public static Vector3 operator *(Vector3 vec, float scale)
        {
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            return vec;
        }

        public static Vector3 operator *(float scale, Vector3 vec)
        {
            vec.X *= scale;
            vec.Y *= scale;
            vec.Z *= scale;
            return vec;
        }

        public static Vector3 operator /(Vector3 lhs, Vector3 rhs)
        {
            lhs.X /= rhs.X;
            lhs.Y /= rhs.Y;
            lhs.Z /= rhs.Z;
            return lhs;
        }

        public static Vector3 operator /(Vector3 vec, float scale)
        {
            vec.X /= scale;
            vec.Y /= scale;
            vec.Z /= scale;
            return vec;
        }

        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return Equals(lhs, rhs);
        }

        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return !Equals(lhs, rhs);
        }

        public static bool Equals(Vector3 lhs, Vector3 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }
    }
    public struct Vector2
    {
        public float X, Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
        }

        public Vector2(float value)
        {
            X = value;
            Y = value;
        }

        public Vector2(Vector2 v)
        {
            X = v.X;
            Y = v.Y;
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            lhs.X += rhs.X;
            lhs.Y += rhs.Y;
            return lhs;
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            lhs.X -= rhs.X;
            lhs.Y -= rhs.Y;
            return lhs;
        }

        public static Vector2 operator -(Vector2 vec)
        {
            vec.X = -vec.X;
            vec.Y = -vec.Y;
            return vec;
        }

        public static Vector2 operator *(Vector2 vec, float scale)
        {
            vec.X *= scale;
            vec.Y *= scale;
            return vec;
        }

        public static Vector2 operator *(float scale, Vector2 vec)
        {
            vec.X *= scale;
            vec.Y *= scale;
            return vec;
        }

        public static Vector2 operator *(Vector2 lhs, Vector2 rhs)
        {
            lhs.X *= rhs.X;
            lhs.Y *= rhs.Y;
            return lhs;
        }

        public static Vector2 operator /(Vector2 lhs, Vector2 rhs)
        {
            lhs.X /= rhs.X;
            lhs.Y /= rhs.Y;
            return lhs;
        }

        public static Vector2 operator /(Vector2 vec, float scale)
        {
            vec.X /= scale;
            vec.Y /= scale;
            return vec;
        }

        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            return Equals(lhs, rhs);
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return !Equals(lhs, rhs);
        }

        public static bool Equals(Vector2 lhs, Vector2 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;
        }
    }

    public struct Matrix4x4
    {
        public float[,] Matrix = new float[4, 4];

        public Matrix4x4()
        {
        }
    }
}
