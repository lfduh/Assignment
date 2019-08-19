using UnityEngine;

namespace Assets.Scripts.Common.Utilities
{
    public class TraceCamera : MonoBehaviour
    {  
        [Header("Runtime Ref.")]
        [SerializeField] Transform target;

        [Header("Runtime Value.")]
        [SerializeField] float traceSpeed = 0.02f;

        void Update ()
        {
            if( !target ) return;
            var pos = new Vector3( target.transform.position.x, target.transform.position.y, transform.position.z );
                   
            transform.position = Vector3.Lerp( transform.position, pos, traceSpeed );
        }

        public void SetTarget ( Transform _tran )
        {
            target = _tran;
        }        
    }
}