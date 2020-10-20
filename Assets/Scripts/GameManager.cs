using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text[] buttonArray;
	private string playerSide;

	public GameObject gameOverPanel;
	public Text gameOverText;

	private int moveCount;

	private void Awake() {
		gameOverPanel.SetActive(false); 
		playerSide = "X";
		moveCount = 0;
		SetGameManagerReferenceOnButtons();
	}

	void SetGameManagerReferenceOnButtons() {

		for (int i = 0; i < buttonArray.Length; i++) {
			buttonArray[i].GetComponentInParent<GridSpace>().SetGameManagerReference(this);
		}
	}

	public string GetPlayerSide() {
		return playerSide;
	}

	public void EndTurn() {
		// Debug.Log("EndTurn is not implemented!");

		moveCount++;

		if (buttonArray[0].text == playerSide &&
			buttonArray[1].text == playerSide &&
			buttonArray[2].text == playerSide) {
			GameOver();
		}
		else if (
			buttonArray[3].text == playerSide &&
			buttonArray[4].text == playerSide &&
			buttonArray[5].text == playerSide) {
			GameOver();
		}
		else if (
			buttonArray[6].text == playerSide &&
			buttonArray[7].text == playerSide &&
			buttonArray[8].text == playerSide) {
			GameOver();
		}
		else if (
			buttonArray[0].text == playerSide &&
			buttonArray[3].text == playerSide &&
			buttonArray[6].text == playerSide) {
			GameOver();
		}
		else if (
			buttonArray[1].text == playerSide &&
			buttonArray[4].text == playerSide &&
			buttonArray[7].text == playerSide) {
			GameOver();
		}
		else if (
			buttonArray[2].text == playerSide &&
			buttonArray[5].text == playerSide &&
			buttonArray[8].text == playerSide) {
			GameOver();
		}
		else if (
			buttonArray[0].text == playerSide &&
			buttonArray[4].text == playerSide &&
			buttonArray[8].text == playerSide) {
			GameOver();
		}
		else if (
			buttonArray[2].text == playerSide &&
			buttonArray[4].text == playerSide &&
			buttonArray[6].text == playerSide) {
			GameOver();
		}

		if (moveCount >= 9) {
			SetGameOverText("It's a draw!");
		}

		ChangeSides();
	}

	void GameOver() {
		for (int i = 0; i < buttonArray.Length; i++) {
			buttonArray[i].GetComponentInParent<Button>().interactable = false;
		}

		SetGameOverText(playerSide + " Wins!");

	}

	void ChangeSides() {
		playerSide = (playerSide == "X") ? "O" : "X";
	}

	void SetGameOverText(string value) {
		gameOverPanel.SetActive(true);
		gameOverText.text = value;
	}
}
