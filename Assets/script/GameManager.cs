using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  private enum GameState
  {
    Loop,
    GameOver
  }

  private int score = 0;
  private GameState state = GameState.Loop;

  void Start()
  {

  }

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
    DrawScore();

    float CenterX = Screen.width / 2;
    float CenterY = Screen.height / 2;
    if (this.state == GameState.GameOver)
    {
      DrawGameOver(CenterX, CenterY);
      if (DrawRetryButton(CenterX, CenterY))
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
      if (DrawReturnToTitleButton(CenterX, CenterY))
      {
        SceneManager.LoadScene(0);
      }
    }
  }

  void DrawGameOver(float CenterX, float CenterY)
  {
    GUI.skin.label.alignment = TextAnchor.MiddleCenter;
    float w = 400;
    float h = 100;
    Rect position = new Rect(CenterX - w / 2, CenterY - h / 2, w, h);
    GUI.Label(position, "GAME OVER");
  }

  bool DrawRetryButton(float CenterX, float CenterY)
  {
    float ofsY = 30;
    float w = 120;
    float h = 32;
    Rect rect = new Rect(CenterX - w / 2, CenterY + ofsY, w, h);
    return GUI.Button(rect, "RETRY");
  }

  bool DrawReturnToTitleButton(float CenterX, float CenterY)
  {
    float ofsY = 80;
    float w = 120;
    float h = 32;
    Rect rect = new Rect(CenterX - w / 2, CenterY + ofsY, w, h);
    return GUI.Button(rect, "TITLE");
  }

  void DrawScore()
  {
    GUI.skin.label.fontSize = 32;
    GUI.skin.label.alignment = TextAnchor.MiddleLeft;
    Rect position = new Rect(8, 8, 400, 100);
    GUI.Label(position, string.Format("score:{0}", this.score));
  }
}
