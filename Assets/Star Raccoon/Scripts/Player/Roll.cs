using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
  [SerializeField]
  private float doubleTapDelay = 0.25f;
  [SerializeField]
  private float barrelRollDelay = 0.5f;

  public bool AllowedToBarrelRoll { get; private set; } = true;
  public bool DoubleTap { get; private set; }

  private void Update()
  {
    RollOnInput();
    BarrelRollOnInput();
  }

  private void BarrelRollOnInput()
  {
    if (Input.GetButtonDown("Roll") && AllowedToBarrelRoll)
    {
      if (DoubleTap)
      {
        StartCoroutine(nameof(DoBarrelRoll), Input.GetAxisRaw("Roll") > 0);
      }
      else
      {
        StartCoroutine(nameof(BarrelRollExpiry));
      }
    }
  }

  private IEnumerator BarrelRollExpiry()
  {
    DoubleTap = true;
    yield return new WaitForSeconds(doubleTapDelay);
    DoubleTap = false; // too late for barrel roll; reset double tap
    yield return null;
  }

  private void RollOnInput()
  {
    float h = Input.GetAxis("Roll");
    if (h < 0 || h > 0)
    {
      Vector3 rotation = transform.rotation.eulerAngles;
      rotation.z = -90 * h;
      transform.rotation = Quaternion.Euler(rotation);
    }
  }

  private IEnumerator DoBarrelRoll(bool right)
  {
    float t = 0.0f;

    Vector3 initialRotation = transform.rotation.eulerAngles;
    Vector3 goalRotation = initialRotation;

    goalRotation.z += (right ? -360 : 360);

    Vector3 currentRotation = initialRotation;

    float halfDuration = barrelRollDelay / 2.0f;
    while (t < halfDuration)
    {
      currentRotation.z = Mathf.Lerp(initialRotation.z, goalRotation.z, t / halfDuration);
      transform.rotation = Quaternion.Euler(currentRotation);
      t += Time.deltaTime;
      yield return null;
    }

    yield return null;
  }

  private IEnumerator AllowedToBarrelRollExpiry()
  {
    AllowedToBarrelRoll = false;
    yield return new WaitForSeconds(barrelRollDelay);
    AllowedToBarrelRoll = true;
    yield return null;
  }
}
