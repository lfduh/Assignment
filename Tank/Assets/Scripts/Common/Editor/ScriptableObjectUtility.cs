using UnityEngine;
using UnityEditor;
using Assets.Scripts.Table;

namespace Assets.Scripts.Common.Editor
{
    public class ScriptableObjectUtility
    {
        public static void CreateAsset<T> () where T : ScriptableObject
        {
            var asset = ScriptableObject.CreateInstance<T>();
            ProjectWindowUtil.CreateAsset( asset, "New " + typeof( T ).Name + ".asset" );
        }

        [MenuItem( "Assets/Create/GameTable" )]
        public static void CreateGameTable ()
        {
            CreateAsset<GameTable>();
        }

        [MenuItem( "Assets/Create/MapGeneratoerSettings" )]
        public static void CreateMapGeneratorSettings ()
        {
            CreateAsset<MapGeneratorSettings>();
        }
    }
}
