using System.Collections.Generic;
using UnityEngine;

public class CubeStack : MonoBehaviour
{
    [SerializeField] private List<GameObject> _stack = new List<GameObject>();
    public List<GameObject> Stack => _stack;
    public int Count => _stack.Count;

    public void Add(GameObject cube)
    {
        _stack.Add(cube);
        cube.transform.parent = transform;
        cube.transform.localPosition = Vector3.up * (_stack.Count - .5f);
        cube.tag = "Stack cube";
        cube.GetComponent<CubeAnimator>().position = _stack.Count - 1;
    }
}