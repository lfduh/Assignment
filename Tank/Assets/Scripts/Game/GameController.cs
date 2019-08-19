using UnityEngine;
using Assets.Scripts.Common.Base;
using Assets.Scripts.Game.Enumerations;

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
