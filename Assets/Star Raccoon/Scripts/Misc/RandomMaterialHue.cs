using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialHue : MonoBehaviour
{
  [SerializeField]
  private Material[] materialsToChange;
  [SerializeField]
  private float saturation = 1.0f;
  [SerializeField]
  private float brightness = 1.0f;
  [SerializeField]
  private float alpha = 1.0f;

  private void Update()
  {
    HSBColor newColour = new HSBColor(Random.value, saturation, brightness, alpha);
    foreach (Material material in materialsToChange)
    {
      material.color = newColour.ToColor();
    }
  }
}
