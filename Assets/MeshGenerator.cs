using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    [SerializeField] Vector3[] verticies;
    int[] triagnles;

    public int xSize = 20;
    public int zSize = 20;

    public int density = 1;

    void Start() {
        

        DrawMesh();
    }

    void Update() {
        DrawMesh();
        UpdateMesh();
    }

    public void DrawMesh() {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        int xs = xSize * density;
        int zs = zSize * density;
        verticies = new Vector3[(xs + 1) * (zs + 1)];
        for(int i = 0, z = 0; z <= zs; z++) {
            for(int x = 0; x <= xs; x++) {
                float y = Mathf.PerlinNoise(((float) x  / density + transform.position.x) * 0.3f, ((float) z  / density + transform.position.z) * 0.3f) * 2f;
                verticies[i] = new Vector3((float) x / density, y, (float) z / density);
                i++;
            }
        }

        triagnles = new int[xs * zs * 6];
        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zs; z++, vert++)
        {
            for(int x = 0; x < xs; x++) {
                triagnles[tris++] = vert + 0;
                triagnles[tris++] = vert + xs + 1;
                triagnles[tris++] = vert + 1;
                triagnles[tris++] = vert + 1;
                triagnles[tris++] = vert + xs + 1;
                triagnles[tris++] = vert + xs + 2;

                vert++;

            }
        }
        
        

        UpdateMesh();
    }

    void UpdateMesh() {
        mesh.Clear();
        mesh.vertices = verticies;
        mesh.triangles = triagnles;
        mesh.RecalculateNormals();
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}
