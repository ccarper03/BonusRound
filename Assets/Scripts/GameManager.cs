using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.Assertions;

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
    private float[] denoAmt = { .25f, .50f, 1.00f, 5.00f };
    private float denominator;
    private float winningTotal;
    private int multiplier;
    private float lastGameWin;
    private int[] winMultiplyerOnes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private int[] winMultiplyerTens = { 12, 16, 24, 32, 48, 64 };
    private int[] winMultiplyerHundreds = { 100, 200, 300, 400, 500 };
    public decimal[] dividedChestWinningsArr = new decimal[8];
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
        denoLbl.text = denoAmt[denoIndex].ToString("C");
        banlanceLbl.text = currentBalance.ToString("C");
        playBtn.interactable = true;
        DenoSubBtn.interactable = true;
        DenoAddBtn.interactable = true;
        divideWinningsCounter = 0;
        ChestManager.Instance.CloseAllChests();
        ChestManager.Instance.DisableAllChests();
    }
    private void Update()
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
    public void Play()
    {
        playBtn.interactable = false;
        DenoSubBtn.interactable = false;
        DenoAddBtn.interactable = false;
        LastGameWinLbl.text = "$0.00";
        divideWinningsCounter = 0;
        ChestManager.Instance.CloseAllChests();
        ChestManager.Instance.DisableAllChests();

        // Chests are pickable after pressing play
        // when picked
        // show open chest
        // display money in that chest (if any)
        // Add money to the running total (last game win)
        // Become no longer clickable
        // After Pooper is picked, add the total won to the current balance
        // on play press reset the Chest visuals


        if (denoAmt[denoIndex] <= currentBalance) // Check if you have enough in balance for Denomination amount
        {
            float randNum = Random.value;
            if (randNum <= .5f)// 50%
            {
                Debug.Log(randNum + " 50%");
                // Get input 
                denominator = denoAmt[denoIndex];

                // Calculate the values

                // Output the results
                Debug.Log(" Denominator: " + denominator + " Current Balance: " + currentBalance);
                LastGameWinLbl.text = "$0.00";
                banlanceLbl.text = (currentBalance -= denominator).ToString("C");
            }
            else if (randNum > .5f && randNum < .8f) // 30%
            {
                Debug.Log(randNum + " 30%");
                // Get input 
                multiplier = winMultiplyerOnes[Random.Range(0,10)];
                denominator = denoAmt[denoIndex];

                // Calculate the values
                banlanceLbl.text = (currentBalance -= denominator).ToString("C");
                winningTotal = multiplier * denominator;
                currentBalance += winningTotal;

                // Output the results
                Debug.Log("Mulitplyer: " + multiplier + " Denominator: " + denominator + " Winning Total: " + winningTotal + " Current Balance: " + currentBalance);
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
                Debug.Log("Mulitplyer: " + multiplier + " Denominator: " + denominator + " Winning Total: " + winningTotal + " Current Balance: " + currentBalance);
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
                Debug.Log("Mulitplyer: "+ multiplier + " Denominator: " + denominator + " Winning Total: " + winningTotal + " Current Balance: " + currentBalance);
                banlanceLbl.text = currentBalance.ToString("C");
                LastGameWinLbl.text = winningTotal.ToString("C");
            }
        }

        decimal howmuchmoneywon = (decimal)winningTotal;
        //int random = Random.Range(0, dividedChestWinningsArr.Length); // can only divide total winnings if we won 
        decimal numb = 0m;
        for (int i = 0; i < dividedChestWinningsArr.Length; i++)
        {
            numb = (Mathf.FloorToInt((float)(howmuchmoneywon * 20)) / Random.Range(4, 8)) * 0.05m;
            Debug.Log(numb);


            if (i == 7)
            {
                dividedChestWinningsArr[i] = howmuchmoneywon;
            }
            else
            {
                dividedChestWinningsArr[i] = numb;
                howmuchmoneywon -= numb;
            }
        }
        Debug.Log("$$$$$$$$$$$$$$$$$$$$");
        foreach (var winnings in dividedChestWinningsArr)
        {
            //Debug.Log("Winnings Divided: " + winnings.ToString("C"));
            Debug.Log(string.Format("{0:C2}", winnings));
        }
        Debug.Log("$$$$$$$$$$$$$$$$$$$$");


        ChestManager.Instance.EnableAllChests();
        playBtn.interactable = false;
        DenoSubBtn.interactable = false;
        DenoAddBtn.interactable = false;

        ChestManager.Instance.DisplayWinning(0);
        // Can click on chests
        // show open chest
        // display money in that chest
        // add money
        // no longer clickable

        // after pooper is found diable all the chests


        // close and disable all the chests
        playBtn.interactable = true;
        DenoSubBtn.interactable = true;
        DenoAddBtn.interactable = true;
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

    public decimal[] GetWinningsArray()
    {
        return dividedChestWinningsArr;
    }
}
