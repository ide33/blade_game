using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float attackRange = 1f; // 攻撃の範囲
    public LayerMask enemyLayer; // 敵のレイヤー

    void Update()
    {
        // プレイヤーが攻撃ボタンを押したとき
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    void Attack()
    {
        // 攻撃範囲内の敵を検出
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        // 検出した敵を消滅させる
        foreach (Collider2D enemy in hitEnemies)
        {
            Destroy(enemy.gameObject);
        }
    }

    // ギズモを表示して攻撃範囲を可視化
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}