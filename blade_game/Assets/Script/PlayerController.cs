using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f; // ジャンプの強さ
    private int jumpCount = 0; // ジャンプの回数
    private bool isGrounded = false; // 地面にいるかどうか
    private Rigidbody2D rb;
    //プレイヤーの速度
    public float speed = 5f;
    public Vector2 respawnPosition;
    private SpriteRenderer spriteRenderer;
    // public float flap = 500f;
    // public float scroll = 5f;
    // float direction = 0f;
    Rigidbody2D rb2d;
    private Transform stratPosition;
    private Rigidbody2D rb2D;  //オブジェクト・コンポーネント参照

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();   //コンポーネント参照取得
        rb = GetComponent<Rigidbody2D>();

         rb2D = GetComponent<Rigidbody2D>();
        stratPosition = gameObject.transform;
    }

    void Update()
    {
        //右に進む移動
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // スペースキーが押され、ジャンプ回数が2未満の場合ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // 上向きの速度をリセット
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // ジャンプの力を加える
            jumpCount++;
        }

        // Vector2 posi = this.transform.position;
        // Debug.Log("x = -7" + posi.x);
        // Debug.Log("y = -2.6" + posi.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 地面に着地したらジャンプ回数をリセット
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 地面から離れたら地面にいないことを設定
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // トリガーが他のColliderと接触した際に呼ばれる
   private void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.CompareTag("River"))
    {
        Respawn();
    }
}

void Respawn()
{
    Vector2 startPosition = new Vector2(-10f, -3.3f);
    transform.position = startPosition;

    GameObject manager = GameObject.Find("GameManager");
    manager.GetComponent<GameManager>().DecreaseHP();
}
}
