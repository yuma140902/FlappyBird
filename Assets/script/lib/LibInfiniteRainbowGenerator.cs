using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibInfiniteRainbowGenerator
{

  private Color[] colors;
  private int index = 0;
  private int steps;

  public LibInfiniteRainbowGenerator(int steps)
  {
    this.steps = steps;
    this.colors = new Color[steps];
    float hue = 0.0f;
    float hue_step = 1.0f / steps;
    for (int i = 0; i < steps; ++i)
    {
      colors[i] = Color.HSVToRGB(hue, 0.5f, 1.0f);
      hue += hue_step;
    }
  }

  public Color Next()
  {
    Color color = this.colors[this.index];
    ++this.index;
    if (this.index >= this.steps)
    {
      this.index = 0;
    }
    return color;
  }
}
