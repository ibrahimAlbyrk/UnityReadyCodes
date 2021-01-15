using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class MeshCombine : MonoBehaviour
{
    private MeshFilter[] _meshFilters;
    private CombineInstance[] _combine;

    private Vector3 _oldPos;
    private Vector3 _oldScale;
    public void CombineMesh()
    {
        _oldPos = transform.position;
        _oldScale = transform.localScale;
        
        _meshFilters = GetComponentsInChildren<MeshFilter>();
        _combine = new CombineInstance[_meshFilters.Length];
        
        for (var i = 0; i < _meshFilters.Length; i++)
        {
            _combine[i].mesh = _meshFilters[i].sharedMesh;
            _combine[i].transform = _meshFilters[i].transform.localToWorldMatrix;
        }

        transform.GetComponent<MeshFilter>().sharedMesh = new Mesh {indexFormat = UnityEngine.Rendering.IndexFormat.UInt32};
        transform.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(_combine);
        transform.GetComponent<MeshFilter>().sharedMesh.name = gameObject.name;
        
        transform.localScale = _oldScale;
        transform.position = _oldPos;

        AddMaterial();
    }

    public void ClearCombineMesh()
    {
        GetComponent<MeshFilter>().sharedMesh = null;
        GetComponent<MeshCollider>().sharedMesh = null;
        GetComponent<MeshRenderer>().material = null;
    }
    
    public void CreateMeshCollider()
    {
        var meshFilters = GetComponentsInChildren<MeshFilter>();
        var combine = new CombineInstance[meshFilters.Length];
        
        for (var i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }
        
        transform.GetComponent<MeshCollider>().sharedMesh = new Mesh {indexFormat = UnityEngine.Rendering.IndexFormat.UInt32};
        transform.GetComponent<MeshCollider>().sharedMesh.CombineMeshes(combine);
        transform.GetComponent<MeshCollider>().sharedMesh.name = $"{gameObject.name} Collider";
    }

    public void SetActiveChildObjects(bool isActive)
    {
        for (var i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(isActive);
    }

    public void AddMaterial()
    {
        var child = transform.GetChild(0).GetComponent<MeshRenderer>();
        if (child == null) return;
        GetComponent<MeshRenderer>().material = child.material;
    }
    
}
