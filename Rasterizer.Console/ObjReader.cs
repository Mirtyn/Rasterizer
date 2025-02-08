using System.IO;
using Rasterizer.Library;
using Rasterizer.Library.Mathmatics;

namespace Rasterizer.Console
{
    public static class ObjReader
    {
        public static Mesh Run(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File in location: '" + path + "' does not exist.");
            }

            var lines = File.ReadAllLines(path);

            //using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            //{
            //    stream.Read
            //}

            int numVerts = 0;
            int numNormals = 0;
            int numUvs = 0;
            int numFaces = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                switch (line.Split(' ')[0])
                {
                    case "v":
                        numVerts++;
                        break;
                    case "vn":
                        numNormals++;
                        break;
                    case "vt":
                        numUvs++;
                        break;
                    case "f":
                        numFaces++;
                        break;
                    default:
                        break;
                }
            }

            Vector3[] verticesByIndex = new Vector3[numVerts];
            Vector3[] normalsByIndex = new Vector3[numNormals];
            Vector2[] uvsByIndex = new Vector2[numUvs];

            int[] verticesIndex = new int[numFaces * 3];
            int[] normalsIndex = new int[numFaces * 3];
            int[] uvsIndex = new int[numFaces * 3];

            Vector3[] vertices = new Vector3[numFaces * 3];
            Vector3[] normals = new Vector3[numFaces * 3];
            Vector2[] uvs = new Vector2[numFaces * 3];

            int currentVert = 0;
            int currentNormal = 0;
            int currentUv = 0;
            int currentFace = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                string[] parts = line.Split(' ');

                switch (parts[0])
                {
                    case "v":
                        verticesByIndex[currentVert] = new Vector3(float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3]));
                        currentVert++;
                        break;

                    case "vn":
                        normalsByIndex[currentNormal] = new Vector3(float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3]));
                        currentNormal++;
                        break;

                    case "vt":
                        uvsByIndex[currentUv] = new Vector2(float.Parse(parts[1]), float.Parse(parts[2]));
                        currentUv++;
                        break;

                    case "f":
                        var faceParts = parts[1].Split('/');

                        verticesIndex[currentFace] = int.Parse(faceParts[0]);
                        uvsIndex[currentFace] = int.Parse(faceParts[1]);
                        normalsIndex[currentFace] = int.Parse(faceParts[2]);

                        vertices[currentFace] = verticesByIndex[int.Parse(faceParts[0])];
                        uvs[currentFace] = uvsByIndex[int.Parse(faceParts[1])];
                        normals[currentFace] = normalsByIndex[int.Parse(faceParts[2])];

                        currentFace++;

                        faceParts = parts[2].Split('/');

                        verticesIndex[currentFace] = int.Parse(faceParts[0]);
                        uvsIndex[currentFace] = int.Parse(faceParts[1]);
                        normalsIndex[currentFace] = int.Parse(faceParts[2]);

                        vertices[currentFace] = verticesByIndex[int.Parse(faceParts[0])];
                        uvs[currentFace] = uvsByIndex[int.Parse(faceParts[1])];
                        normals[currentFace] = normalsByIndex[int.Parse(faceParts[2])];

                        currentFace++;

                        faceParts = parts[3].Split('/');

                        verticesIndex[currentFace] = int.Parse(faceParts[0]);
                        uvsIndex[currentFace] = int.Parse(faceParts[1]);
                        normalsIndex[currentFace] = int.Parse(faceParts[2]);

                        vertices[currentFace] = verticesByIndex[int.Parse(faceParts[0])];
                        uvs[currentFace] = uvsByIndex[int.Parse(faceParts[1])];
                        normals[currentFace] = normalsByIndex[int.Parse(faceParts[2])];

                        currentFace++;
                        break;

                    default:
                        break;
                }
            }

            return new Mesh(vertices, normals, uvs);
        }
    }
}
