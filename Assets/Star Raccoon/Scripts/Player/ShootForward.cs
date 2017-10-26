using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForward : MonoBehaviour
{
  [SerializeField]
  private Rigidbody bulletPrefab;
  [SerializeField]
  private float velocity = 100f;
  [SerializeField]
  private float attackDelay = 0.25f;
  [SerializeField]
  private Transform laserOrigin;

  private float lastAttackTime = 0.0f;

  private void Update()
  {
    if (Input.GetButtonDown("Fire1") && Time.time - lastAttackTime > attackDelay)
    {
      Fire();
    }
  }

  private void Fire()
  {
    Rigidbody bulletClone = Instantiate(bulletPrefab, laserOrigin.transform.position, laserOrigin.transform.rotation);
    bulletClone.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
    lastAttackTime = Time.time;
    Destroy(bulletClone.gameObject, 3f);
  }
}
