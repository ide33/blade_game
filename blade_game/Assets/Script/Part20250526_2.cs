using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Part20250526_2
{

    public class Part20250526_2 : MonoBehaviour
    {
        private void Start()
        {
            new Question1().CheckAnswer();
            new Question2().CheckAnswer();
        }

        /**
         * 問1: ジェネリッククラスの作成
         * 期待される出力: intBox: 10, stringBox: Hello
         */
        private class Question1
        {
            // TODO : ジェネリッククラス Box<T> を作成
            // TODO : Box<T> に Value プロパティを追加
            // TODO : Box<T> のコンストラクタを追加

            private class Box<T>
            {
                public T Value { get; }

                public Box(T value)
                {
                    Value = value;
                }
            }
            private class Box
            {
                public int Value { get; }
                public Box(int value)
                {
                    Value = value;
                }
            }
            
            /** Boxのインスタンス作成 */
            private Box CreateBox(int value)
            {
                // TODO : Box<T> に対応したジェネリック関数へ変更する
                return new Box(value);
            }
            
            private Box CreateBox(string value)
            {
                return null;
            }

            private bool IsValid(out string message)
            {
                var intBox = CreateBox(10);
                var stringBox = CreateBox("Hello");
                
                var intBoxValue = intBox.Value;
                // TODO : stringBox.Value を取得する
                // var stringBoxValue = stringBox.Value;
                string stringBoxValue = "";
                
                message = $"intBox: {intBoxValue}, stringBox: {stringBoxValue}";
                return intBox.Value == 10 && stringBoxValue == "Hello";
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question1: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }


        /**
         * 問1: 型制約付きジェネリッククラスの作成
         * 期待される出力: 合計レベル: 10
         */
        private class Question2
        {
            /** 味方クラス */
            private abstract class Ally
            {
                public abstract int Level { get; }
            }
            
            /** ユニット派生クラス */
            private class Warrior : Ally
            {
                public override int Level => 5;
            }
            
            private class Mage : Ally
            {
                public override int Level => 3;
            }
            
            private class Rogue : Ally
            {
                public override int Level => 2;
            }
            
            /** パーティー情報クラス */
            // TODO : ジェネリッククラス Party<TUnit> に型制約を追加
            private class PartyInfo<T>
            {
                private readonly List<T> _allies = new List<T>();
                
                /** ユニットのレベルを合計 */
                public void Add(T unit)
                {
                    _allies.Add(unit);
                }
                
                /** ユニットのレベルを合計 */
                public int GetLevelSum()
                {
                    // TODO : 編成ユニット のレベルを合計する処理を実装
                    return 0;
                }
            }
            
            private bool IsValid(out string message)
            {
                var party = new PartyInfo<Ally>();
                
                // パーティーにユニットを追加
                party.Add(new Warrior());
                party.Add(new Mage());
                party.Add(new Rogue());
                
                // ユニットのレベルを合計
                var levelSum = party.GetLevelSum();
                
                message = $"合計レベル: {levelSum}";
                return levelSum == 10;
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question2: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }
    }

}
