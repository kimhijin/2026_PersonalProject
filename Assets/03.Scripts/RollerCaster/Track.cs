using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

namespace _03.Scripts.RollerCaster
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public abstract class Track : MonoBehaviour
    {
        protected MeshFilter meshFilter;
        protected List<Vector3> myVertices = new List<Vector3>();
        protected List<int> myTriangles = new List<int>();
        protected BezierKnot _knot;
        private Mesh _mesh;
        private Spline _spline;

        private void Awake()
        {
            meshFilter = GetComponent<MeshFilter>();
            myVertices = meshFilter.mesh.vertices.ToList();
            myTriangles = meshFilter.mesh.triangles.ToList();

            _mesh = new Mesh();
        }

        public void SetUp(BezierKnot knot)
        {
            _knot = knot;

            transform.position = knot.Position;
            transform.rotation = knot.Rotation;
        }

        private void Update()
        {
            if (_spline == null) return;
            LeftTrack(1, _spline);
        }

        public virtual bool LeftTrack(float range, Spline spline)
        {
            _spline = spline;
            
            List<Vector3> vertices = new();
            List<int> triangles = new();

            for (int i = 0; i <= 50; i++)
            {
                float t = i / (float)50;

                
                Vector3 pos = spline.EvaluatePosition(t);
                Vector3 tangent = spline.EvaluateTangent(t); //방향 벡터

                Vector3 forward = ((Vector3)tangent).normalized;

                Vector3 right =
                    Vector3.Cross(Vector3.up, forward).normalized; //Cross는 두 벡터의 수직 벡터를 구해주는거

                Vector3 leftVertex = pos - (Vector3)(right * 1 );
                Vector3 leftRVertex = pos - (Vector3)(right * 1 * 0.5f);
                Vector3 rightVertex = pos + (Vector3)(right * 1 );
                Vector3 rightLVertex = pos + (Vector3)(right * 1 * 0.5f);

                vertices.Add(leftVertex);
                vertices.Add(leftRVertex);
                vertices.Add(rightVertex);
                vertices.Add(rightLVertex);

                if (i < 50)
                {
                    int start = i * 4;

                    triangles.Add(start);
                    triangles.Add(start + 4);
                    triangles.Add(start + 1);

                    triangles.Add(start + 1);
                    triangles.Add(start + 4);
                    triangles.Add(start + 5);
                    
                    triangles.Add(start + 2);
                    triangles.Add(start + 3);
                    triangles.Add(start + 6);

                    triangles.Add(start + 3);
                    triangles.Add(start + 7);
                    triangles.Add(start + 6);
                }
            }

            _mesh.Clear();

            _mesh.vertices = vertices.ToArray();
            _mesh.triangles = triangles.ToArray();

            _mesh.RecalculateNormals();
            _mesh.RecalculateBounds();
            meshFilter.mesh = _mesh;
            return true;
        }

        public virtual bool RightTrack(float range)
        {
            return true;
        }
    }
}