using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  private enum GameState
  {
    Loop,
    GameOver
  }

  private int score = 0;
  private GameState state = GameState.Loop;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void FixedUpdate()
  {
    if (this.state == GameState.Loop)
    {
      ++this.score;
    }
  }

  public void SetGameOver()
  {
    this.state = GameState.GameOver;
  }

  private void OnGUI()
  {
    // スコアを描画
    DrawScore();

    float CenterX = Screen.width / 2;
    float CenterY = Screen.height / 2;
    if (this.state == GameState.GameOver)
    {
      // ⑥ゲームオーバーの描画
      DrawGameOver(CenterX, CenterY);
    }
  }

  void DrawGameOver(float CenterX, float CenterY)
  {
    // 中央揃え
    GUI.skin.label.alignment = TextAnchor.MiddleCenter;
    float w = 400;
    float h = 100;
    Rect position = new Rect(CenterX - w / 2, CenterY - h / 2, w, h);
    GUI.Label(position, "GAME OVER");
  }

  // スコアの描画
  void DrawScore()
  {
    GUI.skin.label.fontSize = 32;
    GUI.skin.label.alignment = TextAnchor.MiddleLeft;
    Rect position = new Rect(8, 8, 400, 100);
    GUI.Label(position, string.Format("score:{0}", this.score));
  }
}
