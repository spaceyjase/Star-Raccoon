using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
  [SerializeField]
  private float speed = 1.0f;

  // Update is called once per frame
  private void Update()
  {
    transform.position += transform.forward * speed * Time.deltaTime;
  }
}
