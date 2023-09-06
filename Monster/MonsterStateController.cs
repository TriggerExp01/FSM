using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

public class MonsterStateController
{
    public LStateMachine StateMachine;
    public MonsterAttack MonsterAttackState;
    public MonsterHit MonsterHitState;
    public MonsterMove MonsterMoveState;
    public MonsterIdle MonsterIdleState;
    public MonsterDie MonsterDieState;

    private MonsterController _monsterController;
    public MonsterStateController(MonsterController monsterController)
    {
        _monsterController = monsterController;
        MonsterAttackState = new MonsterAttack("MonsterAttack",_monsterController);
        MonsterHitState = new MonsterHit("MonsterHit",_monsterController);
        MonsterMoveState = new MonsterMove("MonsterMove",_monsterController);
        MonsterIdleState = new MonsterIdle("MonsterIdle",_monsterController);
        MonsterDieState = new MonsterDie("MonsterDie",_monsterController);
        StateMachine = new LStateMachine("MonsterStateMachine",MonsterDieState.State);
        
        // attack 2 other
        var attack2Hit = new LTransition("attack2Hit", MonsterAttackState.State, MonsterHitState.State);
        attack2Hit.OnCheck += Attack2HitCondition;
        var attack2Move = new LTransition("attack2Move", MonsterAttackState.State, MonsterMoveState.State);
        attack2Move.OnCheck += Attack2MoveCondition;
        var attack2Idle = new LTransition("attack2Idle", MonsterAttackState.State, MonsterIdleState.State);
        attack2Idle.OnCheck += Attack2IdleCondition;
        var attack2Die = new LTransition("attack2Die", MonsterAttackState.State, MonsterDieState.State);
        attack2Die.OnCheck += Attack2DieCondition;
        
        
        // idle 2 other
        var idle2Hit = new LTransition("idle2Hit", MonsterIdleState.State, MonsterHitState.State);
        attack2Hit.OnCheck += Idle2HitCondition;
        var idle2Move = new LTransition("idle2Move", MonsterIdleState.State, MonsterMoveState.State);
        idle2Move.OnCheck += Idle2MoveCondition;
        var idle2Attack = new LTransition("idle2Attack", MonsterIdleState.State, MonsterAttackState.State);
        idle2Attack.OnCheck += Idle2AttackCondition;
        var idle2Die = new LTransition("idle2Die", MonsterIdleState.State, MonsterDieState.State);
        idle2Die.OnCheck += Idle2DieCondition;
        
    }

    #region  attack 2 other

    private bool Attack2HitCondition()
    {
        
        return true;
    }
    
    private bool Attack2IdleCondition()
    {
        return true;
    }
    private bool Attack2MoveCondition()
    {
        return true;
    }
    private bool Attack2DieCondition()
    {
        return true;
    }
    #endregion
  
    
    #region idle 2 other

    private bool Idle2HitCondition()
    {
        return true;
    }
    
    private bool Idle2MoveCondition()
    {
        return true;
    }
    private bool Idle2AttackCondition()
    {
        return true;
    }
    private bool Idle2DieCondition()
    {
        return true;
    }
    #endregion

}
