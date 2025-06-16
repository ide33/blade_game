using System.Collections;
using UnityEngine;

namespace _20250616
{
    public class CoroutineExample : MonoBehaviour
    {
        private void Start()
        {
            // Coroutineを開始
            StartCoroutine(BasicCoroutine());
            Debug.Log("Start()メソッド終了");
        }

        // Coroutineは戻り値がIEnumeratorである必要がある
        private IEnumerator BasicCoroutine()
        {
            Debug.Log("Coroutine開始");
            
            StartCoroutine(WaitForEscapeKey());

            var waitTime = 0;
        
            // 1秒待機
            yield return new WaitForSeconds(1f);
            
            waitTime += 1;
            Debug.Log($"{waitTime}秒経過");
        
            // さらに1秒待機
            yield return new WaitForSeconds(1f);
            
            waitTime += 1;
            Debug.Log($"{waitTime}秒経過");
            
            // さらに1秒待機
            yield return new WaitForSeconds(1f);
            
            waitTime += 1;
            Debug.Log($"{waitTime}秒経過");
            
            // コルーチン内で他のコルーチンを呼び出すことも可能
            yield return StartCoroutine(WaitForKey(KeyCode.Space, 3));
            yield return StartCoroutine(WaitForUpdate());
            
            Debug.Log("Coroutine終了");
        }
        
        // Spaceキーが押されるのを待つCoroutine
        // 引数も受け取れる
        private IEnumerator WaitForKey(KeyCode keyCode, int count)
        {
            Debug.Log($"{keyCode}キーが{count}回押されるのを待っています...");
            var keyCount = 0;
            while (keyCount < count)
            {
                // キーが押されるまで待機
                yield return new WaitUntil(() => Input.GetKeyDown(keyCode));
                
                keyCount += 1;
                Debug.Log($"{keyCode}キーが{keyCount}回押されました");
                
                yield return new WaitUntil(() => !Input.GetKey(keyCode));
            }
        }
        
        private IEnumerator WaitForUpdate()
        {
            Debug.Log("Update待機...");
            // Updateが呼ばれるまで待機
            yield return null;
            Debug.Log("Update完了");
        }
        
        // Escapeキーで全てのコルーチンを中断する
        private IEnumerator WaitForEscapeKey()
        {
            // Escapeキーが押されるまで待機
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
            
            // 全てのコルーチンを停止
            StopAllCoroutines();
            Debug.Log("全てのコルーチンを停止しました");
        }
    }
}
