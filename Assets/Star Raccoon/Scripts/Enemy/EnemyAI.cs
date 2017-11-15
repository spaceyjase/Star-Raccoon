using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
  [SerializeField]
  private GameObject player;
  [SerializeField]
  private float targetDistance = 10.0f;
  [SerializeField]
  private float enemySpeed = 0.0f;

  private void LateUpdate()
  {
    Vector3 projection = Vector3.Project(player.transform.position - transform.position, player.transform.forward);
    if (projection.magnitude <= targetDistance)
    {
      transform.position += Vector3.Project((player.transform.position - transform.position).normalized * targetDistance,
        player.transform.forward) - projection;

      //Vector3 newPosition = transform.position;
      //newPosition.z = player.transform.position.z + targetDistance;
      //transform.position = newPosition;
      //var newRotation = transform.rotation;
      //newRotation.y = 0;
      //transform.rotation = newRotation;
    }
    else
    {
      transform.position += transform.forward * enemySpeed * Time.deltaTime;
    }
  }
}
