﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  private int score = 0;

  // Singleton
  private static ScoreManager instance;
  public static ScoreManager Instance { get { return instance; } }

  private void Awake()
  {
    Instance.score += value;
  }
  private void OnGUI()
  {
    GUILayout.Label("Score: " + ScoreManager.Instance.score.ToString("D6"));
  }
}