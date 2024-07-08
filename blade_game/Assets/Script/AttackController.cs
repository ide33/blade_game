using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform attackPoint; // 攻撃の発生地点
    public float attackRange = 0.5f; // 攻撃の範囲
    public LayerMask enemyLayers; // 攻撃が当たる敵のレイヤー
    public int attackDamage = 10; // 攻撃力

    void Update()
    {
        // スペースキーが押されたときに攻撃を実行
        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }
    }

    void Attack()
    {
        // 攻撃の範囲内にいる敵を検出
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // 検出された敵にダメージを与える
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}