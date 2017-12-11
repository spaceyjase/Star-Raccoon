using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnCollision : MonoBehaviour
{
  [SerializeField]
  private float damageAmount = 1.0f;
  [SerializeField]
  private float cooldownTime = 1.0f;

  private bool cooldown = false;

  private void OnCollisionEnter(Collision collision)
  {
    if (!cooldown)
    {
      cooldown = true;
      HealthManager.Instance.TakeDamage(damageAmount);
      Invoke(nameof(Uncool), cooldownTime);
    }
  }

  private void Uncool()
  {
    cooldown = false;
  }
}
