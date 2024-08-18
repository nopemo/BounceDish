using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class FloatIntPair
{
  public float height;
  public int score;
}
public class ScoreSensor : MonoBehaviour
{
  private int score;
  // floatとintのセットをリストに保管
  [SerializeField] private List<FloatIntPair> score_table;
  [SerializeField] private Text score_text;

  void Start()
  {
    score_table.Sort((a, b) => a.height.CompareTo(b.height));
  }

  public void Score(Transform _transform)
  {
    // debug
    Debug.Log(_transform.position.y);
    foreach (var pair in score_table)
    {
      if (_transform.position.y < pair.height)
      {
        score += pair.score;
        break;
      }
    }
    score_text.text = score.ToString();
  }
  void OnTriggerEnter2D(Collider2D other)
  {
    other.GetComponent<Dish>().Score(gameObject);
  }
}
