using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace FSM{
	public interface IState  {

		string Name{get;}
		string Tag{ get; set; }

		IStateMachine Parent{get;set;}
		float Timer{get;}
		List<ITransition> Transitions{get;}

		void EnterCallback (IState prev);
		void ExitCallback (IState next);
		void UpdateCallback (float deltaTime);
		void AddTransition (ITransition t);
	}
}
