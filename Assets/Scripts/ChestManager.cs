using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestManager :Singleton<ChestManager>
{
    [SerializeField] private Sprite close;

    public List<Chest> ChestList = new List<Chest>();
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisableAllChests();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EnableAllChests();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CloseAllChests();
        }
    }
    public void DisableAllChests()
    {
        foreach (var chest in ChestList)
        {
            chest.GetComponent<Button>().interactable = false;
        }
    }
    public void EnableAllChests()
    {
        foreach (var chest in ChestList)
        {
            chest.GetComponent<Button>().interactable = true;
        }
    }

    public void CloseAllChests()
    {
        foreach (var chest in ChestList)
        {
            chest.GetComponent<Image>().sprite = close;
            chest.winningText.text = "";
        }
    }
}
