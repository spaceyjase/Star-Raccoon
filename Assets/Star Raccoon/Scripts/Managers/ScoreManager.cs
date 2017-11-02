using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  private int score = 0;

  // Singleton
  private static ScoreManager instance;
  public static ScoreManager Instance { get { return instance; } }

  private void Awake()  {    if (instance == null)    {      instance = this;    }    else    {      if (instance != this)      {        Destroy(gameObject);      }    }  }  public void AddScore(int value)
  {
    Instance.score += value;
  }
  private void OnGUI()
  {
    GUILayout.Label("Score: " + ScoreManager.Instance.score.ToString("D6"));
  }
}
