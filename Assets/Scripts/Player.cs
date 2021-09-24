using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    public event Action OnCoinCollected;

    public bool grounded;
    public int coinCount;

    private Rigidbody rb;
    float jumpForce = 7f;

    public float moveSpeed = 10f;

    Vector3 velocity;

    private void Start()
    {
        grounded = true;
        rb = GetComponent<Rigidbody>();

    }

    public void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(h, 0, v);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        float speed = inputMagnitude * moveSpeed;
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        velocity = movementDirection * speed;

        transform.Translate(velocity * Time.deltaTime);

        if (grounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }

    }

    private void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.CompareTag("Coin"))
        {
            Destroy(triggerCollider.gameObject);
            OnCoinCollected?.Invoke();
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }

}