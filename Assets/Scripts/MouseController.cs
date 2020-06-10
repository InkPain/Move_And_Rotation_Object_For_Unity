using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    #region Variables

    private Quaternion rotation;
    private float angleX;
    private float currentAngleX;
    private float velocityCurrntAngeX;
    private float angleY;
    private float currentAngleY;
    private float velocityCurrntAngeY;
    public float speedMouse = 1f;
    public float delyMouseRotation = 0.1f;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MouseRotation();
    }

    /// <summary>
    /// Method for rotating a character with a mouse
    /// </summary>
    private void MouseRotation()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            angleX += Input.GetAxis("Mouse X") * speedMouse;
            //angleX = Mathf.Clamp(angleX, -30, 30); //if you need to limit mouse movement on this axis
            currentAngleX = Mathf.SmoothDamp(currentAngleX, angleX, ref velocityCurrntAngeX, delyMouseRotation);
            Quaternion rotationX = Quaternion.AngleAxis(currentAngleX, Vector3.up);

            angleY += Input.GetAxis("Mouse Y") * speedMouse;
            //angleY = Mathf.Clamp(angleY, -30, 30); //if you need to limit mouse movement on this axis
            currentAngleY = Mathf.SmoothDamp(currentAngleY, angleY, ref velocityCurrntAngeY, delyMouseRotation);
            Quaternion rotationY = Quaternion.AngleAxis(-currentAngleY, Vector3.right);

            transform.rotation = rotation * rotationX * rotationY;
        }
    }
}
