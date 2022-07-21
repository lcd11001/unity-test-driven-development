using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Movement movement;

    public IUnityService unityService;

    void Start()
    {
        movement = new Movement(speed);
        if (unityService == null)
        {
            unityService = new UnityService();
        }
    }

    void Update()
    {
        // Input & Time can not access from unit test
        // so that, we refactor the code

        var h = unityService.GetAxisInput("Horizontal");
        var v = unityService.GetAxisInput("Vertical");
        float deltaTime = unityService.GetDeltaTime();

        transform.position += movement.Caculate(h, v, deltaTime);
    }
}
