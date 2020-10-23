using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCrosshairTexture : MonoBehaviour
{
    [SerializeField] private Texture InactiveCrosshair;
    [SerializeField] private Texture ActiveCrosshair;
    [SerializeField] private bool isActive;
    private RawImage image;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive){
            image.texture = ActiveCrosshair;
            return;
        }

        image.texture = InactiveCrosshair;
    }
}
