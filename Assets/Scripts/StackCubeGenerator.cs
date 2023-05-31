using UnityEngine;

public class StackCubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject stackCubePrefab;
    [SerializeField] private float generationPeriod;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 instantiateOffset;
    private float _lastGeneratedTime;

    private void Update()
    {
        if ((_lastGeneratedTime + generationPeriod) > Time.time) return;
        GenerateStackCube();
    }

    private void GenerateStackCube()
    {
        _lastGeneratedTime = Time.time;
        var stackCube = Instantiate(stackCubePrefab);
        var playerPosition = player.position;
        var position = playerPosition + instantiateOffset;
        position.x = Random.RandomRange(-2f,2f);
        stackCube.transform.position = position;
    }
}
