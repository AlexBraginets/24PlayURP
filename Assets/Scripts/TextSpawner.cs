using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 moveOffset;
    public static TextSpawner Instance { get; private set; }

    private void Awake() => Instance = this;

    [SerializeField] private TMP_Text labelPrefab;
    [SerializeField] private Transform target;
    [SerializeField] private float destroyDuration;

    public void Spawn(string text)
    {
        var label = Instantiate(labelPrefab, transform);
        label.text = text;
        label.transform.position = target.position;
        label.transform.DOLocalMove(label.transform.localPosition + moveOffset, destroyDuration);
        Destroy(label.gameObject, destroyDuration);
    }
}