using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace _20250616
{
    public class TaskExample : MonoBehaviour
    {
        private CancellationTokenSource _cancellationTokenSource;

        private void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            // Taskを開始
            _ = BasicTaskAsync(_cancellationTokenSource.Token);
        }

        private void OnDestroy()
        {
            // オブジェクト破棄時にキャンセル
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }
        
        private async Task Wait1SecondAsync(int waitTime, CancellationToken cancellationToken)
        {
            await Task.Delay(1000, cancellationToken);
            Debug.Log($"{waitTime}秒経過!");
        }

        // Taskは戻り値がTaskである必要がある
        private async Task BasicTaskAsync(CancellationToken cancellationToken)
        {
            var waitTime = 0;
                
            // Escapeキー監視を開始
            // _ = WaitForEscapeKeyAsync();

            // 1秒待機
            waitTime += 1;
            await Wait1SecondAsync(waitTime, cancellationToken);
            
            // さらに1秒待機
            waitTime += 1;
            await Wait1SecondAsync(waitTime, cancellationToken);
            
            // さらに1秒待機
            waitTime += 1;
            await Wait1SecondAsync(waitTime, cancellationToken);
            
            // await WaitForKeyAsync(KeyCode.Space, 3);
            
            Debug.Log("Task終了");
        }
        
        // Spaceキーが押されるのを待つTask
        // 引数も受け取れる
        private async Task WaitForKeyAsync(KeyCode keyCode, int count)
        {
            Debug.Log($"{keyCode}キーが{count}回押されるのを待っています...");
            var keyCount = 0;
            
            while (keyCount < count )
            {
                await WaitForKeyAsync(keyCode);
                keyCount += 1;
                Debug.Log($"{keyCode}キーが{keyCount}回押されました");
                await Task.Delay(20);
            }
        }
        
        // Escapeキーで全てのTaskを中断する
        private async Task WaitForEscapeKeyAsync()
        {
            // Escapeキーが押されるまで待機
            await WaitForKeyAsync(KeyCode.Escape);
            
            // 全てのTaskを停止
            _cancellationTokenSource.Cancel();
            Debug.Log("全てのTaskを停止しました");
        }
        
        // 特定のキーが押されるまで待機
        private async Task WaitForKeyAsync(KeyCode keyCode)
        {
            while (!Input.GetKeyDown(keyCode))
            {
                await Task.Yield();
            }
        }
    }
}
