using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Open : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        bool h = Input.GetKey(KeyCode.H);

        if (h)
        {
            Vector3 tempVect = new Vector3(0, 0, 1);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
    }
}
