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
        decimal winningAmt = .000m;
        List<decimal> winningsArray = GameManager.Instance.GetWinningsArray();
        ChestManager.Instance.cMax = winningsArray.Count;
        winningAmt = winningsArray[GameManager.Instance.DivideWinningsCounter];
        if (winningAmt > 2000m)
        {
            chestImage.sprite = openXtraLg;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Hooray);
            chestButton.interactable = false;
            ChestManager.Instance.cOpened++;
            winningText.text = winningAmt.ToString("C");
            GameManager.Instance.DivideWinningsCounter++;
        }
        else if (winningAmt > 1500m)
        {
            chestImage.sprite = openLg;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Whoa);
            chestButton.interactable = false;
            ChestManager.Instance.cOpened++;
            winningText.text = winningAmt.ToString("C");
            GameManager.Instance.DivideWinningsCounter++;
        }
        else if (winningAmt > 1000m)
        {
            chestImage.sprite = openMd;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Alright);
            chestButton.interactable = false;
            ChestManager.Instance.cOpened++;
            winningText.text = winningAmt.ToString("C");
            GameManager.Instance.DivideWinningsCounter++;
        }
        else if (winningAmt > .05m)
        {
            chestImage.sprite = openSm;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Nice);
            chestButton.interactable = false;
            ChestManager.Instance.cOpened++;
            winningText.text = winningAmt.ToString("C");
            GameManager.Instance.DivideWinningsCounter++;
        }
        else
        {
            chestImage.sprite = openEmpty;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Wrong);
            chestButton.interactable = false;
            GameManager.Instance.dividedChestWinningsList.Clear();
            ChestManager.Instance.DisableAllChests();
            GameManager.Instance.EnableBottomPanel();
            ChestManager.Instance.cOpened = ChestManager.Instance.cMax;
            winningText.text = winningAmt.ToString("C");
        }
        //add up an display total winnings?
    } 
}




//if (winningAmt == .000m)//pooper
//{
//    chestImage.sprite = openEmpty;
//    chestButton.interactable = false;
//    GameManager.Instance.dividedChestWinningsList.Clear();
//    ChestManager.Instance.DisableAllChests();
//    GameManager.Instance.EnableBottomPanel();
//    ChestManager.Instance.cOpened++;
//    winningText.text = winningAmt.ToString("C");
//    GameManager.Instance.DivideWinningsCounter++;
//    break;
//}
//if (winningAmt < .25m || Input.GetKeyDown(KeyCode.Q))
//{
//    chestImage.sprite = openEmpty;
//    chestButton.interactable = false;
//    ChestManager.Instance.cOpened++;
//    winningText.text = winningAmt.ToString("C");
//    GameManager.Instance.DivideWinningsCounter++;
//}
//else if (winningAmt > 500m || Input.GetKeyDown(KeyCode.W))
//{
//    chestImage.sprite = openXtraLg;
//    chestButton.interactable = false;
//    ChestManager.Instance.cOpened++;
//    winningText.text = winningAmt.ToString("C");
//    GameManager.Instance.DivideWinningsCounter++;
//}
//else if (winningAmt > 60m || Input.GetKeyDown(KeyCode.E))
//{
//    chestImage.sprite = openLg;
//    chestButton.interactable = false;
//    ChestManager.Instance.cOpened++;
//    winningText.text = winningAmt.ToString("C");
//    GameManager.Instance.DivideWinningsCounter++;
//}
//else if (winningAmt > 5m || Input.GetKeyDown(KeyCode.R))
//{
//    chestImage.sprite = openMd;
//    chestButton.interactable = false;
//    ChestManager.Instance.cOpened++;
//    winningText.text = winningAmt.ToString("C");
//    GameManager.Instance.DivideWinningsCounter++;
//}
//else if (winningAmt > .24m || Input.GetKeyDown(KeyCode.T))
//{
//    chestImage.sprite = openSm;
//    chestButton.interactable = false;
//    ChestManager.Instance.cOpened++;
//    winningText.text = winningAmt.ToString("C");
//    GameManager.Instance.DivideWinningsCounter++;
//}