using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("プレイヤーの能力値")]
    public float speed = 3.0f; //プレイヤーのスピードを調整
    public float jumpPower = 9.0f;  //ジャンプ力

    [Header("地面判定の対象レイヤー")]
　　public LayerMask groundLayer ;


    Rigidbody2D rbody; //PlayerについているRigidbody2Dを扱うための変数
    float axisH; //入力の方向を記憶するための変数
    bool goJump = false;  //ジャンプフラグ（true:真 on ,  false:偽 off）
    bool onGround = false; //地面にいるかどうかの判定（地面にいる：true、地面にいない：false）


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); //Playerについているコンポーネント情報を取得
    }

    // Update is called once per frame
    void Update()
    {
        //Velocityの元となる値の取得（右なら1.0f、左なら-1.0f、なにもなければ0)
        axisH = Input.GetAxisRaw("Horizontal");

        if (axisH > 0)
        {
            //右を向く
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (axisH < 0)
        {
            //左を向く
            transform.localScale = new Vector3(-1, 1, 1);
        }

        
        if (Input.GetButtonDown("Jump"))
        {
            Jump(); //Jumpメソッドの発動
        }


    }
    //1秒間に50回(50fps)繰り返すように制御しながら行う繰り返しメソッド
    private void FixedUpdate()
    {
        //地面判定をサークルキャストで行って、その結果を変数onGroundに代入
        onGround = Physics2D.CircleCast(
            transform.position, //発射位置＝プレイヤーの位置（基準点）
            0.2f, //調査する円の半径
            new Vector2(0,1.0f),
            0,
            groundLayer
            );

        //Velocityに値を代入
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);

        //ジャンプフラグが立ったら
        if (goJump == true)
        {
            rbody.AddForce(new Vector2(0,jumpPower),ForceMode2D.Impulse);
            goJump = false;
        }

    }

　　void Jump()
    {
        if (onGround == true)
        { 
            goJump = true; //ジャンプフラグをON
        }
       
    }


}
