using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Items;
using ScriptableVariables;

public class UI_SpiritPressure : MonoBehaviour
{
    Text text;
    [SerializeField] IntReference spiritPressure;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"Spirit pressure: {spiritPressure.Value}%"; 
        
        if(spiritPressure.Value >= 80){
            text.color = new Color(255,0,0,255);
        }else{
            text.color = Color.white;
        }
    }
}
