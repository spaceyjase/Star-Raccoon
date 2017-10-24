using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
  [SerializeField]
  private float movementSpeed = 1.0f;

  private void Update()
  {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    transform.position += new Vector3(h, -v, 0) * movementSpeed * Time.deltaTime;
  }
}
