using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Slime,
    Dragon
}

public class Stage : MonoBehaviour
{
    private Dictionary<EnemyType, EnemyFactory> _enemyFactories;

    private void Start()
    {
        _enemyFactories = new Dictionary<EnemyType, EnemyFactory>
        {
            { EnemyType.Slime, new SlimeFactory() },
            { EnemyType.Dragon, new DragonFactory() }
        };

        var slime = CreateEnemy(EnemyType.Slime);
        var dragon = CreateEnemy(EnemyType.Dragon);

        ApperEnemy(slime);
        ApperEnemy(dragon);
    }

    private void ApperEnemy(Enemy_1 enemy_1)
    {
        Debug.Log($"{enemy_1.GetName()}が現れた！");
    }

    private Enemy_1 CreateEnemy(EnemyType enemyType)
    {
        var existFactory = _enemyFactories.TryGetValue(enemyType, out var factory);
        if (!existFactory)
        {
            Debug.LogError("Factoryが存在していません");
            return null;
        }
        return factory.Create();
    }
}
