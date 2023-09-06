using UnityEngine;
using System.Collections;

namespace FSM{
	public interface ITransition {

		IState From{get;set;}

		IState To{get;set;}
		string Name{ get; set; }
		bool TransitionCallback();
		bool ShouldBengin ();
	}
}
