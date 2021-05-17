using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [SerializeField] private Chest chestObject;
    [SerializeField] private Sprite close;
    [SerializeField] private Sprite openEmpty;
    [SerializeField] private Sprite openSm;
    [SerializeField] private Sprite openMd;
    [SerializeField] private Sprite openLg;
    [SerializeField] private Sprite openXtraLg;
    [SerializeField] public Text winningText;
    [SerializeField] private Image chestImage;
    [SerializeField] private Button chestButton;

    private decimal winningAmount;
    public Button ChestButton => chestButton;
    public Chest ChestObject => chestObject;
    public Image ChestImage => chestImage;

    public void WinningText() 
    {
        winningText.text = string.Format("{0:0.00}", winningAmount);
    }

    private void Start()
    {
        chestButton.onClick.AddListener(OpenChest);
    }
    private void OnDestroy()
    {
        chestButton.onClick.RemoveListener(OpenChest);
    }
    public void OpenChest()
    {
        
        List<decimal> winningsArray = GameManager.Instance.GetWinningsArray();
        decimal winningAmt = winningsArray[GameManager.Instance.DivideWinningsCounter];
        if (winningAmt == 0)
        {
            chestImage.sprite = openEmpty;
            chestButton.interactable = false;
            GameManager.Instance.dividedChestWinningsList.Clear();
            ChestManager.Instance.DisableAllChests();
            GameManager.Instance.EnableBottomPanel();
        }
        if (winningAmt < .25m || Input.GetKeyDown(KeyCode.Q))
        {
            chestImage.sprite = openEmpty;
            chestButton.interactable = false;
            ChestManager.Instance.chestsOpened++;
        }
        else if (winningAmt > 500m || Input.GetKeyDown(KeyCode.W))
        {
            chestImage.sprite = openXtraLg;
            chestButton.interactable = false;
            ChestManager.Instance.chestsOpened++;
        }
        else if (winningAmt > 60m || Input.GetKeyDown(KeyCode.E))
        {
            chestImage.sprite = openLg;
            chestButton.interactable = false;
            ChestManager.Instance.chestsOpened++;
        }
        else if (winningAmt > 5m || Input.GetKeyDown(KeyCode.R))
        {
            chestImage.sprite = openMd;
            chestButton.interactable = false;
            ChestManager.Instance.chestsOpened++;
        }
        else if (winningAmt > .24m || Input.GetKeyDown(KeyCode.T))
        {
            chestImage.sprite = openSm;
            chestButton.interactable = false;
            ChestManager.Instance.chestsOpened++;
        }
        winningText.text = winningAmt.ToString("C");
        GameManager.Instance.DivideWinningsCounter++;
    } 
}
