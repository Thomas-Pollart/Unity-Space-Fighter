using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public int Speed = 9;
    public float LimitY = 0;

    void Update()
    {
        var velocity = Vector3.down * Speed;
        transform.Translate(velocity * Time.deltaTime);

        if (transform.position.y < LimitY)
        {
            Destroy(this.gameObject);
        }
    }
}
