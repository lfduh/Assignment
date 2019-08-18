using UnityEngine;
using Assets.Scripts.Tank.Enumerations;

namespace Assets.Scripts.Bullet
{
    [RequireComponent(typeof(BulletAsset))]
    public class BulletView : MonoBehaviour
    {
        [Header( "Runtime Ref." )]
        [SerializeField] BulletAsset asset;

        void Awake ()
        {
            asset = GetComponent<BulletAsset>();    
        }

        public void SetColor ( TankType _tankType )
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
