using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problemex1_3 : MonoBehaviour
{
    void Start()
    {
        // UnityではMainが自動で呼ばれないので、手動で呼ぶ
        string[] dummyArgs = new string[0]; // 引数を模倣
        Program.Main(dummyArgs);
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Sample s = new Sample();
            s.func();
            s.End();
            // s = null;
            // System.GC.Collect();  // GCを強制してみる
            // System.GC.WaitForPendingFinalizers();
        }
    }

    class Sample
    {
        public Sample()
        {
            Debug.Log("スタート");
        }
        public void func()
        {
            Debug.Log("func");
        }
        public void End()
        {
            Debug.Log("エンド");
        }

        // デストラクタ（GCにより自動的に呼ばれるが、Unityでは非決定的）
        // ~Sample()
        // {
        //     Debug.Log("エンド");  // Unityでは呼ばれないことがある
        // }
    }
}
