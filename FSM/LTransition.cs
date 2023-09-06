using UnityEngine;
using System.Collections;

namespace FSM{

	public delegate bool LTransitionDelegate();

	public class LTransition : ITransition {

		public event LTransitionDelegate OnTransition;
		public event LTransitionDelegate OnCheck;

		public IState From {
			get {
				return _from;
			}
			set {
				_from = value;
			}
		}

		public IState To {
			get {
				return _to;
			}
			set {
				_to = value;
			}
		}

		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}

		public LTransition(string name,IState fromState,IState toState){
			_name = name;
			_from = fromState;
			_to = toState;
		}

		public bool TransitionCallback(){
			if (OnTransition != null) {
				return OnTransition();	
			}
			return true;
		}

		public bool ShouldBengin (){
			if (OnCheck!=null) {
				return OnCheck ();
			}
			return true;
		}

		private IState _from;	// 原状态
		private IState _to;		// 目标状态
		private string _name;	// 过渡名

	}
}
