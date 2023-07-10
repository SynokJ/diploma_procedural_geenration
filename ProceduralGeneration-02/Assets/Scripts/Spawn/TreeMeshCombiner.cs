using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMeshCombiner : MonoBehaviour
{

    [SerializeField] private GameObject _treePref;
    [SerializeField] private Vector2 _spawnRange;
    [SerializeField] private GameObject _forestMesh;

    [Range(0, 50)]
    [SerializeField] private int _amountOfChunk;

    private const int _MAX_TREE = 10;
    private float posX = 0;
    private float posY = 0;

    private Queue<GameObject> spawnedTrees = new Queue<GameObject>();
    private List<MeshFilter> meshFilters = new List<MeshFilter>();

    public void SpawnTree()
    {
        int maxNum = _MAX_TREE * (_amountOfChunk <= 0 ? 1 : _amountOfChunk);

        for (int i = 0; i < maxNum; ++i)
        {
            posX = Random.Range(-_spawnRange.x, _spawnRange.x);
            posY = Random.Range(-_spawnRange.y, _spawnRange.y);

            GameObject spawnedTree = Instantiate(_treePref, transform.position + new Vector3(posX, 0, posY), Quaternion.identity);

            foreach (var meshFilter in spawnedTree.GetComponentsInChildren<MeshFilter>())
                meshFilters.Add(meshFilter);

            spawnedTrees.Enqueue(spawnedTree);
        }
    }

    public void CombineMeshes()
    {
        CombineInstance[] combine = new CombineInstance[meshFilters.Count];

        for (int i = 0; i < meshFilters.Count; ++i)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }

        _forestMesh.transform.GetComponent<MeshFilter>().sharedMesh = new Mesh();
        _forestMesh.transform.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combine, true, true);
        _forestMesh.SetActive(true);

        _forestMesh.AddComponent<MeshCollider>();
    }

    public void ClearPlayground()
    {
        foreach (var obj in spawnedTrees)
            DestroyImmediate(obj);

        spawnedTrees.Clear();
        meshFilters.Clear();
    }
}
