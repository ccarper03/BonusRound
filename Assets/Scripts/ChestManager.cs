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
    public int ChestsOpenedCounter { get; set; }
    public List<decimal> winningsList = (List<decimal>)GameManager.Instance.GetWinningsArray().OrderByDescending(i => i);
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
            chest.ChestImage.sprite = close;
            chest.ChestText.text = "";
        }
    }

    public decimal GetNextChestValue()
    {
        decimal individualChestWinning = winningsList[GameManager.Instance.DivideWinningsCounter];       
        return individualChestWinning;
    }

    private void Update()
    {
        foreach (var chest in ChestList)
        {
            if (chest.IsChestPressed)
            {
                var number = GetNextChestValue();
                
                if (number > 1250)
                {
                    chest.ChangeChestSprite(Chest.ChestType.OpenXtraLg);
                }
                else if(number > 625)
                {
                    chest.ChangeChestSprite(Chest.ChestType.OpenLg);
                }
                else if (number > 312)
                {
                    chest.ChangeChestSprite(Chest.ChestType.OpenMd);
                }
                else if (number > 156)
                {
                    chest.ChangeChestSprite(Chest.ChestType.OpenSm);
                }
                else if (number == 0)
                {
                    chest.ChangeChestSprite(Chest.ChestType.OpenEmpty);
                }
                chest.ChangeChestText(number);

                if (number == 0)
                {
                    // Pooper Found
                    DisableAllChests();
                    DisplayTotalResults();

                    
                    GameManager.Instance.EnableBottomPanel();
                }
            }
        }
    }

    private void DisplayTotalResults()
    {
        decimal balanceTotal = 0m; 
        foreach (var item in winningsList)
        {
            balanceTotal += item
        }
       
    }







    // GameManager.Instance.dividedChestWinningsList.Clear();
}
