using UnityEngine;
using Assets.Scripts.Common.Services;
using Assets.Scripts.Table;

namespace Assets.Scripts.Common.Utilities
{
    public class SingletonAwaker : MonoBehaviour
    {
        void Awake ()
        {           
            InputService.Instance.Initial();
            TableService.Instance.Initial();
        }
    }
}
