using System.Collections.Generic;
using UnityEngine;

public class CustomPool<T> where T : MonoBehaviour
{
    private List<T> prefabs;
    private List<T> objects;

    public List<T> getObjects => objects;

    public CustomPool(List<T> prefabs, Transform root)
    {
        this.prefabs = prefabs;
        objects = new List<T>();

        foreach (T _prefab in prefabs)
        {
            var _obj = GameObject.Instantiate(_prefab, root);
            _obj.gameObject.SetActive(false);
            objects.Add(_obj);
        }
    }

    public T Get()
    {
        List<T> _objects = objects.FindAll(x => !x.isActiveAndEnabled);

        T _obj = null;
        if (_objects.Count > 0) _obj = _objects[Random.Range(0, _objects.Count)];

        if (_obj == null) return null;

        _obj.gameObject.SetActive(true);
        return _obj;
    }

    public void Release(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    public void ReleaseAll()
    {
        foreach (T _obj in objects) _obj.gameObject.SetActive(false);
    }
}
