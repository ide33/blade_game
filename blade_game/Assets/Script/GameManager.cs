using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject hpGauge;
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }

       void Update()
    {
        // HPゲージがなくなったらゲームオーバー画面に移行
        if (hpGauge.GetComponent<Image>().fillAmount <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void DecreaseHP()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.4f;
    }
}
