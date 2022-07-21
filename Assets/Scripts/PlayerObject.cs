using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    [SerializeField]
    private int initHealth;
    [SerializeField]
    private int maximumHealth;

    [SerializeField]
    private int amount;

    private Player player;

    public Player Player { get => player; }

    void Awake()
    {
        player = new Player(initHealth, maximumHealth);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            // heart.Replenish(amount);
            // heartContainer.Replenish(amount);
            player.Heal(amount);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            // heart.Deplete(amount);
            // heartContainer.Deplete(amount);
            player.Damage(amount);
        }
    }
}
