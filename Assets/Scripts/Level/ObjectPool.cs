using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected void IncludeStartObjects(GameObject preFilledPool)
    {
        for (int i = 0; i < preFilledPool.transform.childCount; i++)
        {
            _pool.Add(preFilledPool.transform.GetChild(i).gameObject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }

    protected void DisablePassedPlatforms()
    {
        Vector3 point = _camera.WorldToViewportPoint(new Vector2(0, 0.5f));

        foreach (GameObject item in _pool)
        {
            if (item.activeSelf)
            {
                if (item.transform.position.x < point.x)
                    item.SetActive(false);
            }
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
