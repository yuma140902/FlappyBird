using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMotion : MonoBehaviour
{
  private float speed = -5;

  private Rigidbody2D _rigidbody;
  private Vector2 velocity;
  private float left;

  void Start()
  {
    this._rigidbody = GetComponent<Rigidbody2D>();
    this.velocity = new Vector2(this.speed, 0);
    this.left = Camera.main.ViewportToWorldPoint(Vector2.zero).x;
  }

  void Update()
  {
    this._rigidbody.velocity = this.velocity;
    if (this.transform.position.x < this.left)
    {
      Destroy(this.gameObject); // 画面外に出たので消す.
    }
  }

  public void SetSpeed(float speed)
  {
    this.speed = -speed;
  }

  public void SetColor(Color color)
  {
    foreach (Renderer renderer in this.gameObject.GetComponentsInChildren<Renderer>())
    {
      renderer.material.color = color;
    }
  }
}
