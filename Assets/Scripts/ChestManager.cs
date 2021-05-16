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
        GetComponent<Image>().sprite = close;
    }
    public void OpenSmChest( )
    {
        GetComponent<Image>().sprite = openSm;
    }
    public void OpenMdChest()
    {
        GetComponent<Image>().sprite = openMd;
    }
    public void OpenLgChest()
    {
        GetComponent<Image>().sprite = openLg;
    }
    public void OpenXtaLgChest()
    {
        GetComponent<Image>().sprite = openXtaLg;
    }

    public void DisplayWinning()
    {
        decimal[] num = GameManager.Instance.GetWinningsArray();
        var winningAmount = num[GameManager.Instance.DivideWinningsCounter];
        Debug.Log(GameManager.Instance.DivideWinningsCounter);
        Debug.Log("---" + winningAmount + "---");
        if (winningAmount > 500)
        {
            GetComponent<Image>().sprite = openXtaLg;
            Debug.Log("Xtra");
        }
        else if (winningAmount > 60)
        {
            GetComponent<Image>().sprite = openLg;
            Debug.Log("Lg");
        }
        else if (winningAmount > 5)
        {
            GetComponent<Image>().sprite = openMd;
            Debug.Log("Md");
        }
        else if (winningAmount > .24m)
        {
            GetComponent<Image>().sprite = openSm;
            Debug.Log("sm");
        }
        else if (winningAmount < .25m)
        {
            GetComponent<Image>().sprite = openEmpty;
            Debug.Log("Empty");
        }
        GameManager.Instance.DivideWinningsCounter++;
        Debug.Log(GameManager.Instance.DivideWinningsCounter);
        Instance.DisableChest(); 
    }
}
