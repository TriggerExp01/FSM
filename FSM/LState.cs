using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FSM{
	
	public delegate void LStateDelegate();
	public delegate void LStateDelegateState(IState state);
	public delegate void LStateDelegateFloat(float f);

	public class LState : IState {

		public event LStateDelegateState OnEnter;

		public event LStateDelegateState OnExit;

		public event LStateDelegateFloat OnUpdate;

		public string Name {
			get {
				return _name;
			}
		}

		public string Tag {
			get {
				return _tag;
			}
			set {
				_tag = value;
			}
		}

		public IStateMachine Parent{
			get {
				return _parent;
			}
			set {
				_parent = value;
			}
		}

		public float Timer{
			get {
				return _timer;
			}
		}

		public List<ITransition> Transitions{
			get{ 
				return _transitions;
			}
		}

		public void AddTransition(ITransition t){
			if (t != null && !_transitions.Contains (t)) {
				_transitions.Add (t);	
			}
		}

		public LState(string name){
			_name = name;
			_transitions = new List<ITransition> ();
		}

		public virtual void EnterCallback (IState prev)
		{
			// 进入状态时调用 OnEnter 事件
			_timer = 0f;
			if (OnEnter != null) {
				OnEnter (prev);
			}
		}

		public virtual void ExitCallback (IState next)
		{
			_timer = 0f;
			// 离开状态时调用 OnExit 事件
			if (OnExit != null) {
				OnExit (next);
			}
		}
		
		public virtual void UpdateCallback (float deltaTime)
		{
			_timer += deltaTime;
			// Update 时调用 OnUpdate 事件
			if (OnUpdate != null) {
				OnUpdate (deltaTime);
			}
		}


		private string _name;		// 状态名
		private string _tag;		// 状态标签
		private float _timer;		// 计时器
		private IStateMachine _parent; //当前状态的状态机
		private List<ITransition> _transitions; //状态过渡
	}
}
