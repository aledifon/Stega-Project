using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textCoin;
    int numCoins;
    
    //Public Method which is going to be called from the player script when this one gets a coin. (onTrigger)
    public void AddCoin()
    {
        numCoins++;//Adds 1
        //Show it by the UI
        textCoin.text = "" + numCoins.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
