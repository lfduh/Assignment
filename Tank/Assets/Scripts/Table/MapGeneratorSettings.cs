using UnityEngine;

namespace Assets.Scripts.Table
{
    public class MapGeneratorSettings : ScriptableObject
    {
        public float gridSize;
        public Vector2Int reservedIndexRange;
        public int updateInterval;
    }
}
