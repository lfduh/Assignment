using UnityEngine;
using Assets.Scripts.Tank.Enumerations;

namespace Assets.Scripts.Tank
{
    [RequireComponent(typeof(TankAsset))]
    public class TankView : MonoBehaviour
    {
        [Header( "Runtime Ref." )]
        [SerializeField] TankAsset asset;

        void Awake ()
        {
            asset = GetComponent<TankAsset>();
        }

        void Start ()
        {            
            asset.gameObject.AddComponent<BoxCollider2D>();
            asset.gameObject.AddComponent<Rigidbody2D>();
        }

        public void SetColor( TankType _tankType )
        {
            Color color;
            ColorUtility.TryParseHtmlString( _tankType.ToString(), out color );
            SetColor( color );
        }

        public void SetColor ( Color _color )
        {
            asset.spriteRenderer.color = _color;
        }
    }
}
