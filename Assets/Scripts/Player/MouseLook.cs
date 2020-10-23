using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] Transform playerTransform;

    float verticalRotation = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseRotation = GetMouseRotation();

        verticalRotation -= mouseRotation.y; 
        verticalRotation = Mathf.Clamp(verticalRotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(verticalRotation,0f,0f);
        playerTransform.Rotate(Vector3.up * mouseRotation.x);
    }


    Vector2 GetMouseRotation(){

        Vector2 mouseRot = Vector2.zero;
        mouseRot.x = Input.GetAxis("Mouse X");
        mouseRot.y = Input.GetAxis("Mouse Y");

        return mouseRot * mouseSensitivity * Time.deltaTime;

    }
}
