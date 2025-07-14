using System;
using UniRx;
using UnityEngine;

namespace _20250712
{
    /** イベントの発行側 */
    public class UniRxPublisher
    {
        /** 文字列メッセージを発行するSubject */
        private readonly Subject<string> _messageSubject = new();
        /** 外部から購読できるObservable */
        public IObservable<string> MessageStream => _messageSubject.AsObservable();
        
        /** カウンター */
        private readonly ReactiveProperty<int> _counter = new(0);
        public IReadOnlyReactiveProperty<int> CounterRP => _counter;
        
        /** 破棄 */
        private IDisposable _intervalDisposable;
        
        public void OnStart()
        {
            Debug.Log("Publisher: 開始しました");
        
            // Observableクラスには汎用的ななイベントを発行するためのメソッドがある
            // 定期的にメッセージを発行するIObservable<long>を生成
            _intervalDisposable = Observable.Interval(TimeSpan.FromSeconds(1))
                // 購読してメッセージを発行・Observable.Intervalはプッシュした回数を発行する
                .Subscribe(x => PublishMessage(x.ToString()));
        }
    
        /** 文字列メッセージを発行 */
        private void PublishMessage(string message)
        {
            _messageSubject.OnNext(message);
            // _counter.Value += 20;
        }
    
        public void Dispose()
        {
            Debug.Log("Publisher: 破棄されました");
            // Disposeを呼び出して購読を破棄
            _messageSubject.Dispose();
            _intervalDisposable.Dispose();
        }
    }
} 