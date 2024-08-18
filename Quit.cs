using UnityEngine;
using SceneChanger;
public class Quit : MonoBehaviour
{
  public void QuitGame()
  {
    SceneChanger.SceneChanger scene_changer = new SceneChanger.SceneChanger();
    scene_changer.QuitScene();
  }
}
