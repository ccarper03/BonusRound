using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System.Linq;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public Text ChestOneWinText;
    [SerializeField] private Text LastGameWinLbl;
    [SerializeField] private Text banlanceLbl;
    [SerializeField] private Text denoLbl;
    [SerializeField] private Button playBtn;
    [SerializeField] private Button DenoSubBtn;
    [SerializeField] private Button DenoAddBtn;
    private int divideWinningsCounter;
    public int DivideWinningsCounter
    {
        get { return divideWinningsCounter; }
        set { divideWinningsCounter = value; }
    }
    private float currentBalance = 10.00f;
    private int denoIndex = 0;
    private float denominator;
    private float winningTotal;
    private float[] denoAmt = { .25f, .50f, 1.00f, 5.00f };
    private int multiplier;
    private int[] winMultiplyerOnes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private int[] winMultiplyerTens = { 12, 16, 24, 32, 48, 64 };
    private int[] winMultiplyerHundreds = { 100, 200, 300, 400, 500 };
    public List<decimal> dividedChestWinningsList = new List<decimal>();
    private AudioSource audioSource;
    public AudioSource AudioSource
    {
        get { return audioSource; }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        denoIndex = 0;
        divideWinningsCounter = 0;
        denoLbl.text = denoAmt[denoIndex].ToString("C");
        banlanceLbl.text = currentBalance.ToString("C");
        EnableBottomPanel();
        ChestManager.Instance.CloseAllChests();
        ChestManager.Instance.DisableAllChests();
    }
    private void Update()
    {
        InsufficientFunds();
    }
    public void Play()
    {
        ChestManager.Instance.CloseAllChests();
        ChestManager.Instance.DisableAllChests();
        EnableBottomPanel();
        ResetLastWinGameText();
        ResetDivideWinningCounter();
        if (denoAmt[denoIndex] <= currentBalance) // Check if you have enough in balance for Denomination amount
        {
            float randNum = GetRandomValue();
            if (randNum <= .5f)// 50%
            {
                // Get input 
                denominator = denoAmt[denoIndex];

                // Calculate the values
                DisableBottomPanel();
                ChestManager.Instance.CloseAllChests();
                ChestManager.Instance.EnableAllChests();
                
                // Output the results
                LastGameWinLbl.text = "$0.00";
                banlanceLbl.text = (currentBalance -= denominator).ToString("C");
            }
            else if (randNum > .5f && randNum < .8f) // 30%
            {
                Debug.Log(randNum + " 30%");
                // Get input 
                multiplier = winMultiplyerOnes[Random.Range(0, 10)];
                denominator = denoAmt[denoIndex];

                // Calculate the values
                banlanceLbl.text = (currentBalance -= denominator).ToString("C");
                winningTotal = multiplier * denominator;
                currentBalance += winningTotal;

                // Output the results
                banlanceLbl.text = currentBalance.ToString("C");
                LastGameWinLbl.text = winningTotal.ToString("C");

            }
            else if (randNum > .80f && randNum < .95f) // 15%
            {
                Debug.Log(randNum + " 15%");
                // Get input 
                multiplier = winMultiplyerTens[Random.Range(0, 6)];
                denominator = denoAmt[denoIndex];

                // Calculate the values
                banlanceLbl.text = (currentBalance -= denominator).ToString("C");
                winningTotal = multiplier * denominator;
                currentBalance += winningTotal;

                // Output the results
                banlanceLbl.text = currentBalance.ToString("C");
                LastGameWinLbl.text = winningTotal.ToString("C");
            }
            else if (randNum > .95f) // 5%
            {
                Debug.Log(randNum + " 5%");
                // Get input 
                multiplier = winMultiplyerHundreds[Random.Range(0, 5)];
                denominator = denoAmt[denoIndex];

                // Process Calculations
                banlanceLbl.text = (currentBalance -= denominator).ToString("C");
                winningTotal = multiplier * denominator;
                currentBalance += winningTotal;

                // Output the results
                banlanceLbl.text = currentBalance.ToString("C");
                LastGameWinLbl.text = winningTotal.ToString("C");
            }
        }

        decimal howmuchmoneywon = (decimal)winningTotal;
        decimal numb = 0m;
        int randAmountOfChests = Random.Range(1, 9);
        dividedChestWinningsList.Clear();
        for (int i = 0; i < randAmountOfChests; i++)
        {
            numb = (Mathf.FloorToInt((float)(howmuchmoneywon * 20)) / randAmountOfChests) * 0.05m;
            Debug.Log(numb);
            if (i == randAmountOfChests - 1)
            {
                dividedChestWinningsList.Add(howmuchmoneywon);
            }
            else
            {
                dividedChestWinningsList.Add(numb);
                howmuchmoneywon -= numb;
            }
        }
    }

    private static float GetRandomValue()
    {
        return Random.value;
    }

    private void ResetDivideWinningCounter()
    {
        divideWinningsCounter = 0;
    }

    private void ResetLastWinGameText()
    {
        LastGameWinLbl.text = "$0.00";
    }

    // Add Denomination Button
    public void DenominatorIncrease()
    {
        if (denoIndex <= 2)
        {
            denoIndex++;
            denoLbl.text = denoAmt[denoIndex].ToString("C");
            Instance.AudioSource.PlayOneShot(SoundManager.Instance.IncreaseClick);
        }
    }

    // Subtract Denomination Button
    public void DenominatorDecrease()
    {
        if (denoIndex > 0)
        {
            denoIndex--;
            denoLbl.text = denoAmt[denoIndex].ToString("C");
            Instance.AudioSource.PlayOneShot(SoundManager.Instance.DecreaseClick);
        }
    }

    // Send the List
    public List<decimal> GetWinningsArray()
    {
        while (dividedChestWinningsList.Count < 9)
        {
            AddZeroEndofList();
        }
        return dividedChestWinningsList;
    }
    
    // Add Zeros to the remaining positions of the list
    void  AddZeroEndofList()
    {
        dividedChestWinningsList.Add(0m);
    }
    
    // Function to Enable the bottom Panels, Denominator & PlayButton
    public void EnableBottomPanel()
    {
        playBtn.interactable = true;
        DenoSubBtn.interactable = true;
        DenoAddBtn.interactable = true;
    }

    // Funtion to Disable the Bottom Panels, Denominator & PlayButton
    public void DisableBottomPanel()
    {
        playBtn.interactable = false;
        DenoSubBtn.interactable = false;
        DenoAddBtn.interactable = false;
    }

    // Checks if Denominator Amount is less than
    // current balance, disables play button if true
    void InsufficientFunds()
    {
        if (denoAmt[denoIndex] <= currentBalance)
        {
            playBtn.interactable = true;
        }
        else
        {
            playBtn.interactable = false;
        }
    }
}
