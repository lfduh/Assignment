using UnityEngine;
using Assets.Scripts.Common.Modifiers;
using Assets.Scripts.Table;

namespace Assets.Scripts.Hay
{
    public class HayController : MonoBehaviour, IDamageReceiver
    {
        [Header( "Runtime Value." )]
        [SerializeField] short healthPoint;

        void Start ()
        {
            healthPoint = TableService.Instance.GetHayHealthPoint();
        }
        
        public void TakeDamage ( short _point )
        {
            healthPoint -= _point;
            if( healthPoint > 0 ) return;
            Destroy( gameObject );            
        }     
    }
}