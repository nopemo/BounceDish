using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
  // ミラーの回転中心にあるEmptyObjectにアタッチ
  [SerializeField] private float rotate_speed = 1.0f;
  private bool is_game_over = false;

  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("Mirror is created");
  }

  // Update is called once per frame
  void Update()
  {
    // マウスの位置を取得
    if (is_game_over)
    {
      return;
    }
    Vector3 mousePosition = Input.mousePosition;

    mousePosition.z = 10f;

    // マウス位置をスクリーン座標からワールド座標に変換
    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

    // オブジェクトの位置からマウス位置へのベクトルを計算
    Vector2 direction = new Vector2(
        mousePosition.x,
        mousePosition.y
    );

    // ベクトルの角度を計算
    float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
    Rotate(angle);
    // Debug.Log(angle);
  }
  public void Rotate(float _angle)
  {
    transform.rotation = Quaternion.Euler(0, 0, _angle);
  }
  public void GameOver()
  {
    is_game_over = true;
  }
}
