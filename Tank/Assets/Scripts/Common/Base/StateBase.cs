using System;
using UnityEngine;

namespace Assets.Scripts.Common.Base
{
    public class StateBase<T> : MonoBehaviour where T : struct, IComparable, IConvertible, IFormattable // Enum
    {
        protected ControllerBase<T> controller;

        public virtual StateBase<T> Initial ( ControllerBase<T> _controller, Transition<T> _trans )
        {
            controller = _controller;
            return this;
        }		
    }
}
