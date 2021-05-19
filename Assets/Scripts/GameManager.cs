using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System.Linq;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Text balanceText;
    [SerializeField] private Text lastGameWinText;
    [SerializeField] private Text denominationText;
    [SerializeField] private Button playBtn;
<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField] private Button denoMinusBtn;
    [SerializeField] private Button denoPlusBtn;
    
    public decimal currentBalance;
    
    private decimal[] denoAmt = { .25m, .50m, 1.00m, 5.00m };
    private decimal numb;
    private decimal howmuchmoneywon;
    private decimal winningTotal;
    private decimal denominator;
    private int[] winMultiplyerOnes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private int[] winMultiplyerTens = { 12, 16, 24, 32, 48, 64 };
    private int[] winMultiplyerHundreds = { 100, 200, 300, 400, 500 };
    private int denoIndex;
    private int numOfChests;
    private int multiplier;

    public List<decimal> dividedChestWinningsList = new List<decimal>();
    public int DivideWinningsCounter { get; set; }
    public AudioSource AudioSource { get; private set; }
    public bool IsBottomPanelOpen { get; set; }
    public bool IsTopPanelOpen { get; set; }

=======
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
    private int numOfChests;
    private float winningTotal;
    private float[] denoAmt = { .25f, .50f, 1.00f, 5.00f };
    private int multiplier;
    private int[] winMultiplyerOnes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private int[] winMultiplyerTens = { 12, 16, 24, 32, 48, 64 };
    private int[] winMultiplyerHundreds = { 100, 200, 300, 400, 500 };
    public List<decimal> dividedChestWinningsList = new List<decimal>();
=======
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
    private int numOfChests;
    private float winningTotal;
    private float[] denoAmt = { .25f, .50f, 1.00f, 5.00f };
    private int multiplier;
    private int[] winMultiplyerOnes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private int[] winMultiplyerTens = { 12, 16, 24, 32, 48, 64 };
    private int[] winMultiplyerHundreds = { 100, 200, 300, 400, 500 };
    public List<decimal> dividedChestWinningsList = new List<decimal>();
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
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
    private int numOfChests;
    private float winningTotal;
    private float[] denoAmt = { .25f, .50f, 1.00f, 5.00f };
    private int multiplier;
    private int[] winMultiplyerOnes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private int[] winMultiplyerTens = { 12, 16, 24, 32, 48, 64 };
    private int[] winMultiplyerHundreds = { 100, 200, 300, 400, 500 };
    public List<decimal> dividedChestWinningsList = new List<decimal>();
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
    private AudioSource audioSource;
    public AudioSource AudioSource
    {
        get { return audioSource; }
    }
<<<<<<< HEAD
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        denoIndex = 0;
<<<<<<< HEAD
<<<<<<< HEAD
        numb = 0;
        numOfChests = 0;
        DivideWinningsCounter = 0;
        howmuchmoneywon = 0;
        currentBalance = 10.00m;
        balanceText.text = "$10.00";
        denominationText.text = "$0.25";
        
=======
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
        divideWinningsCounter = 0;
        denoLbl.text = denoAmt[denoIndex].ToString("C");
        banlanceLbl.text = currentBalance.ToString("C");
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
        EnableBottomPanel();
        ChestManager.Instance.CloseAllChests();
        ChestManager.Instance.DisableAllChests();
    }
    void Update()
    {
        InsufficientFunds();
    }
    public void Play()
    {
        denominator = denoAmt[denoIndex];
        ChestManager.Instance.CloseAllChests();
        ChestManager.Instance.DisableAllChests();
        EnableBottomPanel();
        ResetLastWinGameText();
        ResetDivideWinningCounter();
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)

