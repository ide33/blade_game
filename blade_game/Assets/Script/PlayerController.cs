using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// プレイヤー操作・制御クラス
/// </summary>
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;  //オブジェクト・コンポーネント参照
    private SpriteRenderer spriteRenderer;
    public float flap = 500f;
    public float scroll = 5f;
    float direction = 0f;
    Rigidbody2D rb2d;
    bool jump = false;

    // public CheckGround ground;

    private bool isGround = false;
    public bool isGrounded;



    //移動関連変数
    [HideInInspector] public float xSpeed; //X方向移動速度
    [HideInInspector] public bool rightFacing;  //向いている方向(true.右向き false:左向き)
    private Transform stratPosition;

    void Start()  //Start(オブジェクト有効時に１度実行)
    {
        rb2d = GetComponent<Rigidbody2D>();   //コンポーネント参照取得
        spriteRenderer = GetComponent<SpriteRenderer>();

        //変数初期化
        rightFacing = true;  //最初は右向き

         //コンポーネント読み込み
        rb2D = GetComponent<Rigidbody2D>();
        stratPosition = gameObject.transform;
    }

    void Update()  //Update(１フレームごとに１度ずつ実行)

    {
        Vector2 posi = this.transform.position;
        Debug.Log("x = -10" + posi.x);
        Debug.Log("y = -3.3" + posi.y);

        // isGround = ground.IsGround();

        // このY座標（bottomY）より下へ落ちたらスタートへ戻す
        float bottomY = Camera.main.transform.position.y - Camera.main.orthographicSize * 2;
        // プレイヤーのY座標がbottomYより低い
        if (gameObject.transform.position.y < bottomY)
        {
            Vector2 startPosition = new Vector2(-10f,-3.3f);
            transform.position = startPosition;

            // GameObject manager = GameObject.Find("GameManager");
            // manager.GetComponent<GameManager>().DecreaseHP();
        }

        this.transform.rotation = Quaternion.Euler(0, 0, 0);  //プレイヤーの回転を停止させる
        MoveUpdate();  //左右移動処理

        
        //キーボード操作
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1f;
        }
        else
        {
            direction = 0f;
        }


        //キャラのy軸のdirection方向にscrollの力をかける
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);

        //ジャンプ判定
        if (Input.GetKeyDown("space") && !jump)
        {
            rb2d.AddForce(Vector2.up * flap);
            jump = true;
        }
    }

    /// <summary>
    /// Updateから呼び出される左右移動入力処理
    /// </summary>
    private void MoveUpdate()
    {
        //X方向移動入力
        if (Input.GetKey(KeyCode.RightArrow))  //右方向の移動入力 
        {
            xSpeed = 6.0f;   //X方向移動速度をプラスに設定

            rightFacing = true;  //右向きフラグon
            spriteRenderer.flipX = false;  //スプライトを通常の向きで表示
        }
        else if (Input.GetKey(KeyCode.LeftArrow))  //左方向の移動入力
        {
            xSpeed = -6.0f;  //X方向移動をマイナスに設定

            rightFacing = false;  //右向きフラグoff
            spriteRenderer.flipX = true;  //スプライトを左右反転した向きで表示
        }
        else  //入力なし
        {
            xSpeed = 0.0f;  //X方向の移動を停止
        }
    }

    /// <summary>
    /// Updateから呼び出されるジャンプ入力処理
    /// </summary>

    private void FixedUpdate()  //FixedUpdate (一定時間ごとに１度ずつ実行・物理演算用)
    {
        Vector2 velocity = rb2D.velocity;  //移動速度ベクトルを現在値から取得
        velocity.x = xSpeed;  //X方向の速度を入力から決定
        rb2D.velocity = velocity;  //計算した移動速度ベクトルをRigidBody2Dに反映
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }
}
