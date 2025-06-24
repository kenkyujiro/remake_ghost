﻿using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    //ハートコンテナを取得する
    private GameObject[] heartContainers;
    private Image[] heartFills;

    //ハートの親関係のものを取得
    public Transform heartsParent;
    //プレハブのハートコンテナの取得
    public GameObject heartContainerPrefab;

    private void Start()
    {

        // Should I use lists? Maybe :)
        heartContainers = new GameObject[(int)PlayerStats.Instance.MaxTotalHealth];
        heartFills = new Image[(int)PlayerStats.Instance.MaxTotalHealth];

        PlayerStats.Instance.onHealthChangedCallback += UpdateHeartsHUD;
        InstantiateHeartContainers();
        UpdateHeartsHUD();
    }

    //ハートの管理を行っている
    public void UpdateHeartsHUD()
    {
        SetHeartContainers();
        SetFilledHearts();
    }

    //ハート上限の管理
    void SetHeartContainers()
    {
        for (int i = 0; i < heartContainers.Length; i++)
        {
            if (i < PlayerStats.Instance.MaxHealth)
            {
                heartContainers[i].SetActive(true);
            }
            else
            {
                heartContainers[i].SetActive(false);
            }
        }
    }

    //ハートを並べる
    void SetFilledHearts()
    {
        for (int i = 0; i < heartFills.Length; i++)
        {
            if (i < PlayerStats.Instance.Health)
            {
                heartFills[i].fillAmount = 1;
            }
            else
            {
                heartFills[i].fillAmount = 0;
            }
        }

        if (PlayerStats.Instance.Health % 1 != 0)
        {
            int lastPos = Mathf.FloorToInt(PlayerStats.Instance.Health);
            heartFills[lastPos].fillAmount = PlayerStats.Instance.Health % 1;
            //Debug.Log($"Heart {lastPos} fillAmount adjusted to {PlayerStats.Instance.Health % 1}");
        }
    }

    //ハートの作成
    void InstantiateHeartContainers()
    {
        Debug.Log("InstantiateHeartContainers() called");

        for (int i = 0; i < PlayerStats.Instance.MaxTotalHealth; i++)
        {
            GameObject temp = Instantiate(heartContainerPrefab);
            temp.transform.SetParent(heartsParent, false);

            Transform heartFillTransform = temp.transform.Find("HeartFill");

            if (heartFillTransform == null)
            {
                //Debug.LogError($"HeartFill not found in prefab {i}!");
                return;
            }

            heartContainers[i] = temp;
            heartFills[i] = heartFillTransform.GetComponent<Image>();

            //Debug.Log($"Heart {i} instantiated successfully");
        }
    }
}
