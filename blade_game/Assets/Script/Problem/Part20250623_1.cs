using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace _20250623
{
    public class Part20250623_1 : MonoBehaviour
    {
        private void Start()
        {
            // _ = new Question1().CheckAnswerAsync();
            // _ = new Question2().CheckAnswerAsync();
            _ = new Question3().CheckAnswerAsync();
        }
        
        // ログを追加しつつ出力する
        private static void LogAddAndOutput(List<string> logs, string message)
        {
            logs.Add(message);
            Debug.Log(message);
        }
        
        /**
         * 問1 Taskの並列実行
         * 期待される出力: "3秒待機 -> 2秒待機 -> 1秒待機 -> 1秒経過 -> 2秒経過 -> 3秒経過"
         */
        private class Question1
        {
            private readonly List<string> _logs = new();
            
            // 非同期処理
            private async Task ProgressAsync(int delayTime)
            {
                LogAddAndOutput(_logs, $"{delayTime / 1000}秒待機");
                
                // 指定された時間だけ待機
                await Task.Delay(delayTime);
                
                LogAddAndOutput(_logs, $"{delayTime / 1000}秒経過");
            }

            // 処理を平行に実行する
            private void StartParallelTasks()
            {
                // TODO 引数を調整して期待される出力を得る
                _ = ProgressAsync(3000);
                _ = ProgressAsync(2000);
                _ = ProgressAsync(1000);
            }

            public async Task CheckAnswerAsync()
            {
                StartParallelTasks();
                
                // 4秒待機してからログの中をチェック
                await Task.Delay(4000);
                
                var result = string.Join(" -> ", _logs);
                var isValid = result == "3秒待機 -> 2秒待機 -> 1秒待機 -> 1秒経過 -> 2秒経過 -> 3秒経過";
                
                Debug.Log($"Question1: <color={(isValid ? "green" : "red")}> {result}</color>");
                
                await Task.CompletedTask;
            }
        }

        /**
         * 問2：Taskの待機
         * 期待される出力: "Task開始 -> 1秒待機完了 -> Task終了"
         */
        private class Question2
        {
            private readonly List<string> _logs = new();
            
            // ステージをロードする非同期関数
            private async Task LoadStageAsync()
            {
                LogAddAndOutput(_logs, "ロード開始");
                
                // ロード処理を1秒待機とする。
                await Task.Delay(1000);
                
                LogAddAndOutput(_logs, "ロード完了");
            }

            // ステージの開始処理
            // TODO 非同期関数にする
            private async Task StartStageAsync()
            {
                // TODO ロード処理の完了を待つ
                await LoadStageAsync();
                LogAddAndOutput(_logs, "ステージ開始");
            }

            public async Task CheckAnswerAsync()
            {
                // TODO ステージの開始処理の完了を待つ
                await StartStageAsync();
                
                var result = string.Join(" -> ", _logs);
                var isValid = result == "ロード開始 -> ロード完了 -> ステージ開始";
                
                Debug.Log($"Question1: <color={(isValid ? "green" : "red")}> {result}</color>");
                
                await Task.CompletedTask;
            }
        }
        
        
        /**
         * 問2：複数Taskの待機
         * 期待される出力: "処理開始 -> 処理終了 -> 5秒経過"
         */
        private class Question3
        {
            private readonly List<string> _logs = new();
            
            // ランダムな時間で完了する処理クラス
            private class RandomProgress
            {
                private readonly string _name;
                private bool _isCompleted;
                
                public RandomProgress(string name)
                {
                    _name = name;
                    _isCompleted = false;
                }

                // タスクを完了させる非同期処理
                public async Task CompleteAsync()
                {
                    // 完了するまでの時間を1 ~ 5秒でランダムに設定
                    var complete = Random.Range(1000, 5000);
                    await Task.Delay(complete);
                    Debug.Log($"{_name} 完了 ({complete / 1000}秒)");
                    _isCompleted = true;
                }
                
                // 完了しているか
                public bool IsCompleted()
                {
                    return _isCompleted;
                }
            }

            // 処理の完了
            private async Task TaskCompleteAsync(List<RandomProgress> progresses)
            {
                LogAddAndOutput(_logs, "処理開始");

                // TODO 処理を平行に実行し、全てが完了するまで待機する
                // ヒント: Task.WhenAll()は引数に取ったTask集合を全て処理するTaskを返す
                var tasks = progresses.Select(p => p.CompleteAsync()).ToList();
                await Task.WhenAll(tasks);

                LogAddAndOutput(_logs, "処理終了");
                
            }

            public async Task CheckAnswerAsync()
            {
                // ランダムな処理を生成
                var progresses = new List<RandomProgress>
                {
                    new RandomProgress("処理1"),
                    new RandomProgress("処理2"),
                    new RandomProgress("処理3"),
                    new RandomProgress("処理4"),
                    new RandomProgress("処理5")
                };
                
                _ = TaskCompleteAsync(progresses);
                
                // 5秒待機
                await Task.Delay(5000);
                LogAddAndOutput(_logs, "5秒経過");
                
                // 以下チェック処理
                
                string result;
                bool isValid;
                
                if (progresses.Any(t => !t.IsCompleted()))
                {
                    result = "完了していない処理があります";
                    isValid = false;
                }
                else
                {
                    result = string.Join(" -> ", _logs);
                    isValid = result == "処理開始 -> 処理終了 -> 5秒経過";
                }
                
                Debug.Log($"Question1: <color={(isValid ? "green" : "red")}> {result}</color>");
                
                await Task.CompletedTask;
            }
        }


    }
}
