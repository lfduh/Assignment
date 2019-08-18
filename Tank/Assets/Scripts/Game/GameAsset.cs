using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Game
{
    public class GameAsset : MonoBehaviour
    {
        [Header( "Editor Ref." )]
        public Button upButton;
        public EventTrigger upEventTrigger;

        public Button downButton;
        public EventTrigger downEventTrigger;

        public Button leftButton;
        public EventTrigger leftEventTrigger;

        public Button rightButton;
        public EventTrigger rightEventTrigger;

        [Space( 10 )]
        public Button fireButton;
        public Button changeButton;
    }
}
