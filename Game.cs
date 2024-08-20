using UnityEngine;
using SceneChanger;

public class Game : MonoBehaviour
{
  [SerializeField] private GameObject dishes_maker;
  [SerializeField] private GameObject score_sensor;
  [SerializeField] private GameObject timer;
  [SerializeField] private GameObject score_text;
  [SerializeField] private GameObject result_canvas;
  [SerializeField] private GameObject reaction;
  [SerializeField] private GameObject background_canvas;
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
    if (_score == 1 || _score == 2)
    {
      // BackGroundCanvasの子要素として生成
      GameObject _reaction = Instantiate(reaction, new Vector3(0, 88, 0), Quaternion.identity);
      // _reaction を BackGroundCanvas (bg) の子要素として設定
      _reaction.transform.SetParent(background_canvas.transform, false);
      // _reaction を一番前面に配置
      _reaction.transform.SetAsLastSibling();
      _reaction.GetComponent<Reaction>().ShowReaction("Good");
    }
    else if (_score == 3 || _score == 6)
    {
      GameObject _reaction = Instantiate(reaction, new Vector3(0, 88, 0), Quaternion.identity);
      // _reaction を BackGroundCanvas (bg) の子要素として設定
      _reaction.transform.SetParent(background_canvas.transform, false);
      // _reaction を一番前面に配置
      _reaction.transform.SetAsLastSibling();
      _reaction.GetComponent<Reaction>().ShowReaction("Great!");
    }
    else if (_score == 7 || _score == 14)
    {
      GameObject _reaction = Instantiate(reaction, new Vector3(0, 88, 0), Quaternion.identity);
      // _reaction を BackGroundCanvas (bg) の子要素として設定
      _reaction.transform.SetParent(background_canvas.transform, false);
      // _reaction を一番前面に配置
      _reaction.transform.SetAsLastSibling();
      _reaction.GetComponent<Reaction>().ShowReaction("Excellent!!");
    }
    Debug.Log("Score: " + score);
    score_text.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
  }
  public void GameOver()
  {
    Debug.Log("Game Over!");
    result_canvas.GetComponent<Result>().ShowResult(score);
  }
}
