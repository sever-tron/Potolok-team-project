using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door: MonoBehaviour
{
    public float speed;
    private Rigidbody rb;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        bool q = Input.GetKey(KeyCode.Q);

        if (q)
        {
            Vector3 tempVect = new Vector3(1, 0, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
    }
}