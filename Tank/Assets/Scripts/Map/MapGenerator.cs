using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts.Common;
using Assets.Scripts.Hay;
using Assets.Scripts.Map.Enumerations;

namespace Assets.Scripts.Map
{
    public class MapGenerator : MonoBehaviour
    {
        [Header( "Runtime Ref." )]
        public GameObject hayPrefab;
        public GameObject wallPrefab;

        public HashSet<Vector3Int> generatedGridIndex;
        public HashSet<Vector3Int> sightedGridIndex;

        public List<int> indexX;
        public List<int> indexY;

        [Header( "Runtime Value." )]
        public float gridSize = 0.64f;
        public int gridIndexRangeX = 17;
        public int gridIndexRangeY = 10;

        public int updateInterval = -1;
                
        void Awake ()
        {
            generatedGridIndex = new HashSet<Vector3Int>();
            sightedGridIndex = new HashSet<Vector3Int>();

            indexX = new List<int>();
            indexY = new List<int>();
        }

        void Start ()
        {
            hayPrefab = (GameObject)Resources.Load( "Game/Hay" );
            wallPrefab = (GameObject)Resources.Load( "Game/Wall" );
        }

        void Update ()
        {
            updateInterval++;
            if( updateInterval % 5 != 0 ) return;

            var closestGridIndex = new Vector3Int( (int)(transform.position.x / 0.64f), (int)(transform.position.y / 0.64f), 0 );

            indexX.Clear();
            indexY.Clear();

            for( int i = gridIndexRangeX * -1; i < gridIndexRangeX; i++ )
            {
                indexX.Add( closestGridIndex.x + i );
            }

            for( int i = gridIndexRangeY * -1; i < gridIndexRangeY; i++ )
            {
                indexY.Add( closestGridIndex.y + i );
            }

            sightedGridIndex.Clear();
            foreach( var _x in indexX )
            {
                foreach( var _y in indexY )
                {
                    sightedGridIndex.Add( new Vector3Int( _x, _y, 0 ) );
                }
            }

            var newGrid = sightedGridIndex.Except( generatedGridIndex );

            foreach( var _newGrid in newGrid )
            {
                if( closestGridIndex == _newGrid ) continue;
                GenerateGrid( _newGrid );
            }
        }

        void GenerateGrid ( Vector3Int _gridIndex )
        {
            generatedGridIndex.Add( _gridIndex );

            var objChance = Random.Range( 0, 10 );
            if( objChance < 9 ) return;

            var type = (GridType)Random.Range( 1, 3 );

            GameObject newObj = null;
            if( type == GridType.Hay ) newObj = Instantiate( hayPrefab, (Vector3)_gridIndex * gridSize, Quaternion.identity ).AddComponent<HayController>().gameObject;
            if( type == GridType.Wall ) newObj = Instantiate( wallPrefab, (Vector3)_gridIndex * gridSize, Quaternion.identity );

            if( !newObj ) return;            
            newObj.AddComponent<BoxCollider2D>();
        }
    }
}
