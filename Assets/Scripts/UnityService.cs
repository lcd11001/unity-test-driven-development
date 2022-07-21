using UnityEngine;

public class UnityService : IUnityService
{
    public float GetAxisInput(string axisName)
    {
        return Input.GetAxis(axisName);
    }

    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
}