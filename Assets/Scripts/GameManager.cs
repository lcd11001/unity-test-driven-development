using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<Image> images;
    [SerializeField]
    private int amount;

    [SerializeField]
    private Image image;
    private Heart heart;
    private HeartContainer heartContainer;

    void Awake()
    {
        heart = new Heart(image);

        heartContainer = new HeartContainer(
            images
                .Select(image => new Heart(image))
                .ToList()
        );
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            heart.Replenish(amount);
            heartContainer.Replenish(amount);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            heart.Deplete(amount);
            heartContainer.Deplete(amount);
        }
    }
}
