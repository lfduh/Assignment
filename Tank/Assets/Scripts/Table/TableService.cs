using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts.Common;
using Assets.Scripts.Common.Utilities;
using Assets.Scripts.Tank.Enumerations;

namespace Assets.Scripts.Table
{
    public class TableService : PrefabSingleton<TableService>
    {
        [Header( "Runtime Ref." )]        
        GameTable gameTable;
        Dictionary<TankType, short> damageTableCache;

        public TableService Initial ()
        {
            return this;
        }

        void Start ()
        {
            gameTable = (GameTable)Resources.Load( Constants.ResourcePath.Table.GAMETABLE );
            damageTableCache = gameTable.damageTable.ToDictionary( _pair => _pair.tankType, _pair => _pair.damage );            
        }

        public short GetHayHealthPoint ()
        {
            return gameTable.hayHealthPoint;
        }

        public float GetTankMoveSpeed ()
        {
            return gameTable.tankMoveSpeed;
        }

        public float GetTankRotateSpeed ()
        {
            return gameTable.tankRotateSpeed;
        }

        public short GetDamagePoint ( TankType _bulletType )
        {
            return damageTableCache[_bulletType];
        }    
        
        public float GetBulletSpeed ()
        {
            return gameTable.bulletSpeed;
        }

        public float GetBulletOffsetFactor ()
        {
            return gameTable.bulletOffsetFactor;
        }
    }
}
