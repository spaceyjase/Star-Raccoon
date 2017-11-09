using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  [SerializeField]
  private int[] levelScoreThresholds;

  private int currentLevel = 0;

  private int score = 0;

  #region Singleton
  private static ScoreManager instance;
  public static ScoreManager Instance { get { return instance; } }
  #endregion

  private void Awake()  {    if (instance == null)    {      instance = this;    }    else    {      if (instance != this)      {        Destroy(gameObject);      }    }  }  private void OnGUI()
  {
    GUILayout.Label("Score: " + ScoreManager.Instance.score.ToString("D6"));
  }

  private void Update()
  {
    if (instance.score >= levelScoreThresholds[currentLevel])
    { // handle game state here
      // TODO: move somewhere sensible, e.g. GameManager
      currentLevel++;
      // transition to new level
      Messenger<int>.Broadcast("Level Changed", currentLevel);
    }
  }

  public void AddScore(int value)
  {
    Instance.score += value;
  }

}
