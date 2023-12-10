using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController: MonoBehaviour
{
    public float Speed = 0.3f;
    public float JumpForce = 1f;
    public float sensitivity = 5f;
    public float headMinY = -40f;
    public float headMaxY = 40f;
    public Transform head;
    private float rotationY;

    public LayerMask GroundLayer = 2; 

    private Rigidbody _rb;
    private CapsuleCollider _collider;
    private bool _isGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);


            return Physics.CheckCapsule(_collider.bounds.center, bottomCenterPoint, _collider.bounds.size.x / 2 * 0.9f, GroundLayer);
 
        }
    }

    private Vector3 _movementVector
    {
        get
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            return new Vector3(horizontal, 0.0f, vertical);
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();

        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        if (GroundLayer == gameObject.layer)
            Debug.LogError("Player SortingLayer must be different from Ground SourtingLayer!");
    }
void Update()
{
    float rotationX = head.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
    rotationY += Input.GetAxis("Mouse Y") * sensitivity;
    rotationY = Mathf.Clamp(rotationY, headMinY, headMaxY);
    head.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
}

void FixedUpdate()
    {
        JumpLogic();
        MoveLogic();
    }

    private void MoveLogic()
    {
        _rb.AddForce(_movementVector * Speed, ForceMode.Impulse);
    }

    private void JumpLogic()
    {
        if (_isGrounded && (Input.GetAxis("Jump") > 0))
        {
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}