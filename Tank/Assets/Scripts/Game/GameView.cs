using UnityEngine;
using UnityEngine.Events;
using Assets.Scripts.Common.Utilities;
using Assets.Scripts.Common.UI;

namespace Assets.Scripts.Game
{
    public class GameView : MonoBehaviour
    {
        [Header( "Runtime Ref." )]
        [SerializeField] TraceCamera gameCamera;
        [SerializeField] GameAsset asset;

        [SerializeField] HoldButtonView upButtonView;
        [SerializeField] HoldButtonView downButtonView;
        [SerializeField] HoldButtonView leftButtonView;
        [SerializeField] HoldButtonView rightButtonView;

        void Awake ()
        {
            asset = FindObjectOfType<GameAsset>();
            gameCamera = FindObjectOfType<TraceCamera>();
        }

        void Start ()
        {
            upButtonView = asset.upButton.gameObject.AddComponent<HoldButtonView>();
            downButtonView = asset.downButton.gameObject.AddComponent<HoldButtonView>();
            leftButtonView = asset.leftButton.gameObject.AddComponent<HoldButtonView>();
            rightButtonView = asset.rightButton.gameObject.AddComponent<HoldButtonView>();
        }

        public void SetDirectionButtonHoldAction ( UnityAction<bool> _upAction, UnityAction<bool> _downAction, UnityAction<bool> _leftAction, UnityAction<bool> _rightAction )
        {
            upButtonView.SetHoldAction( _upAction );
            downButtonView.SetHoldAction( _downAction );
            leftButtonView.SetHoldAction( _leftAction );
            rightButtonView.SetHoldAction( _rightAction );
        }              

        public void SetFireButtonAction ( UnityAction _action )
        {
            asset.fireButton.onClick.RemoveAllListeners();
            if( _action == null ) return;
            asset.fireButton.onClick.AddListener( _action );
        }

        public void SetChangeButtonAction ( UnityAction _action )
        {
            asset.changeButton.onClick.RemoveAllListeners();
            if( _action == null ) return;
            asset.changeButton.onClick.AddListener( _action );
        }  
    }
}
