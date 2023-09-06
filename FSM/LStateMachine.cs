﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FSM{

	public class LStateMachine : LState, IStateMachine {
		

		public IState CurrentState {
			get {
				return _currentState;
			}
		}

		public IState DefaultState {
			get {
				return _defaultState;
			}
			set {
				AddState (value);
				_defaultState = value;
			}
		}

		public LStateMachine(string name,IState defaultState) : base (name){
			_states = new List<IState> ();
            _anyStateTransitions = new List<ITransition>();
			_defaultState = defaultState;
		}

		public void AddState (IState state)
		{
			if (state != null && !_states.Contains (state)) {
				_states.Add (state);
				state.Parent = this;
				if (_defaultState==null) {
					_defaultState = state;
				}
			}
		}

		public void RemoveState (IState state){
			// 状态机运行过程中,不能删除当前状态
			if (_currentState == state) {
				return;
			}
			if (state != null && _states.Contains (state)) {
				_states.Remove (state);	
				state.Parent = null;
				if (_defaultState == state) {
					_defaultState = (_states.Count >= 1) ? _states [0] : null;
				}
			}
		}

		public IState GetStateWithTag (string tag)
		{
			return null;
		}

		public override void EnterCallback (IState prev)
		{
			base.EnterCallback (prev);
			_currentState.EnterCallback (prev);
		}

		public override void ExitCallback (IState next)
		{
			base.ExitCallback (next);
			_currentState.ExitCallback (next);
		}

		public override void UpdateCallback (float deltaTime)
		{
			if (_isTransition) {
				if (_t.TransitionCallback()) {
					DoTransition (_t);
					_isTransition = false;
				}
				return;
            }

            base.UpdateCallback (deltaTime);

            int count = _anyStateTransitions.Count;

            if (_currentState == null) {
                _currentState = _defaultState;
            }

            for (int i = 0; i < count; i++)
            {
                ITransition t = _anyStateTransitions [i];
                if (t.To!= _currentState && t.ShouldBengin())
                {
                    _isTransition = true;
                    _t = t;
                    return;
                }
            }

			List<ITransition> ts = _currentState.Transitions;
			count = ts.Count;
			for (int i = 0; i < count; i++) {
				ITransition t = ts [i];
				if (t.ShouldBengin()) {
					_isTransition = true;
					_t = t;
					return;
				}
			}
			_currentState.UpdateCallback (deltaTime);
		}

        private IState _tempState;
		// 开始进行过渡
		private void DoTransition(ITransition t){
            _tempState = _currentState;
			_currentState.ExitCallback (t.To);
			_currentState = t.To;
            if (t.From != null)
            {
                _tempState = t.From;
            }
            _currentState.EnterCallback(_tempState);
		}

		private IState _currentState;	// 当前状态
		private IState _defaultState;	// 默认状态
		private List<IState> _states;	// 所有状态


		private bool _isTransition=false;	// 是否在过渡
		private ITransition _t;			// 当前正在执行的过渡

        private List<ITransition> _anyStateTransitions;     // 任何状态下的过渡

        public void AddAnyState(ITransition t)
        {
            if (_anyStateTransitions.Contains(t))
                return;
            t.From = null;
            _anyStateTransitions.Add(t);
        }
	}
}
