using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory
{
    public abstract Enemy_1 Create();
}

public class SlimeFactory : EnemyFactory
{
    public override Enemy_1 Create()
    {
        var slime = new Slime();
        slime.InitializeSlime();
        return slime;
    }
}

public class DragonFactory : EnemyFactory
{
    public override Enemy_1 Create()
    {
        var dragon = new Slime();
        dragon.InitializeSlime();
        return dragon;
    }
}