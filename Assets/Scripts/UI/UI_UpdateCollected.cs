using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Items;

public class UI_UpdateCollected : MonoBehaviour
{
    Text text;
    [SerializeField] ItemInventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = $"Collected dolls: {inventory.items.Count} / {inventory.maxCapacity}"; 
    }
}
