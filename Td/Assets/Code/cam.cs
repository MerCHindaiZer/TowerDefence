using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotationX = 45.0f;
    public float ScrollSpeed;
    public float speed = 5f;
    float mainSpeed = 100.0f; //regular speed
    float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    float maxShift = 1000.0f; //Maximum speed when holdin gshift
    private float totalRun = 1.0f;
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            }
            else
            {
                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                float rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
        Vector3 p = GetBaseInput();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            totalRun += Time.deltaTime;
            p = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else
        {
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
        }

        p = p * Time.deltaTime;
        Vector3 newPosition = transform.position;
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
        else
        {
            transform.Translate(p);
        }
    }
    private Vector3 GetBaseInput()
    {
        Vector3 p_Velocity = new Vector3();
        if (Input.mousePosition.y > 600 && !Input.GetMouseButton(1))
        {
            p_Velocity += new Vector3(0, 1, 1);
        }
        if (Input.mousePosition.y < 300 && !Input.GetMouseButton(1))
        {
            p_Velocity += new Vector3(0, -1, -1);
        }
        if (Input.mousePosition.x < 300 && !Input.GetMouseButton(1))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.mousePosition.x > 900 && !Input.GetMouseButton(1))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Move(new Vector3(0, -1, 1) * ScrollSpeed);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            Move(new Vector3(0, 1, -1) * ScrollSpeed);
        }

        return p_Velocity;
    }
    void Move(Vector3 to)
    {
        if (transform.rotation.x != 90 && transform.rotation.x != 280 && transform.rotation.y != 90)
            transform.Translate(to);

    }
};
