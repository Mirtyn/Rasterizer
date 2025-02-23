using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System.Collections;
using System.Diagnostics.Contracts;
using System.Numerics;

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

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
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
            Matrix = new float[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f }
            };
        }

        public Matrix4x4(float[,] matrix)
        {
            Matrix = matrix;
        }

        public Matrix4x4(Matrix4x4 matrix)
        {
            for(var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    Matrix[i, j] = matrix[i, j];
                }
            }
        }

        public static readonly Matrix4x4 Identity = new Matrix4x4();

        public static readonly Matrix4x4 Zero = new Matrix4x4()
        {
            Matrix = new float[,]
            {
                { 0f, 0f, 0f, 0f },
                { 0f, 0f, 0f, 0f },
                { 0f, 0f, 0f, 0f },
                { 0f, 0f, 0f, 0f }
            }
        };

        public float this[int rowIndex, int columnIndex]
        {
            readonly get { return Matrix[rowIndex, columnIndex]; }
            set { Matrix[rowIndex, columnIndex] = value; }
        }

        public static Vector3 RotateVector(Vector3 i, Matrix4x4 m)
        {
            RotateVector(i, out Vector3 result, m);
            return result;
        }

        public static void RotateVector(Vector3 i, out Vector3 o, Matrix4x4 m)
        {
            o.X = (i.X * m[0, 0]) + (i.Y * m[1, 0]) + (i.Z * m[2, 0]);
            o.Y = (i.X * m[0, 1]) + (i.Y * m[1, 1]) + (i.Z * m[2, 1]);
            o.Z = (i.X * m[0, 2]) + (i.Y * m[1, 2]) + (i.Z * m[2, 2]);

            //o.X = i.X * m.Matrix[0, 0] + i.Y * m.Matrix[1, 0] + i.Z * m.Matrix[2, 0] + m.Matrix[3, 0];
            //o.Y = i.X * m.Matrix[0, 1] + i.Y * m.Matrix[1, 1] + i.Z * m.Matrix[2, 1] + m.Matrix[3, 1];
            //o.Z = i.X * m.Matrix[0, 2] + i.Y * m.Matrix[1, 2] + i.Z * m.Matrix[2, 2] + m.Matrix[3, 2];

            //float w = i.X * m.Matrix[0, 3] + i.Y * m.Matrix[1, 3] + i.Z * m.Matrix[2, 3] + m.Matrix[3, 3];

            //if (w != 0)
            //{
            //    o.X /= w;
            //    o.Y /= w;
            //    o.Z /= w;
            //}
        }

        public static Vector3 TranslateVector(Vector3 i, Matrix4x4 m)
        {
            TranslateVector(i, out Vector3 result, m);
            return result;
        }

        public static void TranslateVector(Vector3 i, out Vector3 o, Matrix4x4 m)
        {
            o.X = i.X + m[3, 0];
            o.Y = i.Y + m[3, 1];
            o.Z = i.Z + m[3, 2];
        }

        public static Vector3 MultiplyPerspectiveMatrixVector(Vector3 i, Matrix4x4 m)
        {
            MultiplyPerspectiveMatrixVector(i, out Vector3 result, m);
            return result;
        }

        public static void MultiplyPerspectiveMatrixVector(Vector3 i, out Vector3 o, Matrix4x4 m)
        {
            o.X = (i.X * m.Matrix[0, 0]) + (i.Y * m.Matrix[1, 0]) + (i.Z * m.Matrix[2, 0]) + m.Matrix[3, 0];
            o.Y = (i.X * m.Matrix[0, 1]) + (i.Y * m.Matrix[1, 1]) + (i.Z * m.Matrix[2, 1]) + m.Matrix[3, 1];
            o.Z = (i.X * m.Matrix[0, 2]) + (i.Y * m.Matrix[1, 2]) + (i.Z * m.Matrix[2, 2]) + m.Matrix[3, 2];

            float w = (i.X * m.Matrix[0, 3]) + (i.Y * m.Matrix[1, 3]) + (i.Z * m.Matrix[2, 3]) + m.Matrix[3, 3];

            if (w != 0)
            {
                o.X /= w;
                o.Y /= w;
                o.Z /= w;
            }
        }

        public static Vector3 ScaleVector(Vector3 i, Matrix4x4 m)
        {
            ScaleVector(i, out Vector3 result, m);
            return result;
        }

        public static void ScaleVector(Vector3 i, out Vector3 o, Matrix4x4 m)
        {
            o.X = i.X * m[0, 0];
            o.Y = i.Y * m[1, 1];
            o.Z = i.Z * m[2, 2];
        }

        public static void CreateTranslation(float x, float y, float z, out Matrix4x4 result)
        {
            result = new Matrix4x4();
            result[3, 0] = x;
            result[3, 1] = y;
            result[3, 2] = z;
        }

        public static Matrix4x4 CreateProjectionMatrix(float fov, float aspect, float near, float far)
        {
            float fovRad = MathF.Tan(fov * 0.5f);
            Matrix4x4 m = new Matrix4x4(Matrix4x4.Identity);

            m[0, 0] = 1f / (fovRad * aspect);
            m[1, 1] = 1f / fovRad;
            m[2, 2] = (far + near) / (near - far);
            m[2, 3] = (far + far) * near / (near - far);
            m[3, 2] = -1;

            return m;
        }

        public static Matrix4x4 CreateTranslation(float x, float y, float z)
        {
            CreateTranslation(x, y, z, out Matrix4x4 result);
            return result;
        }

        public static Matrix4x4 CreateTranslation(Vector3 vector)
        {
            CreateTranslation(vector.X, vector.Y, vector.Z, out Matrix4x4 result);
            return result;
        }

        public static void CreateScale(float x, float y, float z, out Matrix4x4 result)
        {
            result = new Matrix4x4();
            result[0, 0] = x;
            result[1, 1] = y;
            result[2, 2] = z;
        }

        public static void CreateScale(in Vector3 vector, out Matrix4x4 result)
        {
            result = new Matrix4x4();
            result[0, 0] = vector.X;
            result[1, 1] = vector.Y;
            result[2, 2] = vector.Z;
        }

        public static Matrix4x4 CreateScale(float x, float y, float z)
        {
            CreateScale(x, y, z, out Matrix4x4 result);
            return result;
        }

        public static Matrix4x4 CreateScale(Vector3 vector)
        {
            CreateScale(vector.X, vector.Y, vector.Z, out Matrix4x4 result);
            return result;
        }

        public static void CreateRotationX(float radians, out Matrix4x4 result)
        {
            result = new Matrix4x4();

            result.Matrix[1, 1] = MathF.Cos(radians);
            result.Matrix[1, 2] = MathF.Sin(radians);
            result.Matrix[2, 1] = -MathF.Sin(radians);
            result.Matrix[2, 2] = MathF.Cos(radians);
        }

        public static Matrix4x4 CreateRotationX(float radians)
        {
            CreateRotationX(radians, out Matrix4x4 result);
            return result;
        }

        public static void CreateRotationY(float radians, out Matrix4x4 result)
        {
            result = new Matrix4x4();
            result.Matrix[0, 0] = MathF.Cos(radians);
            result.Matrix[0, 2] = -MathF.Sin(radians);
            result.Matrix[2, 0] = MathF.Sin(radians);
            result.Matrix[2, 2] = MathF.Cos(radians);

            //var cos = MathF.Cos(angle);
            //var sin = MathF.Sin(angle);

            //result = Identity;
            //result.Row0.X = cos;
            //result.Row0.Y = sin;
            //result.Row1.X = -sin;
            //result.Row1.Y = cos;

        }

        public static Matrix4x4 CreateRotationY(float angle)
        {
            CreateRotationY(angle, out Matrix4x4 result);
            return result;
        }

        public static void CreateRotationZ(float radians, out Matrix4x4 result)
        {
            result = new Matrix4x4();
            result.Matrix[0, 0] = MathF.Cos(radians);
            result.Matrix[0, 1] = MathF.Sin(radians);
            result.Matrix[1, 0] = -MathF.Sin(radians);
            result.Matrix[1, 1] = MathF.Cos(radians);

            //var cos = MathF.Cos(angle);
            //var sin = MathF.Sin(angle);

            //result = Identity;
            //result.Row0.X = cos;
            //result.Row0.Y = sin;
            //result.Row1.X = -sin;
            //result.Row1.Y = cos;

        }

        public static Matrix4x4 CreateRotationZ(float angle)
        {
            CreateRotationZ(angle, out Matrix4x4 result);
            return result;
        }

        public static Matrix4x4 MultiplyMatrix(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            int length = 4;

            float temp = 0;

            Matrix4x4 result = new Matrix4x4(Matrix4x4.Identity);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    temp = 0;
                    for (int k = 0; k < length; k++)
                    {
                        temp += lhs[i, k] * rhs[k, j];
                    }
                    result[i, j] = temp;
                }
            }

            return result;
        }

        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            return Matrix4x4.MultiplyMatrix(lhs, rhs);
        }
    }
}
