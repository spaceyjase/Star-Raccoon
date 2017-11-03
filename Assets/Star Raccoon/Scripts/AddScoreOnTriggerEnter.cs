using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreOnTriggerEnter : MonoBehaviour
{
  [SerializeField]
  private int value = 100;

  private bool scored = false;

  private void OnTriggerEnter(Collider other)
  {
    if (!scored)
    {
      ScoreManager.Instance.AddScore(value);
      scored = true;
    }
  }
}
