using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class ObjectPooler : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }

        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> poolDictionary;

        public static ObjectPooler Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool p in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < p.size; i++)
                {
                    GameObject obj = Instantiate(p.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                poolDictionary.Add(p.tag, objectPool);
            }
        }

        public GameObject SpawnFromPool(string tag)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning($"Pool with tag {tag} does not exist.");
                return null;
            }
            GameObject obj = poolDictionary[tag].Dequeue();
            obj.SetActive(true);
            return obj;
        }

        public void ReturnToPool(string tag, GameObject obj)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning($"Pool with tag {tag} does not exist.");
                return;
            }

            poolDictionary[tag].Enqueue(obj);
            obj.SetActive(false);
        }
    }
}