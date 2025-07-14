using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace _20250712
{
    /** 購読側 */
    public class UniRxSubscriber : MonoBehaviour
    {
        /** 発行側 */
        private UniRxPublisher _publisher;
        
        private Button _helloButton;
    
        private void Start()
        {
            Debug.Log("Subscriber: 開始しました");

            _publisher = new UniRxPublisher();
            _publisher.OnStart();
            
            // 発行側のメッセージを購読
            _publisher.MessageStream.Subscribe(OnMessageReceived)
                // Monobehaviourの破棄時に自動的に購読解除
                .AddTo(this);
            
            // 発行側のカウンターを購読
            _publisher.CounterRP.Subscribe(OnCounterUpdated).AddTo(this);
        }
        
        /** 文字列メッセージを受信した時の処理 */
        private void OnMessageReceived(string message)
        {
            Debug.Log($"Subscriber: メッセージを受信: {message}");
        }
        
        private void OnCounterUpdated(int count)
        {
            Debug.Log($"Subscriber: カウンターの値が更新されました: {count}");
        }
        
        private void OnDestroy()
        {
            Debug.Log("Subscriber: 破棄されました");
            // 発行側のDisposeを呼び出して購読を破棄
            _publisher.Dispose();
        }
    }
} 