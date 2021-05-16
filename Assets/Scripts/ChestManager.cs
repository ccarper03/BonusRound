using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestManager :Singleton<ChestManager>
{

    [SerializeField] private Sprite close;
    [SerializeField] private Sprite openEmpty;
    [SerializeField] private Sprite openSm;
    [SerializeField] private Sprite openMd;
    [SerializeField] private Sprite openLg;
    [SerializeField] private Sprite openXtaLg;
    [SerializeField] private GameObject[] Chests;


    void Start()
    {
    }
    public void DisableChest()
    {
        GetComponent<Button>().interactable = false;
    }
    public void DisableAllChests()
    {
        foreach (var chest in Chests)
        {
            chest.GetComponent<Button>().interactable = false;
        }
    }
    public void EnableAllChests()
    {
        foreach (var chest in Chests)
        {
            chest.GetComponent<Button>().interactable = true;
        }
    }
    public void CloseAllChests()
    {
        foreach (var chest in Chests)
        {
            chest.GetComponent<Image>().sprite = close;
        }
    }
    public void CloseChest()
    {
        gameObject.GetComponent<Image>().sprite = close;
    }
    public void OpenSmChest( )
    {
        gameObject.GetComponent<Image>().sprite = openSm;
    }
    public void OpenMdChest()
    {
        gameObject.GetComponent<Image>().sprite = openMd;
    }
    public void OpenLgChest()
    {
        gameObject.GetComponent<Image>().sprite = openLg;
    }
    public void OpenXtaLgChest()
    {
        gameObject.GetComponent<Image>().sprite = openXtaLg;
    }

    public void DisplayWinning(int index)
    {
        decimal[] num = GameManager.Instance.GetWinningsArray();
        var winningAmount = num[GameManager.Instance.DivideWinningsCounter];
        Chests[index].GetComponent<Image>().sprite = openXtaLg;
        GameManager.Instance.ChestOneWinText.text = winningAmount.ToString("C");
        Chests[index].GetComponent<Button>().interactable = false;
    }
}
