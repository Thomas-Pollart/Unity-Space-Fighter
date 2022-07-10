using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpaceshipSpeed { get => playerSpaceshipSpeed; }
    public event Action GameOverEvent;

    [SerializeField]
    private bool activeVerticalMovement = false;
    [SerializeField]
    private float playerSpaceshipSpeed = 10f;
    [SerializeField]
    private float boundaryAreaX = 9.5f, boundaryAreaY = 6f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 input;

        if (activeVerticalMovement)
            input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        else
            input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

        var direction = input.normalized;
        var velocity = direction * playerSpaceshipSpeed;

        transform.Translate(Time.deltaTime * velocity, Space.World);

        LimitThePlayerArea(boundaryAreaX, boundaryAreaY);
    }

    private void LimitThePlayerArea(float xpos, float ypos)
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -xpos, xpos),
            Mathf.Clamp(transform.position.y, -ypos, ypos),
            transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameOverEvent != null)
        {
            GameOverEvent();
        }

        Destroy(this.gameObject);
    }
}
