using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBasedOnTargetPosition : MonoBehaviour
{
  [SerializeField]
  private GameObject target;

  private float lastTargetXPosition;
  private float lastTargetYPosition;
  private new Renderer renderer;

  private void Start()
  {
    lastTargetXPosition = target.transform.position.x;
    lastTargetXPosition = target.transform.position.z;
    renderer = GetComponent<Renderer>();
  }

  // Update is called once per frame
  void Update()
  {
    if (target != null)
    {
      float offsetX = (target.transform.position.x - lastTargetXPosition) / 10;  // plane units
      float offsetY = (target.transform.position.z - lastTargetYPosition) / 10; // plane units
      renderer.material.mainTextureOffset -= new Vector2(offsetX, offsetY);
      lastTargetXPosition = target.transform.position.x;
      lastTargetYPosition = target.transform.position.z;
    }
  }
}
