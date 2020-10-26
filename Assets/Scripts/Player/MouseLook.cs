using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] Transform playerTransform;

    float verticalRotation = 0f;
    float horizontalRotation = 0f;
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector2 mouseRotation = GetMouseRotation();

        verticalRotation -= mouseRotation.y; 
        verticalRotation = Mathf.Clamp(verticalRotation,-90f,90f);
        horizontalRotation += mouseRotation.x;

        transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
        playerTransform.eulerAngles = new Vector3(playerTransform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y, playerTransform.rotation.eulerAngles.z);
       // playerTransform.Rotate(Vector3.up * mouseRotation.x);
        transform.position = playerTransform.position + Vector3.up * 1.5f;

        //transform.position = playerTransform.position + Vector3.up ;
    }


    Vector2 GetMouseRotation(){

        Vector2 mouseRot = Vector2.zero;
        mouseRot.x = Input.GetAxis("Mouse X");
        mouseRot.y = Input.GetAxis("Mouse Y");

        return mouseRot * mouseSensitivity * Time.deltaTime;

    }
}
