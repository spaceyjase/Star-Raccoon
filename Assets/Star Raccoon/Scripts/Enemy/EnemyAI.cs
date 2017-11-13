using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
  [SerializeField]
  private GameObject player;
  [SerializeField]
  private float targetDistance = 10.0f;

  private void Update()
  {
    if ((player.transform.position - transform.position).magnitude < targetDistance)
    {
      Vector3 newPosition = transform.position;
      newPosition.z = player.transform.position.z + targetDistance;
      transform.position = newPosition;
      var newRotation = transform.rotation;
      newRotation.y = 0;
      transform.rotation = newRotation;
    }
  }
}
