using UnityEngine;
using SceneChanger;
using System.Collections;
using UnityEngine.UI;


public class StartButton : MonoBehaviour
{
  [SerializeField] private GameObject title_sushi;
  [SerializeField] private GameObject white_image;
  void Start()
  {
    Debug.Log("Start Start!");
    bool is_UR = Random.Range(0, 10) == 0;
    string sushi_name = is_UR ? "sushiUR" : "sushiSR";
    if (is_UR)
    {
      sushi_name += Random.Range(0, 2);
    }
    else
    {
      sushi_name += Random.Range(0, 6);
    }
    title_sushi.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sushi/" + sushi_name);
  }
  public void StartAnimation()
  {
    StartCoroutine(StartAnimationCoroutine());
  }
  public void StartGame()
  {
    // load the game scene
    Time.timeScale = 1;
    SceneChanger.SceneChanger scene_changer = new SceneChanger.SceneChanger();
    scene_changer.ChangeScene("Game");
  }
  IEnumerator StartAnimationCoroutine()
  {
    // activate the title sushi's animation trigger
    title_sushi.GetComponent<Animator>().SetTrigger("EvokeTitleSushi");
    white_image.GetComponent<Animator>().SetTrigger("EvokeWhiteout");
    yield return new WaitForSeconds(1.5f);
    StartGame();
  }
}
