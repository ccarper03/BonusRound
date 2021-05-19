using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChestManager :Singleton<ChestManager>
{
    [SerializeField] 
    private Sprite close;
    [SerializeField]
    private Chest[] ChestList;
<<<<<<< HEAD
    private int counter;
    public int ChestsOpenedCounter { get; set; }
    public List<decimal> winningsList;
    private void Start()
    {
        counter = 0;
        GameManager.Instance.EnableBottomPanel();
        winningsList = GameManager.Instance.GetWinningsArray().OrderByDescending(i => i).ToList();
    } 
    void Update()
    {
        foreach (var chest in ChestList)
        {
            if (chest.IsChestPressed)
            {
                decimal number = GetNextChestValue();
                
                if (number > 1250)
                {
                    chest.ChangeChestSprite(Chest.ChestType.OpenXtraLg);
                    chest.ChangeChestText(number);
                }
                else if(number > 625)
                {
                    chest.ChangeChestSprite(Chest.ChestType.OpenLg);
                    chest.ChangeChestText(number);
                }
                else if (number > 312)
                {
                    chest.ChangeChestSprite(Chest.ChestType.OpenMd);
                    chest.ChangeChestText(number);
                }
                else if (number > 156)
                {
                    chest.ChangeChestSprite(Chest.ChestType.OpenSm);
                    chest.ChangeChestText(number);
                }
                else if (number == 0)
                {
                    chest.ChangeChestSprite(Chest.ChestType.OpenEmpty);
                    chest.ChangeChestText(number);
                }
                

                if (number == 0)
                {
                    // Pooper Found
                    DisableAllChests(); 
                    GameManager.Instance.DisplayBalance();
                    GameManager.Instance.DisplayLastWinText();
                    CloseAllChests();
                    GameManager.Instance.EnableBottomPanel();
                }
            }
        }
    }
=======
    public int chestsOpened;
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
    public void DisableAllChests()
    {
        GameManager.Instance.IsTopPanelOpen = false;
        foreach (var chest in ChestList)
        {
            chest.ChestButton.interactable = false;
        }
    }
    public void EnableAllChests()
    {
        GameManager.Instance.IsTopPanelOpen = true;
        foreach (var chest in ChestList)
        {
            chest.ChestButton.interactable = true;
        }
    }
    public void CloseAllChests()
    {
        foreach (var chest in ChestList)
        {
            chest.ChangeChestSprite(Chest.ChestType.Closed);
            chest.ChestText.text = "";
        }
    }
    decimal GetNextChestValue()
    {
        List<decimal>decimalList = GameManager.Instance.GetWinningsArray();
        decimal individualChestWinning = decimalList[counter];
        counter++;
        return individualChestWinning;
    }
}
