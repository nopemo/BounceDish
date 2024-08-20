using UnityEngine;
using SceneChanger;
public class Quit : MonoBehaviour
{
  public void QuitGame()
  {
    Time.timeScale = 1;
    SceneChanger.SceneChanger scene_changer = new SceneChanger.SceneChanger();
    scene_changer.QuitScene();
  }
}
