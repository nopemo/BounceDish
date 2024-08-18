using UnityEngine;
using SceneChanger;

public class Restart : MonoBehaviour
{
  // button to restart the game
  public void RestartGame()
  {
    // reload the current scene
    SceneChanger.SceneChanger scene_changer = new SceneChanger.SceneChanger();
    scene_changer.ReloadScene();
  }
}
