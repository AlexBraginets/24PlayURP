using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StackAnimator : MonoBehaviour
{
    [SerializeField] private CubeStack _cubeStack;

    public void Animate()
    {
        int idx = 0;
        List<int> newPositionMap = GetNewPositionMap();
        foreach (var cube in _cubeStack.Stack)
        {
            cube.GetComponent<CubeAnimator>().Animate(newPositionMap[idx]);
            idx++;
        }
    }

    private List<int> GetNewPositionMap()
    {
        int drop = 0;
        List<int> positionMap = GetPositionMap();
        List<int> newPositionMap = new List<int>();
        for (int i = 0; i < positionMap.Count; i++)
        {
            newPositionMap.Add(i);
        }

        return newPositionMap;
    }

    private List<int> GetPositionMap()
    {
        var stack = _cubeStack.Stack;
        var positionMap = stack.Select(x => x.GetComponent<CubeAnimator>().position);
        return positionMap.ToList();
    }
}