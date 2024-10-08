using UnityEngine;

public class Dish : MonoBehaviour
{
  [SerializeField] private float life_time = 5.0f;
  private Vector2 screen;
  private bool is_scored;
  private bool is_bounced;
  private bool is_UR;

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
    if (is_scored) return;
    MarkAsScored();
    score_sensor.GetComponent<ScoreSensor>().Score(is_UR);
  }
  public void SetDetail(bool _is_UR)
  {
    is_UR = _is_UR;
    if (_is_UR)
    {

      int type_UR = Random.Range(0, 2);
      gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sushi/sushiUR" + type_UR);
    }
    else
    {
      int type_SR = Random.Range(0, 6);
      gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sushi/sushiSR" + type_SR);
    }
  }
}
