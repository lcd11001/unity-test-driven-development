using UnityEngine;

public class Movement
{
    public Movement(float speed)
    {
        Speed = speed;
    }

    public float Speed { get; private set; }

    public Vector3 Caculate(float h, float v, float deltaTime)
    {
        var x = h * Speed * deltaTime;
        var z = v * Speed * deltaTime;

        return new Vector3(x, 0, z);
    }
}