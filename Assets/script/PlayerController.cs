using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
  [SerializeField]
  float JUMP_VELOCITY = 200;

  private Rigidbody2D _rigidbody;

  private float ceil;
  private float floor;

  void Start()
  {
    this._rigidbody = GetComponent<Rigidbody2D>();
    this.ceil = Camera.main.ViewportToWorldPoint(Vector2.one).y;
    this.floor = Camera.main.ViewportToWorldPoint(Vector2.zero).y;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      this._rigidbody.velocity = Vector2.zero;
      this._rigidbody.AddForce(new Vector2(0, JUMP_VELOCITY));
    }
  }

  void FixedUpdate()
  {
    Vector3 pos = transform.position;
    float y = pos.y;

    if (y > ceil)
    {
      this._rigidbody.velocity = Vector2.zero;
      pos.y = ceil;
    }
    if (y < floor)
    {
      this._rigidbody.velocity = Vector2.zero;
      this._rigidbody.AddForce(new Vector2(0, JUMP_VELOCITY));
      pos.y = floor;
    }

    this.transform.position = pos;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    // 衝突したので消滅
    Destroy(this.gameObject);
  }
}
