using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Movement movement;

    void Start()
    {
        movement = new Movement(speed);
    }

    void Update()
    {
        // Input & Time can not access from unit test
        // so that, we refactor the code

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        float deltaTime = Time.deltaTime;

        transform.position += movement.Caculate(h, v, deltaTime);
    }
}
