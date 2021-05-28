using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMotion : MonoBehaviour
{
  float _speed = -5;

  Rigidbody2D _rigidbody;
  Vector2 velocity;
  float _left;

  // Start is called before the first frame update
  void Start()
  {
    _rigidbody = GetComponent<Rigidbody2D>();
    velocity = new Vector2(_speed, 0);
    _left = Camera.main.ViewportToWorldPoint(-Vector2.one).x;
  }

  // Update is called once per frame
  void Update()
  {
    _rigidbody.velocity = velocity;
    if (transform.position.x < _left)
    {
      Destroy(gameObject); // 画面外に出たので消す.
    }
  }

  public void SetSpeed(float speed)
  {
    _speed = -speed;
  }
}
