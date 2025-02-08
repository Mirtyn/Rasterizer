using Rasterizer.Library.Mathmatics;

namespace Rasterizer.Library
{
    //public struct Triangle
    //{
    //    public Vector3[] Points = new Vector3[3];

    //    public Triangle()
    //    {
            
    //    }
    //}

    public struct Mesh
    {
        public Vector3[] Vertices;
        public Vector3[] Normals;
        public Vector2[] Uvs;

        public Mesh(int numVertices, int numNormals, int numUvs)
        {
            Vertices = new Vector3[numVertices];
            Normals = new Vector3[numNormals];
            Uvs = new Vector2[numUvs];
        }

        public Mesh(Vector3[] verts, Vector3[] normals, Vector2[] uvs)
        {
            Vertices = verts;
            Normals = normals;
            Uvs = uvs;
        }
    }
}
