using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Part20250519_1
{
    public class Part20250516_Collections : MonoBehaviour
    {
        private void Start()
        {
            var question1 = new Question1();
            var question2 = new Question2();
            var question3 = new Question3();
            var question4 = new Question4();
            var question5 = new Question5();

            question1.CheckAnswer();
            question2.CheckAnswer();
            question3.CheckAnswer();
            question4.CheckAnswer();
            question5.CheckAnswer();
        }
    }

    // ────────────────────────────────
    // Question1  ─ 配列の合計を求める
    // ────────────────────────────────
    /**
     * 配列に含まれる整数を合計する SumArrayElements() を完成させてください。
     * 期待される出力 : Sum = 10
     */
    public class Question1
    {
        // TODO: 配列の要素を合計して返すコードを記述
        private int SumArrayElements(int[] numbers)
        {
            var sum = 0;
            foreach (var n in numbers)
            {
                sum += n;
            }
            return sum;
        }

        private bool IsValid(out string message)
        {
            var nums = new[] { 1, 2, 3, 4 };
            var sum = SumArrayElements(nums);
            message = $"Sum = {sum}";
            return sum == 10;
        }

        public void CheckAnswer()
        {
            var color = IsValid(out var msg) ? "green" : "red";
            Debug.Log($"Question1: <color={color}>{msg}</color>");
        }
    }

    // ────────────────────────────────
    // Question2  ─ List の要素フィルタリング
    // ────────────────────────────────
    /**
     * RemoveNegativeNumbers() で負の値だけを List から取り除いてください。
     * 期待される出力 : Filtered [1,4]
     */
    public class Question2
    {
        // TODO: List<int> から負数を除去する処理を実装
        private void RemoveNegativeNumbers(List<int> numbers)
        {
            numbers.RemoveAll(n => n < 0);
        }

        private bool IsValid(out string message)
        {
            var list = new List<int> { -3, 1, -2, 4 };
            RemoveNegativeNumbers(list);
            message = $"Filtered [{string.Join(",", list)}]";
            return list.SequenceEqual(new[] { 1, 4 });
        }

        public void CheckAnswer()
        {
            var color = IsValid(out var msg) ? "green" : "red";
            Debug.Log($"Question2: <color={color}>{msg}</color>");
        }
    }

    // ────────────────────────────────
    // Question3  ─ Dictionary 検索
    // ────────────────────────────────
    /**
     * GetWeatherRate() を完成させ、指定した天気のその月の割合を返してください
     * 期待される出力 : 雨 = 17% 雪 = 0% 
     */
    public class Question3
    {

        /** 月の天気ごとの日数 */
        private readonly Dictionary<string, int> _weatherDic = new()
        {
            { "雨", 5 },
            { "晴れ", 18 },
            { "曇り",  6 }
        };

        // TODO: 天気の割合(%)を取得する処理を実装
        private int GetWeatherRate(string weather)
        {
            var totalDays = _weatherDic.Values.Sum();
            if (_weatherDic.TryGetValue(weather, out var days))
            {
                return (int)((float)days / totalDays * 100);
            }
            return 0;
        }

        private bool IsValid(out string message)
        {
            message = string.Empty;
            // 「雨」と「雪」の割合を取得
            var foundWeather = new[] { "雨", "雪" };
            foreach (var weather in foundWeather)
            {
                var rate = GetWeatherRate(weather);
                // 割合から出力
                message += $"{weather} = {rate}% ";
            }
            return message == "雨 = 17% 雪 = 0% ";
        }

        public void CheckAnswer()
        {
            var color = IsValid(out var msg) ? "green" : "red";
            Debug.Log($"Question3: <color={color}>{msg}</color>");
        }
    }

    // ────────────────────────────────
    // Question4  ─ Stack で文字列を反転
    // ────────────────────────────────
    /**
     * ReverseString() を Stack<char> を用いて実装してください。
     * 期待される出力 : OLLEH
     */
    public class Question4
    {
        // TODO: Stack<char> を利用して文字列「HELLO」を逆順にする
        private string ReverseString(string word)
        {
            // 文字列を 文字のStack<char> に変換
            var stack = new Stack<char>(word);

            for (var i = 0; i < word.Length; i++)
            {

            }
            return string.Empty;
        }

        private bool IsValid(out string message)
        {
            var original = "HELLO";
            var reversed = ReverseString(original);
            message = reversed;
            return reversed == "OLLEH";
        }

        public void CheckAnswer()
        {
            var color = IsValid(out var msg) ? "green" : "red";
            Debug.Log($"Question4: <color={color}>{msg}</color>");
        }
    }

    // ────────────────────────────────
    // Question5  ─ Queue で順番処理
    // ────────────────────────────────
    /**
     * ServeCustomers() が Queue から 1 つずつ名前を取り出し、
     * 処理した順番の文字列 "春夏秋冬" を返すようにしてください。
     */
    public class Question5
    {
        // TODO: Queue<string> を使って順番に取り出し結果を返す。
        // customersには「冬」が不足しているので、Enqueue()で「冬」を追加してください。
        private string ServeCustomers(Queue<string> customers)
        {
            customers.Enqueue(item: "冬");

            return string.Empty;
        }

        private bool IsValid(out string message)
        {
            var q = new Queue<string>(new[] { "春", "夏", "秋" });
            var log = ServeCustomers(q);
            message = log;
            return log == "春夏秋冬";
        }

        public void CheckAnswer()
        {
            var color = IsValid(out var msg) ? "green" : "red";
            Debug.Log($"Question5: <color={color}>{msg}</color>");
        }
    }
}
