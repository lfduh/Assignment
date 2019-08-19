using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Map
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class MapRecycler : MonoBehaviour
    {
        [Header("Runtime Ref.")]
        UnityAction<Vector3Int> recycledAction;    
        
        void OnTriggerEnter2D ( Collider2D _collision  )
        {
            var indexContainer = _collision.GetComponent<IndexContainer>();
            if( indexContainer ) recycledAction?.Invoke( indexContainer.gridIndex );
            Destroy( _collision.gameObject );            
        }

        public void SetRecycledAction ( UnityAction<Vector3Int> _action )
        {
            recycledAction = _action;
        }
    }
}
