using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [SerializeField]
    private Chest chestObject;
    [SerializeField]
    private Sprite close;
    [SerializeField]
    private Sprite openEmpty;
    [SerializeField]
    private Sprite openSm;
    [SerializeField]
    private Sprite openMd;
    [SerializeField]
    private Sprite openLg;
    [SerializeField]
    private Sprite openXtraLg;
    [SerializeField]
    public Text winningText;
    [SerializeField]
    private Button chestButton;

    public decimal winningAmount;

    public Chest ChestObject
    {
        get
        {
            return chestObject;
        }
    }

    public decimal WinningAmount
    {
        get { return winningAmount; }
        set { winningAmount = value; }
    }

    public void WinningText() 
    {
        GetComponent<Text>().text = String.Format("{0:0.00}", winningAmount);
    }   

    public void OpenChest()
    {
        List<decimal> winningsArray = GameManager.Instance.GetWinningsArray();
        decimal winningAmt = winningsArray[GameManager.Instance.DivideWinningsCounter];
        Debug.Log("Counter: " + GameManager.Instance.DivideWinningsCounter);
        Debug.Log("Winning Amount: " + winningAmt);
        if (winningAmt == 0)
        {
            gameObject.GetComponent<Image>().sprite = openEmpty;
            gameObject.GetComponent<Button>().interactable = false;
            GameManager.Instance.dividedChestWinningsList.Clear();
            ChestManager.Instance.DisableAllChests();
            GameManager.Instance.EnableBottomPanel();
        }
        if (winningAmt < .25m || Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.GetComponent<Image>().sprite = openEmpty;
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (winningAmt > 500m || Input.GetKeyDown(KeyCode.W))
        {
            gameObject.GetComponent<Image>().sprite = openXtraLg;
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (winningAmt > 60m || Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Image>().sprite = openLg;
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (winningAmt > 5m || Input.GetKeyDown(KeyCode.R))
        {
            gameObject.GetComponent<Image>().sprite = openMd;
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (winningAmt > .24m || Input.GetKeyDown(KeyCode.T))
        {
            gameObject.GetComponent<Image>().sprite = openSm;
            gameObject.GetComponent<Button>().interactable = false;
        }
        winningText.text = winningAmt.ToString("C");
        GameManager.Instance.DivideWinningsCounter++;
    } 
}
