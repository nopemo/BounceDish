using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoreSensor : MonoBehaviour
{
  [SerializeField] private int score;
  [SerializeField] private GameObject game;
  public void Score(bool _is_UR)
  {
    int _score;
    if (_is_UR)
    {
      _score = score * 2;
    }
    else
    {
      _score = score;
    }
    game.GetComponent<Game>().AddScore(_score);
  }
  void OnTriggerEnter2D(Collider2D other)
  {
    other.GetComponent<Dish>().Score(gameObject);
  }
}
