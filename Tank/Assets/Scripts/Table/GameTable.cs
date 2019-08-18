using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Tank.Enumerations;

namespace Assets.Scripts.Table
{
    public class GameTable : ScriptableObject
    {
        [Serializable]
        public class DamagePair
        {
            public TankType tankType;
            public short damage;
        }

        public List<DamagePair> damageTable;
        public short hayHealthPoint;

        public float tankMoveSpeed;
        public float tankRotateSpeed;

        public float bulletSpeed;
        public float bulletOffsetFactor;
    }
}
