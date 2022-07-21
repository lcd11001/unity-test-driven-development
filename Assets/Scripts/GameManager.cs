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
    private Player player;

    void Awake()
    {
        player = new Player(20, 20);

        heart = new Heart(image);

        heartContainer = new HeartContainer(
            images
                .Select(image => new Heart(image))
                .ToList()
        );

        player.OnHealed += (sender, args) => heartContainer.Replenish(args.Amount);
        player.OnDamaged += (sender, args) => heartContainer.Deplete(args.Amount);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // heart.Replenish(amount);
            // heartContainer.Replenish(amount);
            player.Heal(amount);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // heart.Deplete(amount);
            // heartContainer.Deplete(amount);
            player.Damage(amount);
        }
    }
}
