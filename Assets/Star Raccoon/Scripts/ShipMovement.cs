using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{
  [SerializeField]
  private float movementSpeed = 1.0f;
  [SerializeField]
  private float tilt = 1.0f;
  [SerializeField]
  private Boundary boundary;

  private Rigidbody rb;

  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
  }

  private void FixedUpdate()
  {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    rb.velocity += new Vector3(h, -v, 0) * movementSpeed * Time.deltaTime;

    rb.position = new Vector3(
      Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
      Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
      0.0f
    );

    rb.rotation = Quaternion.Euler(rb.velocity.y * tilt, rb.velocity.z * tilt * 10, rb.velocity.x * tilt);
  }
}
