using UnityEngine;
using UnityEngine.SceneManagement;
namespace SceneChanger
{
  public class SceneChanger
  {
    public void ChangeScene(string scene_name)
    {
      SceneManager.LoadScene(scene_name);
    }
    public void ReloadScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitScene()
    {
      SceneManager.LoadScene("Title");
    }
  }
}
