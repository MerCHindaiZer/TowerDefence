using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed;
    public float ScrollSpeed;
    public Transform target;
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)

    void Move(Vector3 to)
    {
       if(transform.rotation.x != 90 && transform.rotation.x != 280 && transform.rotation.y != 90)
        transform.Translate(to * speed);

    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(message:Input.mousePosition);

        Move(GetBaseInput());
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Move(new Vector3(0, -1, 1) * ScrollSpeed);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            Move(new Vector3(0, 1, -1) * ScrollSpeed);
        }
        if (Input.GetMouseButton(2))
        {

        }

    }
    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.mousePosition.x < 900 && !Input.GetMouseButton(2))
        {
            p_Velocity += new Vector3(-0.1f, 0, 0);
        }
        if (Input.mousePosition.x > 300 && !Input.GetMouseButton(2))
        {
            p_Velocity += new Vector3(0.1f, 0, 0);
        }
        if (Input.mousePosition.y < 30 && !Input.GetMouseButton(2))
        {
            p_Velocity += new Vector3(0, -0.1f, -0.1f);
        }
        if (Input.mousePosition.y > 670 && !Input.GetMouseButton(2))
        {
            p_Velocity += new Vector3(0, 0.1f, 0.1f);
        }
        return p_Velocity;
    }
}
