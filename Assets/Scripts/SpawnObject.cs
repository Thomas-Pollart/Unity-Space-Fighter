using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToInstantiate;

    public float StartDelay = 2;

    public float YSpawn;

    public Vector2 RandomPositionLimitX;
    public Vector2 RandomScaleLimit;
    public Vector2 RandomRotationLimit;
    public Vector2 RandomDelay;

    void Start()
    {
        Invoke("SpawnObjectAt", StartDelay);
    }

    void SpawnObjectAt()
    {
        var randomPositionX = Random.Range(RandomPositionLimitX.x, RandomPositionLimitX.y);
        var randomScaleSize = Random.Range(RandomScaleLimit.x, RandomScaleLimit.y);
        var randomRotation = Random.Range(RandomRotationLimit.x, RandomRotationLimit.y);
        var randomDelayBetweenTwoObject = Random.Range(RandomDelay.x, RandomDelay.y);

        var instance = (GameObject)Instantiate(objectToInstantiate, new Vector3(randomPositionX, YSpawn, 0f), Quaternion.Euler(new Vector3(0, 0, randomRotation)));
        instance.transform.localScale = Vector3.one * randomScaleSize;
        instance.transform.parent = transform;

        if (instance.transform.localScale.x > 1f)
            instance.GetComponent<FallingObject>().Speed = Random.Range(35 , 50);
        else if (instance.transform.localScale.x > 0.7f)
            instance.GetComponent<FallingObject>().Speed = Random.Range(65, 75);
        else
            instance.GetComponent<FallingObject>().Speed = Random.Range(75, 90);

        Invoke("SpawnObjectAt", randomDelayBetweenTwoObject);
    }
}
