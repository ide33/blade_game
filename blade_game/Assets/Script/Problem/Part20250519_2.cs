using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Part20250519_2 : MonoBehaviour
{
    private void Start()
    {
        new LinqQuestion1().CheckAnswer();
        new LinqQuestion2().CheckAnswer();
        new LinqQuestion3().CheckAnswer();
        
        new LinqQuestion4().CheckAnswer();
        new LinqQuestion5().CheckAnswer();
        new LinqQuestion6().CheckAnswer();
    }

    /**
     * 問1: Where - 偶数だけ抽出
     * 期待される出力: 2, 4
     */
    public class LinqQuestion1
    {
        private bool IsValid(out string message)
        {
            var numbers = Enumerable.Range(1, 5); // 1〜5

            // TODO 偶数を抽出
            var evens = numbers;

            evens = numbers.Where(n => n % 2 == 0);

            message = string.Join(", ", evens);
            return evens.SequenceEqual(new List<int> { 2, 4 });
        }

        public void CheckAnswer()
        {
            Debug.Log($"LinqQuestion1: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
        }
    }

    /**
     * 問2: Select - 要素を変換
     * 期待される出力: 3, 5, 3
     */
    public class LinqQuestion2
    {
        private bool IsValid(out string message)
        {
            var names = new List<string> { "Tom", "Alice", "Bob" };

            // TODO 各文字列を文字数に変換
            List<int> lengths = new List<int>();

            lengths = names.Select(name => name.Length).ToList();

            message = string.Join(", ", lengths);
            return lengths.SequenceEqual(new List<int> { 3, 5, 3 });
        }

        public void CheckAnswer()
        {
            Debug.Log($"LinqQuestion2: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
        }
    }

    /**
     * 問3: Any / All - 条件チェック
     * 期待される出力: AnyMinor: true, AllAdults: false
     */
    public class LinqQuestion3
    {
        private bool IsValid(out string message)
        {
            var ages = new List<int> { 17, 22, 30 };
            
            // TODO 誰かが未成年(18未満)か
            var anyMinor = false;

            anyMinor = ages.Any(age => age < 18);

            // TODO すべて成人(18以上)か
            var allAdults = false;

            allAdults = ages.Any(age => age >= 18);

            message = $"AnyMinor: {anyMinor}, AllAdults: {allAdults}";
            return anyMinor == true && allAdults == true;
        }

        public void CheckAnswer()
        {
            Debug.Log($"LinqQuestion3: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
        }
    }
    
    /**
     * 問4: First / FirstOrDefault - 条件一致の最初の要素を取得
     * 期待される出力: FirstA: Andy, FirstZ: null
     */
    public class LinqQuestion4
    {
        private bool IsValid(out string message)
        {
            var names = new List<string> { "Tom", "Andy", "Bob" };

            // TODO "A"で始まる最初の名前を取得。
            // string.StartsWith("A")で文字列が"A"で始まるかを判定できる
            var startsWithA = string.Empty;

            startsWithA = names.FirstOrDefault(name => name.StartsWith("A"));
            
            // TODO "Z"で始まる最初の名前を取得。取得できなければnull
            var notFound = string.Empty;

            notFound = names.FirstOrDefault(name => name.StartsWith("Z"));

            message = $"FirstA: {startsWithA}, FirstZ: {notFound ?? "null"}";
            return startsWithA == "Andy" && notFound == null;
        }

        public void CheckAnswer()
        {
            Debug.Log($"LinqQuestion4: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
        }
    }
    
    /**
     * 問5: Sum - 合計の計算
     * 期待される出力: Sum: 240
     */
    public class LinqQuestion5
    {
        /** 敵クラス */
        private class Enemy
        {
            public readonly string Name;
            public readonly int Gold;
            public Enemy(string name, int gold)
            {
                Name = name;
                Gold = gold;
            }
        }
        
        private bool IsValid(out string message)
        {
            var enemies = new List<Enemy> {
                new("スライム", 50),
                new("オーク", 80),
                new("ドラゴン", 110)
            };

            // TODO 敵のゴールドを合計
            var sumGold = 0;

            sumGold = enemies.Sum(enemy => enemy.Gold);

            message = $"Sum: {sumGold}";
            return sumGold == 240;
        }

        public void CheckAnswer()
        {
            Debug.Log($"LinqQuestion5: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
        }
    }
    
    /**
     * 問6: OrderBy - 並び替え
     * 期待される出力: メイジ, ウォリアー, ローグ
     */
    public class LinqQuestion6
    {
        /** 味方クラス */
        private class Ally
        {
            public readonly string Name;
            public readonly int Level;
            public Ally(string name, int level)
            {
                Name = name;
                Level = level;
            }
        }
        
        private bool IsValid(out string message)
        {
            var allies = new List<Ally>
            {
                new("ウォリアー", 5),
                new("メイジ", 8),
                new("ローグ", 4),
            };

            // TODO レベルで降順に並び替え
            var ascendingByLevel = allies;

            ascendingByLevel = allies.OrderByDescending(allies => allies.Level).ToList();

            message = $"{string.Join(", ", ascendingByLevel.Select(a => a.Name))}";
            return message == "メイジ, ウォリアー, ローグ";
        }

        public void CheckAnswer()
        {
            Debug.Log($"LinqQuestion6: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
        }
    }



}
