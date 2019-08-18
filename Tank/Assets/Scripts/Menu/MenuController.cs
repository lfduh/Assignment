using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Common.Enumerations;

namespace Assets.Scripts.Menu
{
    [RequireComponent(typeof(MenuView))]
    public class MenuController : MonoBehaviour
    {
        [Header("Runtime Ref.")]
        [SerializeField] MenuView view;
        
        void Awake ()
        {
            view = GetComponent<MenuView>();
        }

        void Start ()
        {
            view.SetStartGameButtonAction( StartGame );
        }

        void StartGame ()
        {
            SceneManager.LoadScene( SceneName.Game.ToString() );
        }
    }
}