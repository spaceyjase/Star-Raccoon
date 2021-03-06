﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{
  [SerializeField]
  private float movementSpeed = 1.0f;
  [SerializeField]
  private float slowRate = 0.98f;
  [SerializeField]
  private float tilt = 1.0f;
  [SerializeField]
  private bool invertY = true;
  [SerializeField]
  private float spin = 2.0f;
  [SerializeField]
  private Boundary boundary;

  private Rigidbody rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    Messenger<int>.AddListener("Level Changed", OnLevelChanged);
  }

  private void OnDestroy()
  {
    Messenger<int>.RemoveListener("Level Changed", OnLevelChanged);
  }

  private void OnLevelChanged(int level)
  {
    Debug.Log("New level (" + level +")!");
  }

  private void FixedUpdate()
  {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    if (h == 0f)
    {
      h = -rb.velocity.x * slowRate;
    }
    if (v == 0f)
    {
      v = invertY ? rb.velocity.y : -rb.velocity.y * slowRate;
    }
    rb.velocity += new Vector3(h, invertY ? -v : v, 0.0f) * movementSpeed * Time.deltaTime;

    rb.position = new Vector3(
      Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
      Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
      rb.position.z
    );

    rb.rotation = Quaternion.Euler(rb.velocity.y * tilt, -rb.velocity.x * tilt * spin, rb.velocity.x * tilt);
  }
}
