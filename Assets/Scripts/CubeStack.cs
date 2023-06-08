using System.Collections.Generic;
using DG.Tweening;
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
        AddAnimate(cube.transform);
    }

    private void AddAnimate(Transform cube)
    {
        float duration = .15f;
        float upAdj = .3f;
        var a = cube.localPosition;
        var b = a + Vector3.up * .1f;
        var sequence = DOTween.Sequence();
        sequence.Append(cube.DOLocalMove(b, duration * upAdj));
        sequence.Append(cube.DOLocalMove(a, duration * (1 - upAdj)));
        sequence.Play();
    }
}