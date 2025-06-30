using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public abstract class State
{
    protected readonly Player_1 Player_1;
    protected readonly StateMachine StateMachine;

    protected State(Player_1 player_1, StateMachine stateMachine)
    {
        Player_1 = player_1;
        StateMachine = stateMachine;
    }
    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void OnLand()
    {

    }
}

// 待機状態
public class IdleState : State
{
    public IdleState(Player_1 player_1, StateMachine stateMachine) : base(player_1, stateMachine)
    {

    }

    public override void Enter()
    {
        Debug.Log("待機開始");
    }

    public override void Exit()
    {
        Debug.Log("待機終了");
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ジャンプ状態に遷移
            StateMachine.ChangeState<JumpState>();
        }
    }
}

// ジャンプ状態
public class JumpState : State
{
    private float _jumpPower;
    private const float PlayerJumpPower = 0.01f;

    public JumpState(Player_1 player_1, StateMachine stateMachine) : base(player_1, stateMachine)
    {

    }

    public override void Enter()
    {
        Debug.Log("ジャンプ開始");
        _jumpPower = PlayerJumpPower;
    }

    public override void Update()
    {
        _jumpPower -= PlayerJumpPower * Time.deltaTime;
        Player_1.transform.localPosition += Vector3.up * _jumpPower;
    }

    public override void Exit()
    {
        Debug.Log("ジャンプ終了");
    }

    public override void OnLand()
    {
        Debug.Log("着地しました");
        Player_1.transform.localPosition = Vector3.zero;
        StateMachine.ChangeState<IdleState>();
    }
}
