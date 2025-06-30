using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_1
{
    public abstract string GetName();
}

public class Slime : Enemy_1
{
    public override string GetName()
    {
        return "スライム";
    }

    public void InitializeSlime()
    {
        Debug.Log("スライム初期化");
    }
}

public class Dragon : Enemy_1
{
    public override string GetName()
    {
        return "ドラゴン";
    }

    public void InitializeDragon()
    {
        Debug.Log("ドラゴン初期化");
    }
}
