using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableVariables;
using UnityEngine.UI;

public class UI_BurnedItems : MonoBehaviour
{
    [SerializeField] IntReference burnedItems;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
       text = gameObject.GetComponent<Text>();
       burnedItems.Value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"Burned items: {burnedItems.Value}/10";
    }
}
