using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMouseController : MonoBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 };
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityX = 2f;
    public float sensitivityY = 2f;
    
    public float minimumY = -90f;
    public float maximumY = 90f;
    public float minimumX = -360f;
    public float maximumX = 360f;

    float rotationY = -60f;

   

    // Update is called once per frame
    void Update()
    {
        MouseInput();
    }


    void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
        }
        else if (Input.GetMouseButtonDown(1))
        {
            MouseRightClick();
        }
        else if (Input.GetMouseButtonDown(2))
        {
            MouseMiddleButtonClicked();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            ShowAndUnlockCursor();
        }
        else if (Input.GetMouseButtonUp(2))
        {
            ShowAndUnlockCursor();
        }
    }
    void HideAndLockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void ShowAndUnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Move camera with middle mouse button
    void MouseMiddleButtonClicked()
    {
        HideAndLockCursor();
        Vector3 NewPosition = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
        Vector3 pos = transform.position;

        if (NewPosition.x > 0.0f)
        {
            pos += transform.right;
        }
        if (NewPosition.x < 0.0f)
        {
            pos -= transform.right;
        }
        if (NewPosition.z > 0.0f)
        {
            pos += transform.forward;
        }
        if (NewPosition.z < 0.0f)
        {
            pos -= transform.forward;
        }

        pos.y = transform.position.y;
        transform.position = pos;
    }


    // rotate on the Y axes with right mouse button
    void MouseRightClick()
    {
        HideAndLockCursor();

        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(0, rotationX, 0);
        }

        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }

        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

}
