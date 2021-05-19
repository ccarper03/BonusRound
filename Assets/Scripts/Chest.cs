using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public enum ChestType { Closed, OpenEmpty, OpenSm, OpenMd, OpenLg, OpenXtraLg }
    [SerializeField] private Chest chestObject;
    [SerializeField] private Sprite close;
    [SerializeField] private Sprite openEmpty;
    [SerializeField] private Sprite openSm;
    [SerializeField] private Sprite openMd;
    [SerializeField] private Sprite openLg;
    [SerializeField] private Sprite openXtraLg;
    [SerializeField] public Text ChestText;
    [SerializeField] private Image chestImage;
    [SerializeField] private Button chestButton;
    [SerializeField] private bool isChestPressed;

    private decimal winningAmount;
    // public ChestType ChestType;
    public Button ChestButton => chestButton;
    public Chest ChestObject => chestObject;
    public Image ChestImage => chestImage;
    public bool IsChestPressed => isChestPressed;

    void Start()
    {
        isChestPressed = false;
        GameManager.Instance.EnableBottomPanel();
        // chestButton.onClick.AddListener(ChestIsPressed);
    }
    private void OnDestroy()
    {
       // chestButton.onClick.RemoveListener(ChestIsPressed);
    }
    public void ChestIsPressed()
    {
        isChestPressed = true;
    }
    public void ChangeChestSprite(ChestType Type)
    {
<<<<<<< HEAD
        switch (Type)
        {
            case ChestType.Closed:
            {
                chestImage.sprite = close;
                break;
            }
            case ChestType.OpenEmpty: 
            {
                chestImage.sprite = openEmpty;
                chestButton.interactable = false;
                GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Pooper);
                break;
            }
            case ChestType.OpenSm:
            {
                chestImage.sprite = openSm;
                chestButton.interactable = false;
                GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Nice);
                break;
            }
            case ChestType.OpenMd:
            {
                chestImage.sprite = openMd;
                chestButton.interactable = false;
                GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Whoa);
                break;
            }
            case ChestType.OpenLg:
            {
                chestImage.sprite = openLg;
                chestButton.interactable = false;
                GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Alright);
                break;
            }
            case ChestType.OpenXtraLg:
            {
                chestImage.sprite = openXtraLg;
                chestButton.interactable = false;
                GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Hooray);
                break;
            }
        }
    }

    public void Reset()
    {
        isChestPressed = false;
        ChestText.text = "";
        ChangeChestSprite(ChestType.Closed);
    }
    public void ChangeChestText( decimal value)
    {
        ChestText.text = value.ToString("C");
    }
=======
        
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
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
}
