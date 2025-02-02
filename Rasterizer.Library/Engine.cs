using Rasterizer.Library.Mathmatics;

namespace Rasterizer.Library
{
    public struct Triangle
    {
        public Vector3[] Points = new Vector3[3];

        public Triangle()
        {
            
        }
    }

    public struct Mesh
    {
        public Triangle[] triangles;

        public Mesh(int numTris)
        {
            triangles = new Triangle[numTris];
        }

        public Mesh(Triangle[] tris)
        {
            triangles = tris;
        }
    }
}
