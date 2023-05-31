using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HitMapInitializer : MonoBehaviour
{
    private void Awake()
    {
        Initialize();
    }

    [ContextMenu("Initialize")]
    private void Initialize()
    {
        List<GameObject> children = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i).gameObject);
        }

        Dictionary<int, List<int>> hitMap = new Dictionary<int, List<int>>();
        foreach (var child in children)
        {
            GetInfo(child.transform, out int index, out int position);
            if (hitMap.ContainsKey(index))
            {
                hitMap[index].Add(position);
            }
            else
            {
                hitMap[index] = new List<int>();
                hitMap[index].Add(position);
            }
        }

        foreach (var keys in hitMap.Keys)
        {
            hitMap[keys].Sort();
        }

        GetComponent<ObstacleHitMap>().hitMap = GetHitMap(hitMap);
    }

    private ObstacleHitMap.HitMap GetHitMap(Dictionary<int, List<int>> hitMap)
    {
        List<ObstacleHitMap.HitMap.HitIndices> hitIndices = new List<ObstacleHitMap.HitMap.HitIndices>();
        var keys = hitMap.Keys.OrderBy(x => x);
        for (int i = 0; i < 5; i++)
        {
            hitIndices.Add(new ObstacleHitMap.HitMap.HitIndices()
            {
                hitIndices = new List<int>()
            });
        }

        foreach (var key in keys)
        {
            hitIndices[key].hitIndices = hitMap[key];
        }

        return new ObstacleHitMap.HitMap()
        {
            hitIndices = hitIndices
        };
    }

    private void GetInfo(Transform transform, out int index, out int position)
    {
        float x = transform.localPosition.x;
        float y = transform.localPosition.y;
        index = Mathf.FloorToInt(x + 2.1f);
        position = Mathf.FloorToInt(y + .1f);
        index = 4 - index;
        Debug.Log($"info: index: {index}; position: {position}");
    }
}