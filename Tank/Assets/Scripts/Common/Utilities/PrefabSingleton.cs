/*---------------------------------------------------
ProjectBase Source Code
Copyright (c) 2016 Doo., Inc.
Last Updated --
$Rev$
$Author$
$Date$
$ID$
---------------------------------------------------*/

/*
 *	@auther by Doo 
 * 
 */

using UnityEngine;

namespace Assets.Scripts.Common.Utilities
{
	/// <summary>
	/// Be aware this will not prevent a non singleton constructor
	///   such as `T myT = new T();`
	/// To prevent that, add `protected T () {}` to your singleton class.
	/// 
	/// As a note, this is made as MonoBehaviour because we need Coroutines.
	/// </summary>
	public class PrefabSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;

		private static object _lock = new object();

		public static T Instance
		{
			get
			{
				if( applicationIsQuitting )
				{
#if UNITY_DEBUG
				if( DebugTool.currentDebugLevel >= DebugTool.DebugLevelEnumList.Debug )
				{
					Debug.LogWarning( DebugTool.GetTimestamp() + "[Singleton] Instance '"+ typeof(T) + 
								  "' already destroyed on application quit." + 
								  " Won't create again - returning null." );
				}
#endif

					return null;
				}

				lock( _lock )
				{
					if( _instance == null )
					{
						_instance = (T)FindObjectOfType( typeof( T ) );

						if( FindObjectsOfType( typeof( T ) ).Length > 1 )
						{
#if UNITY_DEBUG
						Debug.LogError( "[Singleton] Something went really wrong " +
										" - there should never be more than 1 singleton!" +
										" Reopening the scene might fix it.");
#endif
							return _instance;
						}

						if( _instance == null )
						{
							string singletonPrefabPath = "Singleton/";

#if UNITY_DEBUG
						if ( DebugTool.HasDebug )
						{
							Debug.Log( DebugTool.GetTimestamp() + "[PrefabSingleton]讀取 Resources/" + singletonPrefabPath + typeof(T).Name );
						}
#endif

							Object prefab = Resources.Load( singletonPrefabPath + typeof( T ).Name );

							if( prefab != null && (prefab as GameObject).GetComponent<T>() != null )
							{
#if UNITY_DEBUG
							if ( DebugTool.HasDebug )
							{
								Debug.Log( DebugTool.GetTimestamp() + "[PrefabSingleton]讀取成功, 使用Prefab作為Singleton.", _instance );
							}
#endif

								GameObject singleton = Instantiate( prefab ) as GameObject;
								_instance = singleton.GetComponent<T>();
							}
							else
							{
#if UNITY_DEBUG
							if ( DebugTool.HasDebug )
							{
								Debug.Log( DebugTool.GetTimestamp() + "[PrefabSingleton]讀取失敗, 新建物件作為Singleton.", _instance );
							}
#endif

								GameObject singleton = new GameObject();
								_instance = singleton.AddComponent<T>();
							}

							_instance.name = "[Singleton] " + typeof( T ).Name.ToString();

							DontDestroyOnLoad( _instance );

#if UNITY_DEBUG
						if ( DebugTool.HasDebug )
						{							
							Debug.Log( DebugTool.GetTimestamp() + 
									   "[Singleton] An instance of " + typeof(T) + 
								       " is needed in the scene, so '" + _instance +
									   "' was created with DontDestroyOnLoad.");
						}
#endif
						}
						else
						{
#if UNITY_DEBUG
						Debug.Log( DebugTool.GetTimestamp() + 
								   "[Singleton] Using instance already created: " + _instance.gameObject.name );
#endif
						}
					}

					return _instance;
				}
			}
		}

		private static bool applicationIsQuitting = false;
		/// <summary>
		/// When Unity quits, it destroys objects in a random order.
		/// In principle, a Singleton is only destroyed when application quits.
		/// If any script calls Instance after it have been destroyed, 
		///   it will create a buggy ghost object that will stay on the Editor scene
		///   even after stopping playing the Application. Really bad!
		/// So, this was made to be sure we're not creating that buggy ghost object.
		/// </summary>
		public void OnDestroy ()
		{
			applicationIsQuitting = true;
		}
	}
}
