using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System.Linq;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public Text LastGameWinText;
    [SerializeField] public Text banlanceText;
    [SerializeField] private Text denoText;
    [SerializeField] private Button playBtn;
    [SerializeField] private Button DenoSubBtn;
    [SerializeField] private Button DenoAddBtn;
    public int DivideWinningsCounter { get; set; }
    public decimal currentBalance = 10.00m;
    private int denoIndex = 0;
    private decimal denominator;
    private int numOfChests;
    public decimal winningTotal;
    private decimal[] denoAmt = { .25m, .50m, 1.00m, 5.00m };
    private int multiplier;
    private int[] winMultiplyerOnes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private int[] winMultiplyerTens = { 12, 16, 24, 32, 48, 64 };
    private int[] winMultiplyerHundreds = { 100, 200, 300, 400, 500 };
    public List<decimal> dividedChestWinningsList = new List<decimal>();
    private AudioSource audioSource;
    private bool hasShowResults;

    public decimal animationTime = 1.5m;
    private decimal desiredWinTotNumber;
    private decimal initialWinTotNumber;
    private decimal currentWinTotNumber;
    private decimal desiredCurBalNumber;
    private decimal initialCurBalNumber;
    private decimal currentCurBalNumber;
    public AudioSource AudioSource
    {
        get { return audioSource; }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        denoIndex = 0;
        currentBalance = 10m;
        denoText.text = denoAmt[denoIndex].ToString("C");
        banlanceText.text = currentBalance.ToString("C");
        EnableBottomPanel();
        ChestManager.Instance.CloseAllChests();
        ChestManager.Instance.DisableAllChests();
    }
    void Update()
    {

        if (currentBalance < denoAmt[denoIndex])
        {
            ChestManager.Instance.CloseAllChests();
            ChestManager.Instance.DisableAllChests();
        } 
    }
        // InsufficientFunds();
    
    public void Play()
    {
        Instance.AudioSource.PlayOneShot(SoundManager.Instance.PlayClick);
        hasShowResults = false;
        Debug.Log("++++++++++++++++++ Start +++++++++++++++++++++++");
        numOfChests = 0;
        denominator = denoAmt[denoIndex];
        ChestManager.Instance.CloseAllChests();
        ChestManager.Instance.DisableAllChests();
        EnableBottomPanel();
        ResetLastWinGameText();
        ResetDivideWinningCounter();


        if (denoAmt[denoIndex] <= currentBalance) // Check if you have enough in balance for Denomination amount
        {
            Debug.Log("Before Bal: " + currentBalance);
            currentBalance -= denominator;
            Debug.Log("Denominator: " + denominator);
            Debug.Log("After Bal: " + currentBalance);
            banlanceText.text = currentBalance.ToString("C");
            
            float randNum = GetRandomValue();
            //randNum = .6f;
            Debug.Log("Random Num: " + randNum);
            if (randNum <= .5f) // 50%
            {
                winningTotal = 0;
                Debug.Log("---50%---");
                // Get input 
                multiplier = 0;
                

                // Calculate the values
                winningTotal = multiplier * denominator;
                Debug.Log("Winning Total " + winningTotal + "Multiplier " + multiplier + " X " +"Demonimator"+ denominator);
                currentBalance += winningTotal;

                decimal howmuchmoneywon = (decimal)winningTotal;
                decimal numb = 0m;
                numOfChests = Random.Range(1, 9);
                dividedChestWinningsList.Clear();
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
                dividedChestWinningsList.Add(.000m); // adding one more for a pooper
                foreach (var item in dividedChestWinningsList)
                {
                    Debug.Log(item + " Divided Amount");
                }
                // Output the results
                DisableBottomPanel();
                ChestManager.Instance.EnableAllChests();
            }
            else if (randNum > .5f && randNum < .8f) // 30% 
            {
                Debug.Log("---30%---");
                // Get input 
                multiplier = winMultiplyerOnes[Random.Range(0, 10)];

                // Calculate the values
                winningTotal = multiplier * denominator;
                Debug.Log("Winning Total " + winningTotal + "Multiplier " + multiplier + " X " + "Demonimator" + denominator);
                currentBalance += winningTotal;

                decimal howmuchmoneywon = (decimal)winningTotal;
                decimal numb = 0m;
                numOfChests = Random.Range(1, 9);
                dividedChestWinningsList.Clear();
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
                dividedChestWinningsList.Add(.000m); // adding one more for a pooper
                foreach (var item in dividedChestWinningsList)
                {
                    Debug.Log(item + " Divided Amount");
                }
                // Output the results
                DisableBottomPanel();
                ChestManager.Instance.EnableAllChests();
            }
            else if (randNum > .80f && randNum < .95f) // 15%
            {
                Debug.Log("---15%---");
                // Get input 
                multiplier = winMultiplyerTens[Random.Range(0, 6)];

                // Calculate the values
                winningTotal = multiplier * denominator;
                Debug.Log("Winning Total " + winningTotal + "Multiplier " + multiplier + " X " + "Demonimator" + denominator);
                currentBalance += winningTotal;

                decimal howmuchmoneywon = (decimal)winningTotal;
                decimal numb = 0m;
                numOfChests = Random.Range(1, 9);
                dividedChestWinningsList.Clear();
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
                dividedChestWinningsList.Add(.000m); // adding one more for a pooper
                foreach (var item in dividedChestWinningsList)
                {
                    Debug.Log(item + " Divided Amount");
                }
                // Output the results
                DisableBottomPanel();
                ChestManager.Instance.EnableAllChests();
            }
            else if (randNum > .95f) // 5%
            {
                Debug.Log("---5%---");
                // Get input 
                multiplier = winMultiplyerHundreds[Random.Range(0, 5)];

                // Calculate the values
                winningTotal = multiplier * denominator;
                Debug.Log("Winning Total " + winningTotal + "Multiplier " + multiplier + " X " + "Demonimator" + denominator);
                currentBalance += winningTotal;

                decimal howmuchmoneywon = (decimal)winningTotal;
                decimal numb = 0m;
                numOfChests = Random.Range(1, 9);
                dividedChestWinningsList.Clear();
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
                dividedChestWinningsList.Add(.000m); // adding one more for a pooper
                foreach (var item in dividedChestWinningsList)
                {
                    Debug.Log(item + " Divided Amount");
                }
                // Output the results
                DisableBottomPanel();
                ChestManager.Instance.EnableAllChests();
            }
        }
    }

    private void AddWinningTotalsToChests()
    {
        decimal howmuchmoneywon = (decimal)winningTotal;
        decimal numb = 0m;
        numOfChests = Random.Range(1, 9);
        dividedChestWinningsList.Clear();
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
    public void SetNumber(decimal value)
    {
        initialWinTotNumber = currentWinTotNumber;
        desiredWinTotNumber = value;
    }
    public void AddBalNumber(decimal value)
    {
        initialWinTotNumber = currentWinTotNumber;
        desiredWinTotNumber += value;
    }
    private static float GetRandomValue()
    {
        return Random.value;
    }

    private void ResetDivideWinningCounter()
    {
        DivideWinningsCounter = 0;
    }

    private void ResetLastWinGameText()
    {
        LastGameWinText.text = "$0.00";
    }

    // Add Denomination Button
    public void DenominatorIncrease()
    {
        if (denoIndex <= 2)
        {
            denoIndex++;
            denoText.text = denoAmt[denoIndex].ToString("C");
            Instance.AudioSource.PlayOneShot(SoundManager.Instance.IncreaseClick);
        }
    }

    // Subtract Denomination Button
    public void DenominatorDecrease()
    {
        if (denoIndex > 0)
        {
            denoIndex--;
            denoText.text = denoAmt[denoIndex].ToString("C");
            Instance.AudioSource.PlayOneShot(SoundManager.Instance.DecreaseClick);
        }
    }

    // Send the List
    public List<decimal> GetWinningsArray()
    {
        return dividedChestWinningsList;
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
