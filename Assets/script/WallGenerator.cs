using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

  public GameObject wall;

  float _timer = 0;
  float _totalTime = 0;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    // ①経過時間を差し引く
    _timer -= Time.deltaTime;
    _totalTime += Time.deltaTime;
    if (_timer < 0)
    {
      // ②0になったのでBlock生成
      // ③BlockMgrの場所から生成
      Vector3 position = transform.position;
      //position.y += 50;
      // ④プレハブをもとにBlock生成
      GameObject obj = Instantiate(wall, position, Quaternion.identity);
      float speed = 5 + (_totalTime * 0.1f);
      obj.GetComponent<WallMotion>().SetSpeed(speed);
      // ⑤n秒後にまた生成する
      _timer = 2;
    }
  }
}
