﻿using System;
using UnityEngine;
using Assets.Scripts.Common.Utilities;

namespace Assets.Scripts.Common.Base
{
    [RequireComponent( typeof( SingletonAwaker ) )]
    public class ControllerBase<T> : MonoBehaviour where T: struct, IComparable, IConvertible, IFormattable // Enum
	{
		protected StateBase<T> currentState;

		public void ChangeState ( Transition<T> _transition )
		{
			if( currentState ) Destroy( currentState );

			string myNameSpace = GetType().Namespace;
			string stateFullName = myNameSpace + ".States." + _transition.nextState;            
                       
            var type = Type.GetType( stateFullName );
			var state = (StateBase<T>)gameObject.AddComponent( type );
			currentState = state;

			InitialState( this, _transition );
		}

		public virtual void InitialState ( ControllerBase<T> _controller, Transition<T> _trans )
		{			
			currentState.Initial( _controller, _trans );
		}
	}
}
