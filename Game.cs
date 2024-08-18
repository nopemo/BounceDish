using UnityEngine;
using SceneChanger;

public class Game : MonoBehaviour
{
  [SerializeField] private GameObject dishes_maker;
  [SerializeField] private GameObject score_sensor;
  [SerializeField] private GameObject timer;
  [SerializeField] private GameObject score_text;
  private float restart_time;
  private bool is_reload_triggered;
  private int score;
  void Start()
  {
    Debug.Log("Game Start!");
    restart_time = 0;
    score = 0;
  }
  void CheckRestart()
  {
    if (Input.GetKeyDown(KeyCode.R) && restart_time == 0)
    {
      restart_time = Time.time;
      is_reload_triggered = false;
    }
    if (Input.GetKeyUp(KeyCode.R))
    {
      restart_time = 0;
      is_reload_triggered = false;
    }
    if (restart_time > 0 && Time.time - restart_time >= 1.0f && !is_reload_triggered)
    {
      SceneChanger.SceneChanger changer = new SceneChanger.SceneChanger();
      changer.ReloadScene();
      is_reload_triggered = true; // リロードが発動したことを示す
    }
  }
  // if the player presses "R" for 1 second, the game will restart
  void Update()
  {
    CheckRestart();
  }

  public void AddScore(int _score)
  {
    score += _score;
    Debug.Log("Score: " + score);
    score_text.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
  }
}
