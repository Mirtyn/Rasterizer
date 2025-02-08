using OpenTK.Graphics.OpenGL;
using System.Collections;

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

    //public struct Color4
    //{
    //    public float R;
    //    public float G;
    //    public float B;
    //    public float A;

    //    public Color4(float r, float g, float b, float a)
    //    {
    //        R = r; G = g; B = b; A = a;
    //    }

    //    public Color4(float r, float g, float b)
    //    {
    //        R = r; G = g; B = b; A = 1f;
    //    }

    //    public static Color4 Black => new Color4(0, 0, 0);
    //    public static Color4 White => new Color4(1, 1, 1);
    //    public static Color4 Red => new Color4(1, 0, 0);
    //    public static Color4 Green => new Color4(0, 1, 0);
    //    public static Color4 Blue => new Color4(0, 0, 1);
    //    public static Color4 Transparent => new Color4(0, 0, 0, 0);

    //    public static Color4 operator +(Color4 lhs, Color4 rhs)
    //    {
    //        lhs.R += rhs.R;
    //        lhs.G += rhs.G;
    //        lhs.B += rhs.B;
    //        lhs.A += rhs.A;

    //        return Color4.Clamp(lhs, 0f, 1f);
    //    }

    //    public static Color4 operator -(Color4 lhs, Color4 rhs)
    //    {
    //        lhs.R -= rhs.R;
    //        lhs.G -= rhs.G;
    //        lhs.B -= rhs.B;
    //        lhs.A -= rhs.A;

    //        return Color4.Clamp(lhs, 0f, 1f);
    //    }

    //    public static Color4 operator *(Color4 color, float scale)
    //    {
    //        color.R *= scale;
    //        color.G *= scale;
    //        color.B *= scale;
    //        color.A *= scale;

    //        return Color4.Clamp(color, 0f, 1f);
    //    }

    //    public static bool operator ==(Color4 lhs, Color4 rhs)
    //    {
    //        return lhs.R == rhs.R &&
    //        lhs.G == rhs.G &&
    //        lhs.B == rhs.B &&
    //        lhs.A == rhs.A;
    //    }

    //    public static bool operator !=(Color4 lhs, Color4 rhs)
    //    {
    //        return !(lhs == rhs);
    //    }

    //    public static Color4 Clamp(Color4 color, float min, float max)
    //    {
    //        color.R = Math.Clamp(color.R, min, max);
    //        color.G = Math.Clamp(color.G, min, max);
    //        color.B = Math.Clamp(color.B, min, max);
    //        color.A = Math.Clamp(color.A, min, max);
    //        return color;
    //    }

    //    public static implicit operator OpenTK.Mathematics.Color4(Color4 color)
    //    {
    //        return new OpenTK.Mathematics.Color4(color.R, color.G, color.B, color.A);
    //    }
    //}

    public struct Matrix4x4
    {
        public float[,] Matrix = new float[4, 4];

        public Matrix4x4()
        {
        }

        public Matrix4x4(float[,] otherMatrix)
        {
            Matrix = otherMatrix;
        }

        public static readonly Matrix4x4 Identity = new Matrix4x4 {
            Matrix = new float[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f }
            } };

        public static void MultiplyMatrixVector(Vector3 i, out Vector3 o, Matrix4x4 m)
        {
            o.X = i.X * m.Matrix[0,0] + i.Y * m.Matrix[1,0] + i.Z * m.Matrix[2,0] + m.Matrix[3,0];
            o.Y = i.X * m.Matrix[0,1] + i.Y * m.Matrix[1,1] + i.Z * m.Matrix[2,1] + m.Matrix[3,1];
            o.Z = i.X * m.Matrix[0,2] + i.Y * m.Matrix[1,2] + i.Z * m.Matrix[2,2] + m.Matrix[3,2];
            float w = i.X * m.Matrix[0, 3] + i.Y * m.Matrix[1, 3] + i.Z * m.Matrix[2, 3] + m.Matrix[3, 3];

            if (w != 0)
            {
                o.X /= w;
                o.Y /= w;
                o.Z /= w;
            }
        }
    }
}
