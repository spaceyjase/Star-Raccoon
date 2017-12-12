using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnTrigger : MonoBehaviour
{
  [SerializeField]
  private float damageAmount = 1.0f;
  [SerializeField]
  private float cooldownTime = 1.0f;
  [SerializeField]
  private string collisionTag = "Player";

  private bool cooldown = false;

  private void OnTriggerEnter(Collider other)
  {
    if (!cooldown && other.tag == collisionTag)
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
