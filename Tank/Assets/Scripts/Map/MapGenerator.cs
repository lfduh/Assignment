using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts.Common;
using Assets.Scripts.Hay;
using Assets.Scripts.Map.Enumerations;
using Assets.Scripts.Table;

namespace Assets.Scripts.Map
{
    public class MapGenerator : MonoBehaviour
    {
        [Header( "Runtime Ref." )]
        [SerializeField] GameObject hayPrefab;
        [SerializeField] GameObject wallPrefab;

        [SerializeField] MapGeneratorSettings settings;
        [SerializeField] MapRecycler recycler;

        [SerializeField] HashSet<Vector3Int> generatedGridIndex;
        [SerializeField] HashSet<Vector3Int> sightedGridIndex;
        
        [Header( "Runtime Value." )]
        [SerializeField] Vector3Int closestGridIndex;
        [SerializeField] int currentUpdateInterval;
                
        void Awake ()
        {
            generatedGridIndex = new HashSet<Vector3Int>();
            sightedGridIndex = new HashSet<Vector3Int>();
        }

        void Start ()
        {
            hayPrefab = (GameObject)Resources.Load( Constants.ResourcePath.Game.HAY );
            wallPrefab = (GameObject)Resources.Load( Constants.ResourcePath.Game.WALL );
            var recyclerPrefab = (GameObject)Resources.Load( Constants.ResourcePath.Game.RECYCLER );
            recycler = Instantiate( recyclerPrefab, Camera.main.transform ).GetComponent<MapRecycler>();
            recycler.SetRecycledAction( RecycleGrid );

            settings = TableService.Instance.GetMapGeneratorSettings();
            UpdateMap();
        }

        void Update ()
        {
            currentUpdateInterval++;
            if( currentUpdateInterval % settings.updateInterval != 0 ) return;
            currentUpdateInterval = 0;

            UpdateMap();
        }

        void UpdateMap ()
        {
            closestGridIndex = new Vector3Int( (int)(transform.position.x / settings.gridSize ), (int)(transform.position.y / settings.gridSize ), 0 );
            
            sightedGridIndex.Clear();
            for( int i = settings.reservedIndexRange.x * -1; i < settings.reservedIndexRange.x; i++ )
            {                
                for( int j = settings.reservedIndexRange.y * -1; j < settings.reservedIndexRange.y; j++ )
                {                    
                    sightedGridIndex.Add( new Vector3Int( closestGridIndex.x + i, closestGridIndex.y + j, 0 ) );
                }
            }            

            var newGrid = sightedGridIndex.Except( generatedGridIndex );
            foreach( var _newGrid in newGrid )
            {
                if( closestGridIndex == _newGrid )
                {
                    generatedGridIndex.Add( _newGrid );
                    continue;
                }

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
            if( type == GridType.Hay ) newObj = Instantiate( hayPrefab, (Vector3)_gridIndex * settings.gridSize, Quaternion.identity ).AddComponent<HayController>().gameObject;
            if( type == GridType.Wall ) newObj = Instantiate( wallPrefab, (Vector3)_gridIndex * settings.gridSize, Quaternion.identity );

            if( !newObj ) return;          
            newObj.AddComponent<BoxCollider2D>();
            var indexContain = newObj.AddComponent<IndexContainer>();
            indexContain.gridIndex = _gridIndex;
        }

        void RecycleGrid ( Vector3Int _toRemoveIndex )
        {
            var dir =  _toRemoveIndex - closestGridIndex;
            var axis = Mathf.Abs( dir.x ) >= Mathf.Abs( dir.y ) ? Vector2.right : Vector2.up;
            if( axis == Vector2.right ) generatedGridIndex.RemoveWhere( _index => _index.x == _toRemoveIndex.x );
            if( axis == Vector2.up ) generatedGridIndex.RemoveWhere( _index => _index.y == _toRemoveIndex.y );           
        }            
    }
}
