using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestManager :Singleton<ChestManager>
{
    [SerializeField] 
    private Sprite close;
    [SerializeField]
    private Chest[] ChestList;
    public int chestsOpened;
    public int cOpened = 0;
    public int cMax = 9;
    public bool AreAllChestsClosed = false;
    public bool stillOpeningChests;
    public void DisableAllChests()
    {
        foreach (var chest in ChestList)
        {
            chest.ChestButton.interactable = false;
        }
    }

    public void EnableAllChests()
    {
        foreach (var chest in ChestList)
        {
            chest.ChestButton.interactable = true;
        }
    }

    public void CloseAllChests()
    {
        foreach (var chest in ChestList)
        {
            chest.ChestImage.sprite = close;
            chest.winningText.text = "";
        }
        AreAllChestsClosed = true;
    }

    public void PauseAllChestsAnimations()
    {
        foreach (var chest in ChestList)
        {
            chest.GetComponent<Animator>().speed = 0;
        }
    }
    public void PlayAllChestsAnimations()
    {
        foreach (var chest in ChestList)
        {
            chest.GetComponent<Animator>().speed = 1;
        }
    }
}
