using UnityEngine;
using unityroom.Api;

public class Result : MonoBehaviour
{
  [SerializeField] private GameObject last_score_text;
  [SerializeField] private GameObject background_canvas;
  [SerializeField] private GameObject mirror;
  void Start()
  {
    gameObject.GetComponent<Canvas>().enabled = false;
  }
  public void ShowResult(int _score)
  {
    // show the result
    Debug.Log("Your score is " + _score);
    gameObject.GetComponent<Canvas>().enabled = true;
    UnityroomApiClient.Instance.SendScore(1, _score, ScoreboardWriteMode.Always);
    last_score_text.GetComponent<UnityEngine.UI.Text>().text = _score.ToString();
    mirror.GetComponent<Mirror>().GameOver();
    // background_canvas.GetComponent<Canvas>().enabled = false;
    // stop the game time and physics
    Time.timeScale = 0;
  }
}
