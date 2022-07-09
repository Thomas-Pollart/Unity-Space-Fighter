using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public bool enableVerticalAxis = false;
    public int speed = 7;

    public float MaxOutBoundLimitX = 9.5f;
    public float MaxOutBoundLimitY = 6f;

    public event Action GameOver;

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 input;

        if (enableVerticalAxis)
            input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        else
            input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

        var direction = input.normalized;
        var velocity = direction * speed;

        transform.Translate(Time.deltaTime * velocity, Space.World);
        
        // Clamp the player in the area.
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -MaxOutBoundLimitX, MaxOutBoundLimitX), 
            Mathf.Clamp(transform.position.y, -MaxOutBoundLimitY, MaxOutBoundLimitY), 
            transform.position.z
            );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameOver != null) GameOver();
        Destroy(this.gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (GameOver != null) GameOver();
    //    Destroy(this.gameObject);
    //}
}
