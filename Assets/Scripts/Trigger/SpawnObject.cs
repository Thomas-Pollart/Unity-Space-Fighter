using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToInstantiate = null;
    [SerializeField]
    private float startDelay = 2f, spawnOffsetY = 10;
    [SerializeField]
    private Vector2 randomPositionX = new Vector2(-8.5f, 8.5f), randomScale = new Vector2(0.5f, 1.5f);
    [SerializeField]
    private Vector2 randomRotation = new Vector2(-12f, 12f), randomSpawnDelay = new Vector2(0.5f, 1f);
    [SerializeField]
    private float smallObjectSpeed = 20f, mediumObjectSpeed = 10f, largeObjectSpeed = 5f;

    private void Start()
    {
        Invoke("RandomSpawn", startDelay);
    }

    private void RandomSpawn()
    {
        var ranPosition = new Vector3(Random.Range(randomPositionX.x, randomPositionX.y), spawnOffsetY, 0);
        var ranScale = Random.Range(randomScale.x, randomScale.y);
        var ranRotation = Random.Range(randomRotation.x, randomRotation.y);
        var ranDelay = Random.Range(randomSpawnDelay.x, randomSpawnDelay.y);

        SpawnObjectAt(ranPosition, ranScale, ranRotation);

        Invoke("RandomSpawn", ranDelay);
    }

    private void SpawnObjectAt(Vector3 position, float scale, float rotation)
    {
        var instance = (GameObject)Instantiate(objectToInstantiate, position, Quaternion.Euler(new Vector3(0, 0, rotation)));
        instance.transform.localScale = Vector3.one * scale;
        instance.transform.parent = transform;

        RandomSpeed(instance);
    }

    private void RandomSpeed(GameObject instance)
    {
        if (instance.transform.localScale.x < randomScale.x)
        {
            instance.GetComponent<FallingObject>().Speed = smallObjectSpeed;
        }
        else if (instance.transform.localScale.x < 1)
        {
            instance.GetComponent<FallingObject>().Speed = mediumObjectSpeed;
        }
        else
        {
            instance.GetComponent<FallingObject>().Speed = largeObjectSpeed;
        }
    }
}
