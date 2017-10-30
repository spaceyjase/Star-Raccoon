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

  private float doubleTapTime = 0.0f;

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
        DoBarrelRoll();
      }
      else
      {
        StartCoroutine(nameof(BarrelRollExpiry));
      }
    }
    doubleTapTime = Time.time;
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
    var rotation = transform.rotation.eulerAngles;
    rotation.z = -90 * h;
    transform.rotation = Quaternion.Euler(rotation);
  }

  private void DoBarrelRoll()
  {
    Debug.Log("Do a barrel roll!");
    StartCoroutine(nameof(AllowedToBarrelRollExpiry));
    DoubleTap = false;
  }

  private IEnumerator AllowedToBarrelRollExpiry()
  {
    AllowedToBarrelRoll = false;
    yield return new WaitForSeconds(barrelRollDelay);
    AllowedToBarrelRoll = true;
    yield return null;
  }
}
