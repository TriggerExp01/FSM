using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;


public class MonsterAttack
{
    public LState State;
    private MonsterController _monsterController;
    public MonsterAttack(string name , MonsterController monsterController)
    {
        State = new LState(name);
        _monsterController = monsterController;
        State.OnExit += OnExit;
        State.OnEnter += OnEnter;
        State.OnUpdate += OnUpdate;
    }

    private void OnExit(IState state)
    {
        // todo 效果表现
    }

    private void OnEnter(IState state)
    {
        // todo 效果表现
    }

    private void OnUpdate(float f)
    {
        // todo 效果表现
    }
}


public class MonsterHit
{
    public LState State;
    private MonsterController _monsterController;
    public MonsterHit(string name , MonsterController monsterController)
    {
        State = new LState(name);
        _monsterController = monsterController;
        State.OnExit += OnExit;
        State.OnEnter += OnEnter;
        State.OnUpdate += OnUpdate;
    }

    private void OnExit(IState state)
    {
        // todo 效果表现
    }

    private void OnEnter(IState state)
    {
        // todo 效果表现
    }

    private void OnUpdate(float f)
    {
        // todo 效果表现
    }
}

public class MonsterMove
{
    public LState State;
    private MonsterController _monsterController;
    public MonsterMove(string name , MonsterController monsterController)
    {
        State = new LState(name);
        _monsterController = monsterController;
        State.OnExit += OnExit;
        State.OnEnter += OnEnter;
        State.OnUpdate += OnUpdate;
        
    }

    private void OnExit(IState state)
    {
        // todo 效果表现
    }

    private void OnEnter(IState state)
    {
        // todo 效果表现
    }

    private void OnUpdate(float f)
    {
        // todo 效果表现
    }
}

public class MonsterIdle
{
    public LState State;
    private MonsterController _monsterController;
    public MonsterIdle(string name , MonsterController monsterController)
    {
        State = new LState(name);
        _monsterController = monsterController;
        State.OnExit += OnExit;
        State.OnEnter += OnEnter;
        State.OnUpdate += OnUpdate;
    }

    private void OnExit(IState state)
    {
        // todo 效果表现
    }

    private void OnEnter(IState state)
    {
        // todo 效果表现
    }

    private void OnUpdate(float f)
    {
        // todo 效果表现
    }
}

public class MonsterDie
{
    public LState State;
    private MonsterController _monsterController;
    public MonsterDie(string name , MonsterController monsterController)
    {
        State = new LState(name);
        _monsterController = monsterController;
        State.OnExit += OnExit;
        State.OnEnter += OnEnter;
        State.OnUpdate += OnUpdate;
    }

    private void OnUpdate(float f)
    {
        // todo 效果表现
    }

    private void OnExit(IState state)
    {
        // todo 效果表现
    }

    private void OnEnter(IState state)
    {
        // todo 效果表现
    }
}