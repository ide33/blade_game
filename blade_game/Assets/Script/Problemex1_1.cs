using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problemex1_1 : MonoBehaviour
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
            s.foo();
        }
    }

    public class Sample
    {
        public Sample()
        {
            Debug.Log("コンストラクタ");
        }
        
        public void foo()
        {
            Debug.Log("foo");
        }
    }
}
