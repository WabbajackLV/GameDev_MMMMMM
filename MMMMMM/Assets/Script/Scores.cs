using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

	public static int scoreAmount;
	private Text scoreText;
	int totalCoins;
	public bool allCoins = false;

    // Use this for initialization
  
    void Start () {
        scoreText = GetComponent<Text>();
		scoreAmount = 0;
		totalCoins = GameObject.FindGameObjectsWithTag("Coins").Length + GameObject.FindGameObjectsWithTag("Coin_Hardmode").Length;
		totalCoins = GameObject.FindGameObjectsWithTag("Coins").Length;
	}
	
	void Update() {
		scoreAmount = totalCoins - GameObject.FindGameObjectsWithTag("Coins").Length - GameObject.FindGameObjectsWithTag("Coin_Hardmode").Length;
		scoreAmount = totalCoins - GameObject.FindGameObjectsWithTag("Coins").Length;
		scoreText.text ="Score: " + scoreAmount;
		if(scoreAmount >= totalCoins)
		{
			allCoins = true;
		}
	}
		
	public bool coinWin() {
		{
			return allCoins;
		}
	}
	
}