using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

  public GameObject wall;

  float _timer = 0;

  void Start()
  {

  }

  void Update()
  {
    _timer -= Time.deltaTime;
    if (_timer < 0)
    {
      Vector3 position = transform.position;
      position.y += 1.1f * Mathf.Sin(Time.time) + Random.Range(-0.5f, 0.5f);
      GameObject obj = Instantiate(wall, position, Quaternion.identity);
      float speed = 5 + (Time.time * 0.1f);
      obj.GetComponent<WallMotion>().SetSpeed(speed);

      _timer = 2;
    }
  }
}
