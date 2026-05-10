using System.Collections.Generic;
using _03.Scripts.RollerCaster;
using UnityEngine;

namespace _03.Scripts.Test
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class TestCubeMeshGenerator : MonoBehaviour
    {
        public Vector3 pos;
        public Mesh mesh;
        
        public List<Vector3> vertices = new List<Vector3>();
        public List<int> triangles = new List<int>();
        public List<Vector2> uvs = new List<Vector2>();

        private int lastVertex;
        private void Start()
        {
           mesh  = new Mesh();

           DrawCube();

           mesh.vertices = vertices.ToArray();
           mesh.triangles = triangles.ToArray();
           mesh.SetUVs(0, uvs.ToArray());
           
           GetComponent<MeshFilter>().mesh = mesh;
        }

        private void DrawCube()
        {
            GenerateFrontFace();
        }

        private void GenerateFrontFace()
        {
            lastVertex =  vertices.Count;
            
            vertices.Add(pos + Vector3.forward);
            vertices.Add(pos + Vector3.up + Vector3.forward);
            vertices.Add(pos + Vector3.forward + Vector3.up + Vector3.right);
            vertices.Add(pos + Vector3.forward + Vector3.right);
            
            triangles.Add(lastVertex);
            triangles.Add(lastVertex+1);
            triangles.Add(lastVertex+2);
            
            triangles.Add(lastVertex);
            triangles.Add(lastVertex+2);
            triangles.Add(lastVertex+3);
        }
    }
}