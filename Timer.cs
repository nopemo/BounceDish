using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  private float start_time;
  private bool is_countdown_finished;
  [SerializeField] private float total_time = 30.0f;
  [SerializeField] private GameObject _ready;
  [SerializeField] private GameObject _go;

  [SerializeField] private GameObject _countdown_canvas;
  [SerializeField] private GameObject _normal_timer_bg;
  [SerializeField] private GameObject _emergency_timer_bg;
  [SerializeField] private GameObject _timer_arrow;


  void Start()
  {
    Debug.Log("Timer Start!");
    _ready.GetComponent<Image>().enabled = false;
    _go.GetComponent<Image>().enabled = false;
    _countdown_canvas.GetComponent<Canvas>().enabled = false;
    _normal_timer_bg.GetComponent<Image>().enabled = true;
    _emergency_timer_bg.GetComponent<Image>().enabled = false;
    is_countdown_finished = false;
    StartCountdown();
    StartTimer();
  }
  public void StartCountdown()
  {
    StartCoroutine(CountdownCoroutine());
  }
  public void StartTimer()
  {
    StartCoroutine(TimerCoroutine());
  }

  IEnumerator CountdownCoroutine()
  {
    _countdown_canvas.GetComponent<Canvas>().enabled = true;

    _ready.GetComponent<Image>().enabled = true;
    yield return new WaitForSeconds(1.0f);
    _ready.GetComponent<Image>().enabled = false;

    _go.GetComponent<Image>().enabled = true;
    yield return new WaitForSeconds(1.0f);
    _go.GetComponent<Image>().enabled = false;

    _countdown_canvas.GetComponent<Canvas>().enabled = false;

    start_time = Time.time;
    is_countdown_finished = true;
    yield return null;
  }
  IEnumerator TimerCoroutine()
  {
    while (true)
    {
      if (!is_countdown_finished)
      {
        yield return null;
        continue;
      }
      float elapsed_time = Time.time - start_time;
      float remaining_time = total_time - elapsed_time;
      if (remaining_time <= 0)
      {
        Debug.Log("Time Over!");
        break;
      }
      if (remaining_time <= 5.0f)
      {
        _normal_timer_bg.GetComponent<Image>().enabled = false;
        _emergency_timer_bg.GetComponent<Image>().enabled = true;
      }
      _timer_arrow.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, -360 * elapsed_time / 30.0f);
      yield return null;
    }
  }

}
