using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

  public GameObject wall;

  private float timer = 0;

  void Start()
  {

  }

  void Update()
  {
    this.timer -= Time.deltaTime;
    if (this.timer < 0)
    {
      Vector3 position = this.transform.position;
      position.y += 1.1f * Mathf.Sin(Time.time) + Random.Range(-0.5f, 0.5f);
      GameObject obj = Instantiate(this.wall, position, Quaternion.identity);
      float speed = 5 + (Time.time * 0.1f);
      obj.GetComponent<WallMotion>().SetSpeed(speed);

      this.timer = 2;
    }
  }
}
