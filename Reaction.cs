using UnityEngine;
using UnityEngine.UI;
public class Reaction : MonoBehaviour
{
  public void ShowReaction(string _reaction)
  {
    gameObject.GetComponent<Text>().text = _reaction;
    if (_reaction == "Excellent!!")
    {
      gameObject.GetComponent<Text>().color = new Color(1, 0, 0);
    }
    else if (_reaction == "Great!")
    {
      gameObject.GetComponent<Text>().color = new Color(0.9f, 0.5f, 0f);
    }
    else if (_reaction == "Good")
    {
      gameObject.GetComponent<Text>().color = new Color(0f, 0.6f, 0.6f);
    }
  }
}
