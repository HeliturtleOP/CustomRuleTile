using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshCombinerTest : MonoBehaviour
{
    // Start is called before the first frame update
    public void CombineMesh()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }
        transform.GetComponent<MeshFilter>().sharedMesh = new Mesh();
        transform.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);

        transform.GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().sharedMesh;

        transform.position = Vector3.zero;

        int childs = transform.childCount;
        for (int c = childs - 1; c >= 0; c--)
        {
            DestroyImmediate(transform.GetChild(c).gameObject);
        }
    }
}
