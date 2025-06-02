using UnityEngine;
using System.Collections.Generic;

namespace Part20250602_2
{
    
    public class Part20250602_2 : MonoBehaviour
    {
        private void Start()
        {
            new Question1().CheckAnswer();
            new Question2().CheckAnswer();
            new Question3().CheckAnswer();
            new Question4().CheckAnswer();
        }

        /**
         * 問1：抽象クラスの基本
         * 期待される出力: Speak: ワンワン
         */
        public class Question1
        {
            private abstract class Animal
            {
                public abstract string Speak();
            }

            // TODO DogクラスはAnimalを継承し、Speakメソッドをオーバーライドしてコンパイルエラーを解消する
            private class Dog : Animal
            {
                public override string Speak()
                {
                    return "ワンワン";
                }
            }

            private bool IsValid(out string message)
            {
                Animal dog = new Dog();
                var sound = dog.Speak();
                message = $"Speak: {sound}";
                return sound == "ワンワン";
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question1: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }

        /**
         * 問2：仮想関数のオーバーライド
         * 期待される出力: Dog: ワンワン, Cat: ニャー
         */
        public class Question2
        {
            private abstract class Animal
            {
                public virtual string Speak()
                {
                    return "動物の鳴き声";
                }
            }

            private class Dog : Animal
            {
                // TODO 仮想関数をオーバーライドして「ワンワン」を返す
                public override string Speak()
                {
                    return "ワンワン";
                }
            }

            private class Cat : Animal
            {
                // TODO 仮想関数をオーバーライドして「ニャー」を返す
                public override string Speak()
                {
                    return "ニャー";
                }
            }

            private bool IsValid(out string message)
            {
                Animal dog = new Dog();
                Animal cat = new Cat();

                message = $"Dog: {dog.Speak()}, Cat: {cat.Speak()}";
                return dog.Speak() == "ワンワン" && cat.Speak() == "ニャー";
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question2: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }

        /**
         * 問3：抽象プロパティの利用
         * 期待される出力: Warrior HP: 150, Mage HP: 80
         */
        public class Question3
        {
            private abstract class Character
            {
                public abstract int MaxHP { get; }
            }

            private class Warrior : Character
            {
                // TODO 改修箇所
                public override int MaxHP => 150;
            }

            private class Mage : Character
            {
                // TODO 改修箇所
                public override int MaxHP => 80;
            }

            private bool IsValid(out string message)
            {
                Character w = new Warrior();
                Character m = new Mage();
                message = $"Warrior HP: {w.MaxHP}, Mage HP: {m.MaxHP}";
                return w.MaxHP == 150 && m.MaxHP == 80;
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question3: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }

        /**
         * 問4：Listで抽象型のループ
         * 期待される出力: TotalArea: 7.14
         */
        public class Question4
        {
            // 図形抽象クラス
            private abstract class Shape
            {
                public virtual float Area()
                {
                    return 0;
                }
            }

            // 円クラス
            private class Circle : Shape
            {
                public readonly float Radius;
                public Circle(float radius)
                { 
                    Radius = radius;
                }

                // TODO 改修箇所
                public override float Area()
                {
                    return Mathf.PI * Radius * Radius;   
                }
            }
            
            // 正方形クラス
            private class Square : Shape
            {
                public readonly float Size;
                public Square(float size)
                {
                    Size = size;
                }

                // TODO 改修箇所
                public override float Area()
                {
                    return Size * Size;
                }
            }

            private bool IsValid(out string message)
            {
                // 図形のリストを作成
                var shapes = new List<Shape>
                {
                    new Circle(1),
                    new Square(2)
                };

                float total = 0;
                foreach (var s in shapes)
                {
                    // 各図形の面積を合計
                    total += s.Area();
                }

                // F2で小数点以下2桁まで表示指定
                message = $"TotalArea: {total:F2}";
                return Mathf.Abs(total - (Mathf.PI * 1 * 1 + 4)) < 0.01f;
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question4: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }


    }
    
}
