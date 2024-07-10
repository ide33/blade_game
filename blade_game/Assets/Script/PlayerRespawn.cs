using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPosition;  // リスポーン位置
    public int respawnDamage = 20;   // リスポーン時のダメージ量
    private PlayerHealth playerHealth;  // プレイヤーのHP管理スクリプトへの参照

    void Start()
    {
        // ゲーム開始時にリスポーン位置を現在の位置に設定
        respawnPosition = transform.position;

        // PlayerHealthスクリプトへの参照を取得
        playerHealth = GetComponent<PlayerHealth>();
    }

    // トリガーが他のColliderと接触した際に呼ばれる
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 川に接触した場合の処理
        if (other.gameObject.CompareTag("River"))
        {
            Respawn();
        }
    }

    // リスポーン位置にプレイヤーを移動させ、HPを減らす
    void Respawn()
    {
        transform.position = respawnPosition;
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(respawnDamage);
        }
    }
}
