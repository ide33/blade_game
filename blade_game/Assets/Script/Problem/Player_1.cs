using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1 : MonoBehaviour
{
    // StateMachine
    private StateMachine _stateMachine;

    private void Start()
    {
        _stateMachine = new StateMachine();

        // ステート登録
        _stateMachine.RegisterState(new IdleState(this, _stateMachine));
        _stateMachine.RegisterState(new JumpState(this, _stateMachine));

        // 待機状態から開始
        _stateMachine.ChangeState<IdleState>();
    }

    private void Update()
    {
        _stateMachine.GetCurrentState().Update();
        
        // 着地判定
        if (transform.position.y <= 0)
        {
            _stateMachine.GetCurrentState().OnLand();
        }
    }
}
