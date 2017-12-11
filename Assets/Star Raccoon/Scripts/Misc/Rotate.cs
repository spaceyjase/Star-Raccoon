using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
  [SerializeField]
  private float rotationSpeed = 30.0f;
  [SerializeField]
  private Vector3 axis = Vector3.forward;

  private void Update()
  {
    transform.Rotate(axis, rotationSpeed * Mathf.Deg2Rad * Time.deltaTime);
  }
}
