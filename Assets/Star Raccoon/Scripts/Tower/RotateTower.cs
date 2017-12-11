using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTower : MonoBehaviour
{
  [SerializeField]
  private float rotationSpeed = 10.0f;

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(transform.up, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
  }
}