>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)

        if (denoAmt[denoIndex] <= currentBalance) // Check if you have enough in balance for Denomination amount
        {
            currentBalance -= denominator;
<<<<<<< HEAD
<<<<<<< HEAD
            Debug.Log("Denominator: " + denominator);
            Debug.Log("Balance After: " + currentBalance);
            balanceText.text = currentBalance.ToString("C");

            //float randNum = GetRandomValue();
            float randNum = .60f;
=======
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
            banlanceLbl.text = currentBalance.ToString("C");
            float randNum = GetRandomValue();
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
            if (randNum <= .5f)// 50%
            {
                winningTotal = 0;
                Debug.Log(randNum + " 50%");
                // Get input 

                // Calculate the values
                // Nothing to calculate

                // Output the results
                DisableBottomPanel();
                ChestManager.Instance.EnableAllChests();
<<<<<<< HEAD
<<<<<<< HEAD
                lastGameWinText.text = "$0.00";
                balanceText.text = currentBalance.ToString("C");
                
=======
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
                if (ChestManager.Instance.chestsOpened == 1 && winningTotal == 0)
                {
                    LastGameWinLbl.text = LastGameWinLbl.text = "$0.00";
                    banlanceLbl.text = currentBalance.ToString("C");
                }
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
            }
            else if (randNum > .5f && randNum < .8f) // 30% 
            {
                Debug.Log(randNum + " 30%");
                // Get input 
                multiplier = winMultiplyerOnes[Random.Range(0, 10)];

                // Calculate the values
                winningTotal = multiplier * denominator;
                howmuchmoneywon = winningTotal;
                numOfChests = Random.Range(1, 9);
                dividedChestWinningsList = new List<decimal>();
                for (int i = 0; i < numOfChests; i++)
                {
                    numb = (Mathf.FloorToInt((float)(howmuchmoneywon * 20)) / numOfChests) * 0.05m;
                    if (i == numOfChests - 1)
                    {
                        dividedChestWinningsList.Add(howmuchmoneywon);
                    }
                    else
                    {
                        dividedChestWinningsList.Add(numb);
                        howmuchmoneywon -= numb;
                    }
                }
                AddToBalance(winningTotal);
                DisableBottomPanel();
                ChestManager.Instance.EnableAllChests();

                // pick the chests

                // Output the results
<<<<<<< HEAD
<<<<<<< HEAD
                Debug.Log("Multiplyer: " + multiplier);
                Debug.Log("Denominator: " + denominator);
                Debug.Log("WinningTotal: " + winningTotal);
                foreach (var chestAmt in dividedChestWinningsList)
                {
                    Debug.Log("Chest List: " + chestAmt);
=======
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
                DisableBottomPanel();
                ChestManager.Instance.EnableAllChests();
                if (ChestManager.Instance.chestsOpened == numOfChests)
                {
                    LastGameWinLbl.text = winningTotal.ToString("C");
                    banlanceLbl.text = currentBalance.ToString("C");
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
                }
            }
            else if (randNum > .80f && randNum < .95f) // 15%
            {
                Debug.Log(randNum + " 15%");
                // Get input 
                multiplier = winMultiplyerTens[Random.Range(0, 6)];

                // Calculate the values
                winningTotal = multiplier * denominator;
                currentBalance += winningTotal;
                AddWinningTotalsToChests();

                // Output the results
<<<<<<< HEAD
<<<<<<< HEAD
                Debug.Log("Multiplyer: " + multiplier);
                Debug.Log("Denominator: " + denominator);
                Debug.Log("WinningTotal: " + winningTotal);
                foreach (var chestAmt in dividedChestWinningsList)
                {
                    Debug.Log("Chest List: " + chestAmt);
=======
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
                DisableBottomPanel();
                ChestManager.Instance.EnableAllChests();
                if (ChestManager.Instance.chestsOpened == numOfChests)
                {
                    LastGameWinLbl.text = winningTotal.ToString("C");
                    banlanceLbl.text = currentBalance.ToString("C");
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
                }
            }
            else if (randNum > .95f) // 5%
            {
                Debug.Log(randNum + " 5%");
                // Get input 
                multiplier = winMultiplyerHundreds[Random.Range(0, 5)];

                // Process Calculations
                winningTotal = multiplier * denominator;
                currentBalance += winningTotal;
                AddWinningTotalsToChests();

                // Output the results
<<<<<<< HEAD
<<<<<<< HEAD
                Debug.Log("Multiplyer: " + multiplier);
                Debug.Log("Denominator: " + denominator);
                Debug.Log("WinningTotal: " + winningTotal);
                foreach (var chestAmt in dividedChestWinningsList)
                {
                    Debug.Log("Chest List: " + chestAmt);
=======
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
                DisableBottomPanel();
                ChestManager.Instance.EnableAllChests();
                if (ChestManager.Instance.chestsOpened == numOfChests)
                {
                    LastGameWinLbl.text = winningTotal.ToString("C");
                    banlanceLbl.text = currentBalance.ToString("C");
<<<<<<< HEAD
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
                }
            }
        }
    }

    public void DisplayBalance()
    {
        balanceText.text = currentBalance.ToString("C");
    }
    public void DisplayLastWinText()
    {
        lastGameWinText.text = winningTotal.ToString("C");
    }
    public int GetDivWinningsCounter()
    {
        return DivideWinningsCounter;
    }
    void AddToBalance(decimal winningTotal)
    {

        currentBalance += winningTotal;
    }

    void AddWinningTotalsToChests()
    {
        decimal howmuchmoneywon = (decimal)winningTotal;
        decimal numb = 0m;
        numOfChests = Random.Range(1, 9);
        List<decimal> dividedChestWinningsList = new List<decimal>();
        for (int i = 0; i < numOfChests; i++)
        {
            numb = (Mathf.FloorToInt((float)(howmuchmoneywon * 20)) / numOfChests) * 0.05m;
            if (i == numOfChests - 1)
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

<<<<<<< HEAD
    void ResetLastWinGameText()
=======
    private static float GetRandomValue()
    {
        return Random.value;
    }

    private void ResetDivideWinningCounter()
    {
        divideWinningsCounter = 0;
    }

    private void ResetLastWinGameText()
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
    {
        lastGameWinText.text = "$0.00";
    }

    // Add Denomination Button
    public void DenominatorIncrease()
    {
        if (denoIndex <= 2)
        {
            denoIndex++;
            denominationText.text = denoAmt[denoIndex].ToString("C");
            Instance.AudioSource.PlayOneShot(SoundManager.Instance.IncreaseClick);
        }
    }

    // Subtract Denomination Button
    public void DenominatorDecrease()
    {
        if (denoIndex > 0)
        {
            denoIndex--;
            denominationText.text = denoAmt[denoIndex].ToString("C");
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
        IsBottomPanelOpen = true;
        playBtn.interactable = true;
        denoMinusBtn.interactable = true;
        denoPlusBtn.interactable = true;
    }

    // Funtion to Disable the Bottom Panels, Denominator & PlayButton
    public void DisableBottomPanel()
    {
        IsBottomPanelOpen = false;
        playBtn.interactable = false;
        denoMinusBtn.interactable = false;
        denoPlusBtn.interactable = false;
    }

    // Checks if Denominator Amount is less than
    // current balance, disables play button if true
    void InsufficientFunds()
    {
        if (denoAmt[denoIndex] < currentBalance)
        {
<<<<<<< HEAD
            //playBtn.interactable = false;
=======
            playBtn.interactable = true;
        }
        else
        {
            playBtn.interactable = false;
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
            playBtn.interactable = true;
        }
        else
        {
<<<<<<< HEAD
            playBtn.interactable = false;
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
            playBtn.interactable = true;
        }
        else
        {
            playBtn.interactable = false;
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
        }
    }
}
