using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ステートマシン
public class StateMachine
{
    // 現在のステート
    private State _currentState;

    // ステートリスト
    private readonly Dictionary<Type, State> _stateDic = new();

    // ステートの登録
    public void RegisterState(State state)
    {
        _stateDic[state.GetType()] = state;
    }

    // ステートの変更
    public void ChangeState<T>() where T : State
    {
        if (_stateDic.TryGetValue(typeof(T), out var state))
        {
            // Exit起動
            _currentState.Exit();


            _currentState = state;

            // Enter処理
            _currentState.Enter();
        }
        else
        {
            Debug.LogError("ステートが登録されていません");
        }
    }

    // Uodate処理
    public void Update()
    {
        _currentState.Update();
    }

    public State GetCurrentState()
    {
        return _currentState;
    }


}
