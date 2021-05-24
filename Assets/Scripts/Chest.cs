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
    private GameObject bigWinPanel;
    public bool isCoinAnimDone = false;
    public GameObject coinPrefab;
    private decimal winningAmount;
    private IEnumerator coroutine;
    private bool isBigWinStillUpdating;
    public Button ChestButton => chestButton;
    public Chest ChestObject => chestObject;
    public Image ChestImage => chestImage;

    public void WinningText() 
    {
        winningText.text = string.Format("{0:0.00}", winningAmount);
    }

    private void Start()
    {
        isBigWinStillUpdating = false;
        isCoinAnimDone = false;
        chestButton.onClick.AddListener(OpenChest);
    }
    private void OnDestroy()
    {
        chestButton.onClick.RemoveListener(OpenChest);
    }
    private void Update()
    {
    }
    public void OpenChest()
    {
        StartCoroutine("OpenChestLogic");
    } 
    IEnumerator OpenChestLogic()
    {
        decimal winningAmt = .000m;
        List<decimal> winningsArray = GameManager.Instance.GetWinningsArray();
        ChestManager.Instance.cMax = winningsArray.Count;
        winningAmt = winningsArray[GameManager.Instance.DivideWinningsCounter];
        if (winningAmt > 200m)
        {
            gameObject.GetComponent<Animator>().speed = 0;
            chestButton.interactable = false;
            chestImage.sprite = openXtraLg;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Hooray);
            winningText.text = winningAmt.ToString("C");
            GameManager.Instance.DivideWinningsCounter++;
        }
        else if (winningAmt > 100m)
        {
            gameObject.GetComponent<Animator>().speed = 0;
            chestButton.interactable = false;
            chestImage.sprite = openLg;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Whoa);
            winningText.text = winningAmt.ToString("C");
            GameManager.Instance.DivideWinningsCounter++;
        }
        else if (winningAmt > 50m)
        {
            gameObject.GetComponent<Animator>().speed = 0;
            chestButton.interactable = false;
            chestImage.sprite = openMd;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Alright);
            winningText.text = winningAmt.ToString("C");
            GameManager.Instance.DivideWinningsCounter++;
        }
        else if (winningAmt > .05m)
        {
            gameObject.GetComponent<Animator>().speed = 0;
            chestButton.interactable = false;
            chestImage.sprite = openSm;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Nice);
            winningText.text = winningAmt.ToString("C");
            GameManager.Instance.DivideWinningsCounter++;
        }
        else if(winningAmt == .000m )
        {
            
            gameObject.GetComponent<Animator>().speed = 0;
            chestButton.interactable = false;
            ChestManager.Instance.DisableAllChests();
            GameManager.Instance.DisableBottomPanel();
            chestImage.sprite = pooper;
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Wrong);
            if (GameManager.Instance.winningTotal >= 1000m)
            {
                GameManager.Instance.BigWinPanel.SetActive(true);
                GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.CrabRave);

                StartCoroutine("LastWonAmountUpdater");
                StartCoroutine("BalUpdater");
                yield return new WaitUntil(()=> isBigWinStillUpdating == false);
                bigWinPanel = GameObject.Find("BigWin");
                bigWinPanel.SetActive(false);
                GameManager.Instance.AudioSource.Stop();
                Debug.Log("Playing original track?");
                GameManager.Instance.AudioSource.Play();
                GameManager.Instance.EnableBottomPanel();

            }
            else
            {
                StartCoroutine("CoinAnimation");
                StartCoroutine("LastWonAmountUpdater");
                StartCoroutine("BalUpdater");
            }
            
            yield return new WaitUntil(() => isCoinAnimDone == true);

            GameManager.Instance.EnableBottomPanel();
            Debug.Log("+++++++++++++++++++ End +++++++++++++++++++++++++");
        }
    }

    public IEnumerator CoinAnimation()
    {
        isCoinAnimDone = false;
        for (int i = 0; i < GameManager.Instance.winningTotal; i++)
        {
            GameObject newGo = Instantiate(coinPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            newGo.GetComponent<CoinManager>().Despawn(1f);
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Money);
            yield return new WaitForSeconds(0.03f);
        }
        isCoinAnimDone = true;
        
    }

    public IEnumerator BalUpdater()
    {
        decimal start = GameManager.Instance.currentBalance;
        decimal target = GameManager.Instance.currentBalance + GameManager.Instance.winningTotal;
        GameManager.Instance.currentBalance += GameManager.Instance.winningTotal;
        while (true)
        {
            if (start < target)
            {
                start++; 
                GameManager.Instance.banlanceText.text = start.ToString("C"); 
            }
            yield return new WaitForSeconds(0.03f);
        }
    }

    public IEnumerator LastWonAmountUpdater()
    {
        decimal start = 0;
        decimal target = GameManager.Instance.winningTotal;
        isBigWinStillUpdating = true;
        GameManager.Instance.DisableBottomPanel();
        for (int j = 0; j < GameManager.Instance.winningTotal; j++)
        {
            if (start < target)
            {
                start++;
                GameManager.Instance.LastGameWinText.text = start.ToString("C");
                GameManager.Instance.bigWinText.text = start.ToString("C");
            }
            yield return new WaitForSeconds(0.03f); // I used .2 secs but you can update it as fast as you want
        }
        isBigWinStillUpdating = false;
    }
}
