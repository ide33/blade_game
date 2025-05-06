using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Problemex1_2 : MonoBehaviour
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
            Calc c1 = new Calc(),c2 = new Calc(3,1);
            c1.Num1 = 1;
            c1.Num2 = 2;
            //  加算の結果を表示
            c1.ShowAdd();
            c2.ShowAdd();
        }
    }

    class Calc
    {
        //  一つ目の数
        private int num1;

        //  二つ目の数
        private int num2;

        //  一つ目の数のプロパティ
        public int Num1
        {
            set { num1 = value; }
            get { return num1; }
        }

        //  二つ目の数のプロパティ
        public int Num2
        {
            set { num2 = value; }
            get { return num2; }
        }

        //　引数付きのコンストラクタ
        public Calc(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        // 引数なしコンストラクタ
        public Calc()
        {

        }

        public void ShowAdd()
        {
            Debug.Log(string.Format("{0} + {1} = {2}", num1, num2, num1 + num2));
        }
    }
}
