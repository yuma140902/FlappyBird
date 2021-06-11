using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

  public GameObject wall;

  private float timer = 0;

  private float timeSpend = 0;

  private LibInfiniteRainbowGenerator rainbow = new LibInfiniteRainbowGenerator(10);

  void Start()
  {

  }

  void Update()
  {
    this.timer -= Time.deltaTime;
    this.timeSpend += Time.deltaTime;

    if (this.timer < 0)
    {

      Vector3 position = this.transform.position;
      position.y += 1.1f * Mathf.Sin(this.timeSpend) + UnityEngine.Random.Range(-1.2f, 1.2f);
      GameObject obj = Instantiate(this.wall, position, Quaternion.identity);
      float speed = 5 + (this.timeSpend * 0.1f);
      WallMotion wall = obj.GetComponent<WallMotion>();
      wall.SetSpeed(speed);
      wall.SetColor(this.rainbow.Next());

      this.timer = Math.Max(2 - (this.timeSpend * 0.06f), 0.2f);
    }
  }
}
