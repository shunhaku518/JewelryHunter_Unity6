using UnityEngine;

public class ShellController : MonoBehaviour
{
    [Header("生存時間")]
    public float deleteTime = 3.0f; // 削除する時間指定

    void Start()
    {
        Destroy(gameObject, deleteTime); // 削除設定
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); // 何かに接触したら消す
    }
}
