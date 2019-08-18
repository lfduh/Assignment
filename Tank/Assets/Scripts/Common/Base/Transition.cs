using System;

namespace Assets.Scripts.Common.Base
{
	public class Transition<T> where T: struct, IComparable, IConvertible, IFormattable //Enum
	{
		public T? preState;
		public T nextState;
		object[] param;
		
		public void SetParams ( params object[] _params )
		{
			param = _params;
		}

		public object[] GetParams ()
		{
			return param;
		}
	}
}
