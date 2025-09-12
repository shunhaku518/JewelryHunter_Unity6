using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("生成プレハブ/時間/速度/範囲")]
    public GameObject objPrefab;            //発生させるPrefabデータ
    public float delayTime = 3.0f;          //遅延時間
    public float fireSpeed = 4.0f;          //発射速度
    public float length = 8.0f;             //範囲

    [Header("発射口")]
    public Transform gateTransform;

    GameObject player;                      //プレイヤー
    float passedTimes = 0;                  //経過時間

    AudioSource audioSource;
    public AudioClip se_Shoot;

    //距離チェック
    bool CheckLength(Vector2 targetPos)
    {
        bool ret = false;
        float d = Vector2.Distance(transform.position, targetPos);
        if (length >= d)
        {
            ret = true;
        }
        return ret;
    }

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーを取得
        player = GameObject.FindGameObjectWithTag("Player");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(player != null) {return;}
        if (player != null)
        {
            //待機時間加算
            passedTimes += Time.deltaTime;
            //Playerとの距離チェック
            if (CheckLength(player.transform.position))
            {
                //待機時間経過
                if (passedTimes > delayTime)
                {
                    passedTimes = 0;        //時間を0にリセット
                                            //砲弾をプレハブから作る
                    Vector2 pos = new Vector2(gateTransform.position.x,
                        gateTransform.position.y);
                    GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);
                    //砲身が向いている方向に発射する
                    Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                    float angleZ = transform.localEulerAngles.z;
                    float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                    float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                    Vector2 v = new Vector2(x, y) * fireSpeed;
                    rbody.AddForce(v, ForceMode2D.Impulse);

                    audioSource.PlayOneShot(se_Shoot);
                }
            }
        }
    }
    //範囲表示
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, length);
    }
}
