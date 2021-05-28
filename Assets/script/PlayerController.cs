using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
  [SerializeField]
  float JUMP_VELOCITY = 200;

  Rigidbody2D _rigidbody;

  float _ceil;
  float _floor;

  void Start()
  {
    _rigidbody = GetComponent<Rigidbody2D>();
    _ceil = Camera.main.ViewportToWorldPoint(Vector2.one).y;
    _floor = Camera.main.ViewportToWorldPoint(Vector2.zero).y;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      _rigidbody.velocity = Vector2.zero;
      _rigidbody.AddForce(new Vector2(0, JUMP_VELOCITY));
    }
  }

  void FixedUpdate()
  {
    Vector3 pos = transform.position;
    float y = pos.y;

    if (y > _ceil)
    {
      _rigidbody.velocity = Vector2.zero;
      pos.y = _ceil;
    }
    if (y < _floor)
    {
      _rigidbody.velocity = Vector2.zero;
      _rigidbody.AddForce(new Vector2(0, JUMP_VELOCITY));
      pos.y = _floor;
    }

    transform.position = pos;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    // 衝突したので消滅
    Destroy(gameObject);
  }
}
