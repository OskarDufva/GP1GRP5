using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Movement 
    public float moveSpeed;
    public float zoomSpeed;

    // Zoom
    public float minZoomDist;
    public float maxZoomDist;

    // Rotation
    public float rotateSpeed;


    // Camera
    private Camera cam; 

    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Zoom();
    }

    // Adds camera movement with wasd and arrow keys
    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * zInput + transform.right * xInput;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    // Adds Zoom function for the scrollwheel
    void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float dist = Vector3.Distance(transform.position, cam.transform.position);

        
        if (dist < minZoomDist && scrollInput > 0.0f)
            return;
 
        else if (dist > maxZoomDist && scrollInput < 0.0f)
            return;

        cam.transform.position += cam.transform.forward * scrollInput * zoomSpeed;
    }

    public void FocusOnPosition(Vector3 pos)
    {
        transform.position = pos;
    }
}
