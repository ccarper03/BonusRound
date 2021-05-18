using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private void Start()
    {
        isChestPressed = false;
        chestButton.onClick.AddListener(ChestIsPressed);
    }
    private void OnDestroy()
    {
        chestButton.onClick.RemoveListener(ChestIsPressed);
    }
    public void ChestIsPressed()
    {
        isChestPressed = true;
        GameManager.Instance.DivideWinningsCounter++;
    }
    public void ChangeChestSprite(ChestType Type)
    {
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

       
        //if (winningAmount != 0 && individualChestWinning < .25m || Input.GetKeyDown(KeyCode.Q))
        //{
        //    chestImage.sprite = openEmpty;
        //    chestButton.interactable = false;
        //    ChestManager.Instance.ChestsOpened++;
        //    GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Pooper);
        //}
        //else if (individualChestWinning > 500m || Input.GetKeyDown(KeyCode.W))
        //{
        //    chestImage.sprite = openXtraLg;
        //    chestButton.interactable = false;
        //    ChestManager.Instance.ChestsOpened++;
        //    GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Hooray);
        //}
 
        //ChestText.text = individualChestWinning.ToString("C");
        //GameManager.Instance.DivideWinningsCounter++;
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
}
