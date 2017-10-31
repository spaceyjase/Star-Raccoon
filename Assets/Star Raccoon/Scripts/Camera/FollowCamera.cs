using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
  [SerializeField]
  private Vector3 defaultDistance = new Vector3(0f, 1f, -3.5f);
  [SerializeField]
  private float distanceDampening = 10f;
  [SerializeField]
  private Transform target;

  private Vector3 velocity = Vector3.one;

  private void LateUpdate()
  {
    if (target != null)
    {
      Vector3 toPosition = target.position + (target.rotation * defaultDistance);
      transform.position = Vector3.SmoothDamp(transform.position, toPosition, ref velocity, distanceDampening);
    }
  }
}
