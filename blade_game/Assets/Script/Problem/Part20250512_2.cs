using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Part20250512_2
{
    public class Part20250512_2 : MonoBehaviour
    {
        private void Start()
        {
            var question1 = new Question1();
            var question2 = new Question2();
            var question3 = new Question3();

            question1.CheckAnswer();
            question2.CheckAnswer();
            question3.CheckAnswer();
        }
    }

    /**
     * 問1
     *
     * SwapValues() が正しく動作するように、ref キーワードを適切な場所に追加してください。
     * このメソッドは2つの整数値を入れ替える処理を行います。
     * 期待される出力は、x が 20 で y が 10
     */
    public class Question1
    {
        // TODO: このメソッドを修正してください
        private void SwapValues(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        // TODO: このメソッドを修正してください
        /** 正誤判定 */
        private bool IsValid(out string message)
        {
            var x = 10;
            var y = 20;

            SwapValues(ref x, ref y);

            message = $"x: {x}, y: {y}";
            return x == 20 && y == 10;
        }

        /** 結果表示 */
        public void CheckAnswer()
        {
            var color = IsValid(out var message) ? "green" : "red";
            Debug.Log($"Question1: <color={color}>{message}</color>");
        }
    }

    /**
     * 問2
     *
     * TryParseCoinData メソッドを修正してください。
     * このメソッドはコイン情報の文字列を解析し、解析に成功した場合はtrueを返し、out引数にコインの名前と価値を設定します。
     * 解析に失敗した場合はfalseを返します。
     * 期待される出力は、CoinName: Gold, CoinValue: 50
     */
    public class Question2
    {
        // TODO: このメソッドを修正してください
        private bool TryParseCoinData(string data, out string coinName, out int coinValue)
        {
            coinName = string.Empty;
            coinValue = 0;

            // Gold:50を「:」で分割
            // parts[0]がコイン名、parts[1]がコインの価値になる
            var parts = data.Split(':');

            coinName = parts[0];

            if (parts.Length != 2)
                return false;

            if (!int.TryParse(parts[1], out var value))
            {
                return false;
            }
            coinValue = 50;

            return true;
        }

        private bool IsValid(out string message)
        {
            // テストとして "Gold:50" を解析
            var result = TryParseCoinData("Gold:50", out var coinName, out var coinValue);

            message = $"CoinName: {coinName}, CoinValue: {coinValue}";

            return result && coinName == "Gold" && coinValue == 50;
        }

        public void CheckAnswer()
        {
            var color = IsValid(out var message) ? "green" : "red";
            Debug.Log($"Question2: <color={color}>{message}</color>");
        }
    }

    /**
     * 問3
     *
     * PlayerStats クラスの UpdateHealth メソッドを修正して、
     * プレイヤーの現在のHPを更新し、実際に適用されたダメージ量を out パラメータで返すようにしてください。
     * ModifyDamage メソッドは ref パラメータを使用して、ダメージ量を防御力に基づいて変更します。
     */
    public class Question3
    {
        private class PlayerStats
        {
            public int CurrentHP { get; private set; } = 100;
            private const int _defense = 10;

            // ダメージを適用し、実際に適用されたダメージ量を返す
            public void UpdateHealth(int damage, out int appliedDamage)
            {
                ModifyDamage(ref damage, _defense);

                // HPが0未満にならないようにする
                if (CurrentHP - damage < 0)
                {
                    appliedDamage = CurrentHP;
                    CurrentHP = 0;
                }
                else
                {
                    appliedDamage = damage;
                    CurrentHP -= damage;
                }
            }

            // ダメージを防御力に基づいて修正する（最低1ダメージ）
            private void ModifyDamage(ref int rawDamage, int defense)
            {
                rawDamage = Math.Max(1, rawDamage - defense);
            }
        }

        private bool IsValid(out string message)
        {
            var player = new PlayerStats();
            var appliedDamage = 0;
            message = string.Empty;

            // ダメージを与える（防御力10があるので、実際のダメージは15になるはず）
            var damage1 = 25;
            player.UpdateHealth(damage1, out appliedDamage);

            var firstCheck = player.CurrentHP == 85 && appliedDamage == 15;

            message += $"CurrentHP: {player.CurrentHP}, appliedDamage: {appliedDamage}\n";

            // 致命的なダメージを与える
            var damage2 = 200;
            player.UpdateHealth(damage2, out appliedDamage);

            var secondCheck = player.CurrentHP == 0 && appliedDamage == 85;

            message += $"CurrentHP: {player.CurrentHP}, appliedDamage: {appliedDamage}";

            return firstCheck && secondCheck;
        }

        public void CheckAnswer()
        {
            var color = IsValid(out var message) ? "green" : "red";
            Debug.Log($"Question3: <color={color}>{message}</color>");
        }
    }
}
