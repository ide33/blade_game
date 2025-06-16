using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _20250616
{
    public class Part20250616_1 : MonoBehaviour
    {
        private void Start()
        {
            new Question1().CheckAnswer(this);
            // new Question2().CheckAnswer(this);
            // new Question3().CheckAnswer(this);
        }

        /**
         * 問1：基本的なCoroutineの実装
         * 期待される出力: "Coroutine開始 -> 1秒待機完了 -> Coroutine終了"
         */
        private class Question1
        {
            private readonly List<string> _logs = new();
            
            // 1秒待機してからログを出力するCoroutineを作成
            private IEnumerator WaitAndLogCoroutine()
            {
                _logs.Add("Coroutine開始");
                
                // TODO: 1秒間待機する処理を実装
                yield return new WaitForSeconds(1f);
                
                _logs.Add("1秒待機完了");
                _logs.Add("Coroutine終了");
            }

            public void CheckAnswer(MonoBehaviour mono)
            {
                mono.StartCoroutine(CheckCoroutineExecution(mono));
            }
            
            private IEnumerator CheckCoroutineExecution(MonoBehaviour mono)
            {
                yield return mono.StartCoroutine(WaitAndLogCoroutine());
                
                var result = string.Join(" -> ", _logs);
                var isValid = result == "Coroutine開始 -> 1秒待機完了 -> Coroutine終了";
                
                Debug.Log($"Question1: <color={(isValid ? "green" : "red")}> {result}</color>");
            }
        }

        /**
         * 問2：フラグの変化を待つ
         * 期待される出力: "条件待機完了"
         */
        private class Question2
        {
            private readonly List<string> _logs = new();
            // 条件待機用のフラグ
            private bool _condition = false;
            
            private IEnumerator MultipleYieldCoroutine(MonoBehaviour mono)
            {
                // 条件フラグを別Coroutineで開始
                mono.StartCoroutine(SetConditionAfterDelay());
                
                // 条件が満たされるまで待機
                // TODO: _conditionがtrueになるまで待機する処理を実装
                yield return SetConditionAfterDelay();
                
                if (_condition)
                {
                    _logs.Add("条件待機完了");
                }
                else
                {
                    _logs.Add("まだ条件が満たされていません");
                }
            }
            
            // 1秒後にフラグが立つ
            private IEnumerator SetConditionAfterDelay()
            {
                // 1秒後に条件を満たす
                yield return new WaitForSeconds(1f);
                _condition = true;
                Debug.Log("条件が満たされました");
            }

            public void CheckAnswer(MonoBehaviour mono)
            {
                mono.StartCoroutine(CheckMultipleYield(mono));
            }
            
            private IEnumerator CheckMultipleYield(MonoBehaviour mono)
            {
                yield return mono.StartCoroutine(MultipleYieldCoroutine(mono));
                
                var result = string.Join(", ", _logs);
                var isValid = result == "条件待機完了";
                
                Debug.Log($"Question2: <color={(isValid ? "green" : "red")}> {result}</color>");
            }
        }

        /**
         * 問3：Coroutineの停止と管理
         * 期待される出力: "カウント: 3, 停止されました"
         */
        private class Question3
        {
            private int _count = 0;
            
            // 1秒ごとに_countを加算し続ける
            private IEnumerator CountingCoroutine()
            {
                // 無限ループ
                while (true)
                {
                    // 1秒待機
                    yield return new WaitForSeconds(1.0f);
                    _count++;
                    Debug.Log(_count <= 3 ? $"カウント: {_count}" : $"<color=red>カウント: {_count}</color>");
                }
            }

            // 3.5秒後にCoroutineを停止する
            private IEnumerator StopCoroutineAfterDelay(MonoBehaviour mono, Coroutine targetCoroutine)
            {
                yield return new WaitForSeconds(3.5f);
                // TODO: targetCoroutineを停止する処理を実装
                // TODO: Monobehaviourが持つCoroutineを停止するStartCoroutineを持っている
                mono.StopCoroutine(targetCoroutine);
            }

            public void CheckAnswer(MonoBehaviour mono)
            {
                mono.StartCoroutine(CheckCoroutineStop(mono));
            }
            
            private IEnumerator CheckCoroutineStop(MonoBehaviour mono)
            {
                var countingCoroutine = mono.StartCoroutine(CountingCoroutine());
                
                // 停止用Coroutineを開始
                yield return mono.StartCoroutine(StopCoroutineAfterDelay(mono, countingCoroutine));
                
                var isValid = _count == 3;
                Debug.Log($"Question3: <color={(isValid ? "green" : "red")}>カウント: {_count}</color>");
            }
        }
    }
}
