using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float speed;
    public float scrollspeed;
    public float minY;
    public float maxY;
    void Update()
    {
        //getting the floats of the axis
        float inputY = Input.GetAxis("Horizontal");
        float inputX = Input.GetAxis("Vertical");
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        //scrolling
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollspeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
        //movement
        transform.Translate(Vector3.forward * inputX * speed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * inputY * speed *  Time.deltaTime, Space.World);
    }
}
