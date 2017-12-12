using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
  #region Singleton
  private static HealthManager instance = null;
  public static HealthManager Instance { get { return instance; } }

  private void Awake()
  {
    if (instance != null && instance != this)
    {
      Destroy(gameObject);
    }
    else
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
      gameObject.name = "$HealthManager";
    }
  }
  #endregion

  [SerializeField]
  private float maxHealth = 10f;
  [SerializeField]
  private Transform healthDisplay;

  private float currentHealth = 0f;
  private float CurrentHealth
  {
    get
    {
      return currentHealth;
    }
    set
    {
      currentHealth = value;
      UpdateUI();
    }
  }

  private float originalScale = 1.0f;

  private void UpdateUI()
  {
    healthDisplay.localScale = new Vector3(healthDisplay.localScale.x, originalScale * (currentHealth / maxHealth), healthDisplay.localScale.z);
  }

  // Use this for initialization
  private void Start()
  {
    CurrentHealth = maxHealth;
    originalScale = healthDisplay.localScale.y;
  }

  public void TakeDamage(float damage)
  {
    if (damage > 0)
    {
      CurrentHealth -= damage;
      if (CurrentHealth < 0f)
      {
        CurrentHealth = 0f;
        // TODO: Game Over logic/lose a life
      }
    }
  }

  public void RestoreHealth(float health)
  {
    if (health > 0)
    {
      CurrentHealth += health;
      if (CurrentHealth > maxHealth)
      {
        CurrentHealth = maxHealth;
      }
    }
  }
}
