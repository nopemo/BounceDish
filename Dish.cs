using UnityEngine;

public class Dish : MonoBehaviour
{
  [SerializeField] private float life_time = 5.0f;
  private Vector2 screen;
  private bool is_scored;
  private bool is_bounced;

  void Start()
  {
    Destroy(gameObject, life_time);
    screen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    is_scored = false;
    is_bounced = false;
  }
  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log(other.gameObject.tag);
    if (other.gameObject.tag == "Mirror")
    {
      MarkAsBounced();
    }
  }
  public void MarkAsScored()
  {
    if (!is_scored)
    {
      is_scored = true;
      Debug.Log("Score!");
    }
  }
  public void MarkAsBounced()
  {
    if (!is_bounced)
    {
      is_bounced = true;
      Debug.Log("Bounce!");
    }
  }
  public void Score(GameObject score_sensor)
  {
    if (!is_bounced) return;
    MarkAsScored();
    score_sensor.GetComponent<ScoreSensor>().Score(transform);
  }
}
