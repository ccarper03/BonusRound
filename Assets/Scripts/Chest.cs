using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [SerializeField] private Chest chestObject;
    [SerializeField] private Sprite close;
    [SerializeField] private Sprite pooper;
    [SerializeField] private Sprite openEmpty;
    [SerializeField] private Sprite openSm;
    [SerializeField] private Sprite openMd;
    [SerializeField] private Sprite openLg;
    [SerializeField] private Sprite openXtraLg;
    [SerializeField] public Text winningText;
    [SerializeField] private Image chestImage;
    [SerializeField] private Button chestButton;

    private decimal winningAmount;
    private bool doneDoingTask;
    private IEnumerator coroutine;
    public Button ChestButton => chestButton;
    public Chest ChestObject => chestObject;
    public Image ChestImage => chestImage;

    public void WinningText() 
    {
        winningText.text = string.Format("{0:0.00}", winningAmount);
    }

    private void Start()
    {
        doneDoingTask = true;
        chestButton.onClick.AddListener(OpenChest);
    }
    private void OnDestroy()
    {
        chestButton.onClick.RemoveListener(OpenChest);
    }
    private void Update()
    {
        if (!doneDoingTask)
        {
            return;
        }
    }
    public void OpenChest()
    {

        StartCoroutine("AnticipationMoment");
    } 
    IEnumerator AnticipationMoment()
    {
        decimal winningAmt = .000m;
        List<decimal> winningsArray = GameManager.Instance.GetWinningsArray();
        ChestManager.Instance.cMax = winningsArray.Count;
        winningAmt = winningsArray[GameManager.Instance.DivideWinningsCounter];

       
        if (winningAmt > 200m)
        {
            chestImage.sprite = openXtraLg;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Hooray);
            chestButton.interactable = false;
            winningText.text = winningAmt.ToString("C");
            if (ChestManager.Instance.cOpened >= ChestManager.Instance.cMax)
            {
                yield return new WaitForSecondsRealtime(2f);
                GameManager.Instance.LastGameWinText.text = GameManager.Instance.winningTotal.ToString("C");
                yield return new WaitForSecondsRealtime(2f);
                GameManager.Instance.banlanceText.text = GameManager.Instance.currentBalance.ToString("C");
                Debug.Log("+++++++++++++++++++ End +++++++++++++++++++++++++");
            }
            ChestManager.Instance.cOpened++;
            GameManager.Instance.DivideWinningsCounter++;
        }
        else if (winningAmt > 100m)
        {
            chestImage.sprite = openLg;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Whoa);
            chestButton.interactable = false;
            winningText.text = winningAmt.ToString("C");
            if (ChestManager.Instance.cOpened >= ChestManager.Instance.cMax)
            {
                yield return new WaitForSecondsRealtime(2f);
                GameManager.Instance.LastGameWinText.text = GameManager.Instance.winningTotal.ToString("C");
                yield return new WaitForSecondsRealtime(2f);
                GameManager.Instance.banlanceText.text = GameManager.Instance.currentBalance.ToString("C");
                Debug.Log("+++++++++++++++++++ End +++++++++++++++++++++++++");
            }
            ChestManager.Instance.cOpened++;
            GameManager.Instance.DivideWinningsCounter++;
        }
        else if (winningAmt > 50m)
        {
            chestImage.sprite = openMd;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Alright);
            chestButton.interactable = false;
            winningText.text = winningAmt.ToString("C");
            if (ChestManager.Instance.cOpened >= ChestManager.Instance.cMax)
            {
                yield return new WaitForSecondsRealtime(2f);
                GameManager.Instance.LastGameWinText.text = GameManager.Instance.winningTotal.ToString("C");
                yield return new WaitForSecondsRealtime(2f);
                GameManager.Instance.banlanceText.text = GameManager.Instance.currentBalance.ToString("C");
                Debug.Log("+++++++++++++++++++ End +++++++++++++++++++++++++");
            }
            ChestManager.Instance.cOpened++;
            GameManager.Instance.DivideWinningsCounter++;
        }
        else if (winningAmt > .05m)
        {
            chestImage.sprite = openSm;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Nice);
            chestButton.interactable = false;
            winningText.text = winningAmt.ToString("C");
            if (ChestManager.Instance.cOpened >= ChestManager.Instance.cMax)
            {
                yield return new WaitForSecondsRealtime(2f);
                GameManager.Instance.LastGameWinText.text = GameManager.Instance.winningTotal.ToString("C");
                yield return new WaitForSecondsRealtime(2f);
                GameManager.Instance.banlanceText.text = GameManager.Instance.currentBalance.ToString("C");
                Debug.Log("+++++++++++++++++++ End +++++++++++++++++++++++++");
            }
            ChestManager.Instance.cOpened++;
            GameManager.Instance.DivideWinningsCounter++;
        }
        else
        {
            chestImage.sprite = pooper;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Wrong);
            chestButton.interactable = false;
            GameManager.Instance.dividedChestWinningsList.Clear();
            ChestManager.Instance.DisableAllChests();
            GameManager.Instance.EnableBottomPanel();
            yield return new WaitForSecondsRealtime(2f);
            GameManager.Instance.LastGameWinText.text = GameManager.Instance.winningTotal.ToString("C");
            yield return new WaitForSecondsRealtime(2f);
            GameManager.Instance.banlanceText.text = GameManager.Instance.currentBalance.ToString("C");
            Debug.Log("+++++++++++++++++++ End +++++++++++++++++++++++++");
            ChestManager.Instance.cOpened = 0;
        }
    }
}
