using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    GageBar HPGage;

    [SerializeField]
    Text Score;

    private bool isDead = false;

    [SerializeField]
    protected int MaxHP = 100;
    public int HPMax
    {
        get
        {
            return
            MaxHP;
        }
    }

    [SerializeField]
    protected int CurrentHP = 100;
    public int HPCurrent
    {
        get
        {
            return CurrentHP;
        }
    }

    int gamePoint = 0;
    public int GamePoint
    {
        get
        {
            return gamePoint;
        }
    }

    void init()
    {
        Reset();
        HPGage.SetHP(CurrentHP, MaxHP);
    }

    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void IncreaseHP(Player player, int value)
    {
        CurrentHP += value;
        if (CurrentHP > 100)
            CurrentHP = 100;

        HPGage.SetHP(CurrentHP, MaxHP);
    }
    private void DecreaseHP(Player player, int value)
    {
        if (isDead)
            return;

        CurrentHP -= value;
        if (CurrentHP < 0)
        {
            CurrentHP = 0;
            isDead = true;
        }

        HPGage.SetHP(CurrentHP, MaxHP);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Item_HP"))
        {
            if (CurrentHP == 100)
            {
                Accumulate(50);
                SetScore(gamePoint);
                Destroy(collider.gameObject);
            }
            IncreaseHP(player, 20);
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.CompareTag("Item_Score"))
        {
            Accumulate(100);
            SetScore(gamePoint);
            Destroy(collider.gameObject);
        }


    }

    public void SetScore(int value)
    {
        Score.text = value.ToString();
    }
    public void Accumulate(int value)
    {
        gamePoint += value;
    }
    public void Reset()
    {
        gamePoint = 0;
    }
}
