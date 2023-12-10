using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cube: MonoBehaviour
{
    public float speed;
    private Rigidbody rb;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        bool w = Input.GetKey(KeyCode.W);

        if (w)
        {
            Vector3 tempVect = new Vector3(0, 1, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
        bool s = Input.GetKey(KeyCode.S);

        if (s)
        {
            Vector3 tempVect2 = new Vector3(0, -1, 0);
            tempVect2 = tempVect2.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect2);
        }
        bool a = Input.GetKey(KeyCode.A);

        if (a)
        {
            Vector3 tempVect3 = new Vector3(-1, 0, 0);
            tempVect3 = tempVect3.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect3);
        }
        bool d = Input.GetKey(KeyCode.D);

        if (d)
        {
            Vector3 tempVect4 = new Vector3(1, 0, 0);
            tempVect4 = tempVect4.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect4);
        }
    }
}