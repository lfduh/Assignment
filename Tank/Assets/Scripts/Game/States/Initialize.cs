using UnityEngine;
using Assets.Scripts.Common;
using Assets.Scripts.Common.Base;
using Assets.Scripts.Common.Utilities;
using Assets.Scripts.Game.Enumerations;
using Assets.Scripts.Tank;
using Assets.Scripts.Tank.Enumerations;
using Assets.Scripts.Map;

namespace Assets.Scripts.Game.States
{
    public class Initialize : GameState
    {        
        void Start ()
        {  
            var newTank = CreateTank();
            controller.view.SetDirectionButtonHoldAction( newTank.Foward, newTank.Backward, newTank.RotateLeft, newTank.RotateRight );
            controller.view.SetFireButtonAction( newTank.Fire );
            controller.view.SetChangeButtonAction( newTank.ChangeTank );

            var newTraceCamera = Camera.main.gameObject.AddComponent<TraceCamera>();
            newTraceCamera.SetTarget( newTank.transform );
            newTank.gameObject.AddComponent<MapGenerater>();

            var newTrans = new Transition<GameStateType>();
            newTrans.preState = GameStateType.Initialize;
            newTrans.nextState = GameStateType.Normal;
            controller.ChangeState( newTrans );
        }

        TankController CreateTank ()
        {
            var tankAsset = (GameObject)Resources.Load( Constants.ResourcePath.Game.TANK );
            var newTank = Instantiate( tankAsset, Vector3.zero, Quaternion.identity ).AddComponent<TankController>();
            newTank.Initial( TankType.Red );      
            return newTank;
        }
    }
}
