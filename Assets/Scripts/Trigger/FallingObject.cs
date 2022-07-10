using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float Speed { get => speed; set { speed = value; } }

    [SerializeField]
    private float speed = 10;

    private void Update()
    {
        Fall(speed); ;
    }

    private void Fall(float speed)
    {
        var velocity = Vector3.down * speed;
        transform.Translate(velocity * Time.deltaTime);
    }
}
