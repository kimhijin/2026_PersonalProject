using System.Collections.Generic;
using UnityEngine;

namespace _03.Scripts.RollerCaster
{
    public class CommonTrack : Track
    {
        private readonly int staticAmt = 2;
        private float defaultRange = 1;

        private void DefaultTrack(float distance)
        {
            
        }

        [ContextMenu("TestCurve")]
        public void SetCurve()
        {
            Mesh mesh = meshFilter.mesh;
            
            Vector3[] vertices = mesh.vertices;

            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 v = vertices[i];

                v.y = Mathf.Sin(v.x);

                vertices[i] = v;
            }

            mesh.vertices = vertices;

            mesh.RecalculateNormals();//빛이 어떻게 반사될지 계산하는 방향값을 다시 계산해주는거
        }

        // public override bool LeftTrack(float range)
        // {
        //     Mesh mesh = meshFilter.mesh;
        //     myVertices.Clear();
        //     myTriangles.Clear();
        //     
        //     Vector3[] vertices = mesh.vertices;
        //     int[] triangles = mesh.triangles;
        //     float x = 0.2f;
        //
        //         for (int i = 0; i < range * 10; i++)
        //         {
        //             for (int j = 0; j < vertices.Length; j++)
        //             {
        //                 Vector3 v = vertices[j];
        //                 v.x = v.x +(i * range);
        //                 myVertices.Add(v);
        //             }
        //             for(int j =0; j<triangles.Length; j++)
        //                 myTriangles.Add(triangles[j]+(i*vertices.Length));
        //         }
        //    
        //
        //     for (int i = 0; i < myVertices.Count; i++)
        //     {
        //         Vector3 v = myVertices[i];
        //         
        //         
        //         v.z -= Mathf.Sin(v.x)/2;
        //
        //         myVertices[i] = v;
        //     }
        //
        //     mesh.vertices = myVertices.ToArray();
        //     mesh.triangles = myTriangles.ToArray();
        //
        //     mesh.RecalculateNormals();//빛이 어떻게 반사될지 계산하는 방향값을 다시 계산해주는거
        //     Debug.Log(mesh.vertexCount);
        //     return true;
        // }
        //
        // public override bool RightTrack(float range)
        // {
        //     Mesh mesh = meshFilter.mesh;
        //     myVertices.Clear();
        //     myTriangles.Clear();
        //     
        //     Vector3[] vertices = mesh.vertices;
        //     int[] triangles = mesh.triangles;
        //     float x = 0.2f;
        //
        //         for (int i = 0; i < range * 10; i++)
        //         {
        //             for (int j = 0; j < vertices.Length; j++)
        //             {
        //                 Vector3 v = vertices[j];
        //                 v.x = v.x +(i * range);
        //                 myVertices.Add(v);
        //             }
        //             for(int j =0; j<triangles.Length; j++)
        //                 myTriangles.Add(triangles[j]+(i*vertices.Length));
        //         }
        //
        //    
        //
        //     for (int i = 0; i < myVertices.Count; i++)
        //     {
        //         Vector3 v = myVertices[i];
        //         
        //         v.z += Mathf.Sin(v.x)/2;
        //
        //         myVertices[i] = v;
        //     }
        //
        //     mesh.vertices = myVertices.ToArray();
        //     mesh.triangles = myTriangles.ToArray();
        //
        //     mesh.RecalculateNormals();//빛이 어떻게 반사될지 계산하는 방향값을 다시 계산해주는거
        //     
        //     Debug.Log(mesh.vertexCount);
        //     return true;
        // }
        // public override bool LeftTrack(float range)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public override bool RightTrack(float range)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}