using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreOnTriggerEnter : MonoBehaviour
{
  [SerializeField]
  private int value = 100;

  private void OnTriggerEnter(Collider other)
  {
    ScoreManager.Instance.AddScore(value);
  }
}
