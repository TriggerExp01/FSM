using System;
using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    
    public Animator Animator;
    public AudioSource AudioSource;
    public CharacterController CharacterController;


    public void Attack()
    {
        
    }

    public void Move()
    {
        
    }

    public void Idle()
    {
        
    }

    public void Hit()
    {
        
    }

    public void Die()
    {
        
    }
    
    
    private MonsterStateController msc;
    public void Start()
    {
        msc = new MonsterStateController(this);
    }

    public void Update()
    {
        msc.StateMachine.UpdateCallback(Time.deltaTime);
    }
}