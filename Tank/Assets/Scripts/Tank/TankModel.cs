using UnityEngine;
using Assets.Scripts.Tank.Enumerations;

namespace Assets.Scripts.Tank
{
    public class TankModel : MonoBehaviour
    {
        [Header("Runtime Value.")]
        public TankType tankType;

        [Space(10)]
        public float moveSpeed;
        public float rotateSpeed;

        [Space( 10 )]
        public bool isMoveFoward;
        public bool isMoveBackward;

        [Space( 10 )]
        public bool isRotateLeft;
        public bool isRotateRight;

        [Space( 10 )]
        public float bulletOffsetFactor;
    }
}
