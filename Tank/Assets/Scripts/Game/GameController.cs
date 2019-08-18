using UnityEngine;
using Assets.Scripts.Game.Enumerations;
using Assets.Scripts.Common.Base;

namespace Assets.Scripts.Game
{
    [RequireComponent(typeof(GameView))]
    public class GameController : ControllerBase<GameStateType>
    {
        [Header("Runtime Ref.")]
        public GameView view;

        void Awake ()
        {
            view = GetComponent<GameView>();   
        }

        void Start ()
        {            
            var newTrans = new Transition<GameStateType>();
            newTrans.preState = null;
            newTrans.nextState = GameStateType.Initialize;
            ChangeState( newTrans );
        } 
    }
}
