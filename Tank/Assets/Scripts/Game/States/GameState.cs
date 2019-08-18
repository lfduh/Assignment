using Assets.Scripts.Common.Base;
using Assets.Scripts.Game.Enumerations;

namespace Assets.Scripts.Game.States
{
    public class GameState : StateBase<GameStateType>
    {
        protected new GameController controller
        {
            get
            {
                return base.controller as GameController;
            }
        }
    }
}
