using System;
using UnityEngine;
using Assets.Scripts.Bullet;
using Assets.Scripts.Table;
using Assets.Scripts.Common.Modifiers;

namespace Assets.Scripts.Hay
{
    public class HayController : MonoBehaviour
    {
        [Header( "Runtime Value." )]
        [SerializeField] short healthPoint;

        void Start ()
        {
            healthPoint = TableService.Instance.GetHayHealthPoint();
        }

        /*
        public void SubHealth ( short _point )
        {
            healthPoint -= _point;
            if( healthPoint <= 0 )
            {
                Destroy( gameObject );
            }
        }
        */

        void OnTriggerEnter2D ( Collider2D _collision )
        {
            //var tag = _collision.gameObject.tag;
            //if( !String.Equals( tag, "Bullet" ) ) return;
            //var bulletController = _collision.GetComponent<BulletController>();
            //var dmg = TableService.Instance.GetDamagePoint( bulletController );
            //
            //var newHealthModifier = new HealthModifier( bulletController );
        }
    }
}