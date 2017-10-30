using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
  private void Update()
  {
    float h = Input.GetAxis("Roll");
    var rotation = transform.rotation.eulerAngles;
    rotation.z = -90 * h;
    transform.rotation = Quaternion.Euler(rotation);
  }
}
