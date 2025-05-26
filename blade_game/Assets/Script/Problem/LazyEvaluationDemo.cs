using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LazyEvaluationDemo : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("=== LINQクエリの定義だけ ===");

        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        var query = numbers
            .Where(n =>
            {
                Debug.Log($"LINQ : Where: {n}");
                return n % 2 == 0;
            });

        Debug.Log("=== まだ何も実行されていない ===");

        Debug.Log("=== 要素を1つずつ列挙開始 ===");
        foreach (var n in query)
        {
            Debug.Log($"抽出された値: {n}");
        }
    }
}
