using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Common.UI
{
    [RequireComponent(typeof(Button))]
    public class HoldButtonView : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [Header("Runtime Ref.")]
        UnityAction<bool> holdAction;       

        public void OnPointerUp ( PointerEventData eventData )
        {        
            holdAction?.Invoke( false );
        }

        public void OnPointerDown ( PointerEventData eventData )
        {
            holdAction?.Invoke( true );
        }

        public void SetHoldAction ( UnityAction<bool> _action )
        {
            holdAction = _action;
        }
    }
}
