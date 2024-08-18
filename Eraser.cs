using UnityEngine;

public class Eraser : MonoBehaviour
{
  // ぶつかった時に呼ばれる関数 BoxCollider2Dが必要
  void OnTriggerEnter2D(Collider2D other)
  {
    // ぶつかったオブジェクトを削除
    Destroy(other.gameObject);
  }
}
