using UnityEngine;
using System.Collections.Generic;

namespace Part20250609
{
    public class Part20250609_1 : MonoBehaviour
    {
        private void Start()
        {
            new Question1().CheckAnswer();
            new Question2().CheckAnswer();
            new Question3().CheckAnswer();
            new Question4().CheckAnswer();
        }

        /**
         * 問1：インターフェースの実装
         * 期待される出力: "こんにちは!"
         */
        private class Question1
        {
            
            // Talk メソッドを持つ インターフェース ISpeakable を定義
            private interface ISpeakable
            {
                string Talk();
            }

            // TODO ISpeakable インターフェースを実装するクラス Person を定義
            // TODO Person クラスの Talk メソッドは "こんにちは!" を返すように実装する
            private class Person : ISpeakable
            {
                private const string Greeting = "こんにちは!";

                public string Talk()
                {
                    return Greeting;
                }
            }

            private string GetSpeak(Person speaker)
            {
                // ISpeakable インターフェースを実装しているかチェック
                var speakable = speaker as ISpeakable;
                return speakable == null ? string.Empty : speakable.Talk();
            }

            private bool IsValid(out string message)
            {
                var speaker = new Person();
                var result = GetSpeak(speaker);
                message = $"Talk: {result}";
                return result == "こんにちは!";
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question1: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }

        /**
         * 問2：複数インターフェースの実装
         * 期待される出力: "normalFile: 読み書き可能, readOnlyFile: 読み取りのみ可能"
         */
        private class Question2
        {
            private const string NormalFileStatus = "読み書き可能";
            private const string ReadOnlyFileStatus = "読み取りのみ可能";
            private const string WriteOnlyFileStatus = "書き込みのみ可能";
            
            // 読み取りと書き込みのインターフェースを定義
            private interface IReadable { string Read(); }
            private interface IWritable { string Write(); }

            // TODO それぞれのクラスで適切なインターフェースを継承する。メソッドの中身は適当でOK

            // 読み取りと書き込みの両方を実装するクラス
            private class File : IWritable, IReadable
            {
                public string Write()
                {
                    return "";
                }

                public string Read()
                {
                    return "";
                }
            }

            // 読み取り専用のクラス
            private class ReadOnlyFile : IReadable
            {
                public string Read()
                {
                    return "";
                }
            }
            
            // ファイルの読み書きの状態を取得するメソッド
            private string GetFileStatus<T>(T file)
            {
                var readable = file is IReadable;
                var writable = file is IWritable;
                if (readable && writable)
                {
                    return NormalFileStatus;
                }
                if (readable)
                {
                    return ReadOnlyFileStatus;
                }
                return WriteOnlyFileStatus;
            }

            private bool IsValid(out string message)
            {
                // File クラスと ReadOnlyFile クラスのインスタンスを作成
                var normalFle = new File();
                var readOnlyFile = new ReadOnlyFile();
                message = $"normalFile: {GetFileStatus(normalFle)}, readOnlyFile: {GetFileStatus(readOnlyFile)}";
                return 
                    GetFileStatus(normalFle) == NormalFileStatus &&
                    GetFileStatus(readOnlyFile) == ReadOnlyFileStatus;
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question3: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }

        /**
         * 問3：インターフェースによる多態性
         * 期待される出力: "にゃー,わんわん"
         */
        private class Question3
        {
            // TODO: IAnimal インターフェースに適切なメソッドを定義
            private interface IAnimal
            {
                string Speak();
            }

            private class Cat : IAnimal
            {
                public string Speak() => "にゃー";
            }

            private class Dog : IAnimal
            {
                public string Speak() => "わんわん";
            }
            
            private string GetAnimalVoice(IAnimal animal)
            {
                // TODO 各動物の声を取得
                return animal.Speak();
            }

            private bool IsValid(out string message)
            {
                // IAnimalのリストを作成
                var animals = new List<IAnimal> { new Cat(), new Dog() };
                var result = string.Join(",", animals.ConvertAll(GetAnimalVoice));
                message = $"Voices: {result}";
                return result == "にゃー,わんわん";
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question4: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }

        /**
         * 問5：インターフェース + ジェネリック
         * 期待される出力: "Int: 42, String: Hello"
         */
        private class Question4
        {
            // ジェネリックな型Tに対応したインターフェース
            private interface IDataHolder<T>
            {
                T GetData();
            }

            // TODO IDataHolder<T> インターフェースを適切に継承する
            private class IntHolder : IDataHolder<int>
            {
                public int GetData() => 42;
            }
            
            private class StringHolder : IDataHolder<string>
            {
                public string GetData() => "Hello";
            }
            
            private bool IsValid(out string message)
            {
                IDataHolder<int> intHolder = null;
                IDataHolder<string> stringHolder = null;
                
                // IntHolder と StringHolder のインスタンスを作成
                
                // TODO インターフェースを実装できたらコメントを外す
                intHolder = new IntHolder();
                stringHolder = new StringHolder();
                
                var intAnswer = intHolder != null ? intHolder.GetData() : 0;
                var stringAnswer = stringHolder != null ? stringHolder.GetData() : "";
                message = $"Int: {intAnswer}, String: {stringAnswer}";
                
                return 
                    intAnswer == 42 &&
                    stringAnswer == "Hello";
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question5: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }
    }

}

