using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private Image BloodScreen;



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
        if (isDead)
        {
            SceneManager.LoadScene("DeadScene");
        }
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
            else
            {
                IncreaseHP(player, 20);
                Destroy(collider.gameObject);
            }
        }

        if (collider.gameObject.CompareTag("Item_Score"))
        {
            Accumulate(100);
            SetScore(gamePoint);
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.CompareTag("Trap"))
        {
            StartCoroutine(ShowBloodScreen());
            DecreaseHP(player, 10);
            if (CurrentHP <= 0)
            {
                isDead = true;
            }
        }
    }

    IEnumerator ShowBloodScreen()
    {
        BloodScreen.color = new Color(1, 0, 0, UnityEngine.Random.Range(0.2f, 0.3f));
        yield return new WaitForSeconds(0.3f);
        BloodScreen.color = Color.clear;

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
