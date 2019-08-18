using UnityEngine;
using Assets.Scripts.Tank.Enumerations;
using Assets.Scripts.Table;
using Assets.Scripts.Common.Modifiers;
using Assets.Scripts.Hay;   

namespace Assets.Scripts.Bullet
{
    [RequireComponent(typeof(BulletView))]
    public class BulletController : MonoBehaviour
    {
        [Header( "Runtime Ref." )]
        [SerializeField] BulletView view;
        
        [Header("Runtime Value")]
        [SerializeField] TankType tankType;        
        [SerializeField] float bulletSpeed;

        void Awake ()
        {
            view = GetComponent<BulletView>();
            var coll = gameObject.AddComponent<BoxCollider2D>();
            coll.isTrigger = true;
            gameObject.AddComponent<Rigidbody2D>();
        }

        public void Initial ( TankType _tankType, Quaternion _rotation )
        {
            transform.rotation = _rotation;
            tankType = _tankType;
        }

        void Start ()
        {
            view.SetColor( tankType );
            bulletSpeed = TableService.Instance.GetBulletSpeed();
        }

        void Update ()
        {
            var directionVector = transform.rotation * Vector3.up;
            transform.position += Time.deltaTime * directionVector * bulletSpeed;
        }

        void OnTriggerEnter2D ( Collider2D _collision )
        {
            if( _collision.tag == "Hay" )
            {
                var hay = _collision.GetComponent<HayController>();
                new HealthModifier( hay, tankType );                
            }

            Destroy( gameObject );
        }
    }
}
