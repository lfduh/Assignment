using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common.Utilities;
using UnityEngine.Events;

namespace Assets.Scripts.Common.Services
{
    public class InputService : PrefabSingleton<InputService>
    {
        [Header("Runtime Ref.")]
        public UnityEventWrapper<bool> upPressed;
        public UnityEventWrapper<bool> downPressed;
        public UnityEventWrapper<bool> leftPressed;
        public UnityEventWrapper<bool> rightPressed;
                
        public UnityEvent spacePressed;
        public UnityEvent zPressed;

        void Awake ()
        {
            upPressed = new UnityEventWrapper<bool>();
            downPressed = new UnityEventWrapper<bool>();
            leftPressed = new UnityEventWrapper<bool>();
            rightPressed = new UnityEventWrapper<bool>();

            spacePressed = new UnityEvent();
            zPressed = new UnityEvent();
        }

        public InputService Initial ()
        {
            return this;
        }
               
        void Update ()
        {
            if( Input.GetKeyDown( KeyCode.UpArrow ) )   upPressed?.Invoke( true );            
            if( Input.GetKeyUp  ( KeyCode.UpArrow ) )   upPressed?.Invoke( false );
            if( Input.GetKeyDown( KeyCode.DownArrow ) ) downPressed?.Invoke( true );
            if( Input.GetKeyUp  ( KeyCode.DownArrow ) ) downPressed?.Invoke( false );
            if( Input.GetKeyDown( KeyCode.LeftArrow ) ) leftPressed?.Invoke( true ); 
            if( Input.GetKeyUp  ( KeyCode.LeftArrow ) ) leftPressed?.Invoke( false ); 
            if( Input.GetKeyDown( KeyCode.RightArrow ) ) rightPressed?.Invoke( true );
            if( Input.GetKeyUp  ( KeyCode.RightArrow ) ) rightPressed?.Invoke( false ); 
            if( Input.GetKeyUp  ( KeyCode.Space ) ) spacePressed?.Invoke();
            if( Input.GetKeyUp  ( KeyCode.Z ) ) zPressed?.Invoke();
        }
    }
}
