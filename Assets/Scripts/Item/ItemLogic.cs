using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;


public class ItemLogic : MonoBehaviour
{
    [SerializeField] public Item itemData;
    GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        prefab = Instantiate(itemData.prefab,Vector3.zero,Quaternion.identity,transform);
        prefab.transform.localScale = Vector3.one * itemData.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
