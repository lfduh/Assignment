using UnityEngine;
using Assets.Scripts.Tank.Enumerations;
using Assets.Scripts.Table;
using Assets.Scripts.Common.Modifiers;

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
            gameObject.AddComponent<BoxCollider>();
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

        void OnTriggerEnter2D ( Collider2D collision )
        {
            Destroy( gameObject );
        }
    }
}
