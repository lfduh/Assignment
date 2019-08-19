using System;
using UnityEngine;
using Assets.Scripts.Common.Services;
using Assets.Scripts.Bullet;
using Assets.Scripts.Common;
using Assets.Scripts.Table;
using Assets.Scripts.Tank.Enumerations;

namespace Assets.Scripts.Tank
{
    [RequireComponent(typeof(TankView))]
    [RequireComponent(typeof(TankModel))]
    public class TankController : MonoBehaviour
    {
        [Header( "Runtime Ref." )]
        [SerializeField] TankView view;
        [SerializeField] TankModel model;
        [SerializeField] BulletAsset bulletPrefab;
                
        void Awake ()
        {
            view = GetComponent<TankView>();
            model = GetComponent<TankModel>();          
        }

        public void Initial ( TankType _tankType )
        {
            model.tankType = _tankType;
        }

        void Start ()
        {
            view.SetColor( model.tankType );

            gameObject.AddComponent<BoxCollider2D>();
            gameObject.AddComponent<Rigidbody2D>();

            model.moveSpeed = TableService.Instance.GetTankMoveSpeed();
            model.rotateSpeed = TableService.Instance.GetTankRotateSpeed();
            model.bulletOffsetFactor = TableService.Instance.GetBulletOffsetFactor();

            InputService.Instance.upPressed.AddListener( Foward );
            InputService.Instance.downPressed.AddListener( Backward );
            InputService.Instance.leftPressed.AddListener( RotateLeft );
            InputService.Instance.rightPressed.AddListener( RotateRight );

            InputService.Instance.zPressed.AddListener( ChangeTank );
            InputService.Instance.spacePressed.AddListener( Fire );

            bulletPrefab = ((GameObject)Resources.Load( Constants.ResourcePath.Game.BULLET )).GetComponent<BulletAsset>();            
        }

        void Update()
        {
            UpdateRotation();
            UpdatePosition();
        }

        void UpdateRotation ()
        {
            var vector = Convert.ToInt16( model.isRotateLeft ) - Convert.ToInt16( model.isRotateRight );
            transform.Rotate( vector * Vector3.forward * model.rotateSpeed );
        }

        void UpdatePosition ()
        {
            var directionVector = transform.rotation * Vector3.up;
            var fowardVector = Convert.ToInt16( model.isMoveFoward ) - Convert.ToInt16( model.isMoveBackward );
            transform.position += fowardVector * directionVector * Time.deltaTime * model.moveSpeed;
        }

        public void Foward ( bool _active )
        {
            model.isMoveFoward = _active;            
        }

        public void Backward ( bool _active )
        {
            model.isMoveBackward = _active;
        }

        public void RotateLeft ( bool _active )
        {
            model.isRotateLeft = _active;
        }

        public void RotateRight ( bool _active )
        {
            model.isRotateRight = _active;
        }

        public void Fire ()
        {
            var newBulletAsset = Instantiate( bulletPrefab, transform.position + model.bulletOffsetFactor * ( transform.rotation * Vector3.up ), transform.rotation );
            var newBullet = newBulletAsset.gameObject.AddComponent<BulletController>();
            newBullet.Initial( model.tankType, transform.rotation );
        }

        public void ChangeTank ()
        {
            var index = (int)model.tankType + 1;
            model.tankType = (TankType)(index % 3);
            view.SetColor( model.tankType );
        }
    }
}
