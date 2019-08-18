using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Menu
{    
    public class MenuView : MonoBehaviour
    {
        [Header("Runtime Ref.")]
        [SerializeField] MenuAsset asset;

        void Awake ()
        {
            asset = FindObjectOfType<MenuAsset>();
        }
               
        public void SetStartGameButtonAction ( UnityAction _startButtonAction )
        {
            asset.startButton.onClick.RemoveAllListeners();
            if( _startButtonAction == null ) return;
            asset.startButton.onClick.AddListener( _startButtonAction );
        }
    }
}
