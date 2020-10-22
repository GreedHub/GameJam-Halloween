using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;


public class ItemLogic : MonoBehaviour
{
    [SerializeField] public Item itemData;
    Renderer meshRenderer;
    MeshFilter meshFilter;
    MeshCollider meshCollider;


    // Start is called before the first frame update
    void Start()
    {
        meshFilter = gameObject.GetComponent<MeshFilter>();
        meshFilter.mesh = itemData.mesh;

        meshCollider = gameObject.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = itemData.mesh;

        meshRenderer = gameObject.GetComponent<Renderer>();
        meshRenderer.material = itemData.material;

        transform.localScale = Vector3.one * itemData.localScale;

        gameObject.tag = "Item";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
