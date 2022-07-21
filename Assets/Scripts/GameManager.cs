using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[DefaultExecutionOrder(999)]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<Image> images;
    [SerializeField]
    private int amount;

    [SerializeField]
    private Image image;

    [SerializeField]
    private PlayerObject playerObject;

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

        playerObject.Player.OnHealed += (sender, args) => heartContainer.Replenish(args.Amount);
        playerObject.Player.OnDamaged += (sender, args) => heartContainer.Deplete(args.Amount);
    }
}
