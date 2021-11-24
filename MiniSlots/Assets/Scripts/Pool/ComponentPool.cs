using UnityEngine;

namespace JGM.Game.Pool
{
    public class ComponentPool<T> where T : Component
    {
        protected readonly T[] _pool;

        public ComponentPool(int poolSize, Transform poolParent)
        {
            _pool = new T[poolSize];
            for (int i = 0; i < poolSize; ++i)
            {
                var pooledGO = new GameObject($"Pooled {typeof(T)} {i + 1}");
                pooledGO.transform.SetParent(poolParent);
                pooledGO.SetActive(false);
                var pooledComponent = pooledGO.AddComponent<T>();
                _pool[i] = pooledComponent;
            }
        }

        public void Get(out T component)
        {
            component = null;
            for (int i = 0; i < _pool.Length; ++i)
            {
                if (!_pool[i].gameObject.activeSelf)
                {
                    component = _pool[i];
                    component.gameObject.SetActive(true);
                    return;
                }
            }
        }

        public void Destroy()
        {
            for (int i = 0; i < _pool.Length; ++i)
            {
                GameObject.Destroy(_pool[i].gameObject);
            }
        }
    }
}