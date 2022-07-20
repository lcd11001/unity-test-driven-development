using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Image image;
    private Heart heart;

    void Awake()
    {
        heart = new Heart(image);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            heart.Replenish(1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            heart.Deplete(1);
        }
    }
}
