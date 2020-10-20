using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player {
	public Image panel;
	public Text text;
}

[System.Serializable]
public class PlayerColor {
	public Color panelColor;
	public Color textColor;
}

public class GameManager : MonoBehaviour
{
	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor inactivePlayerColor;

	public Text[] buttonArray;
	private string playerSide;

	public GameObject gameOverPanel;
	public Text gameOverText;

	public GameObject restartButton;

	private int moveCount;

	private void Awake() {
		gameOverPanel.SetActive(false); 
		playerSide = "X";
		moveCount = 0;
		restartButton.SetActive(false);
		SetGameManagerReferenceOnButtons();
		SetPlayerColors(playerX, playerO);
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
			GameOver(playerSide);
		}
		else if (
			buttonArray[3].text == playerSide &&
			buttonArray[4].text == playerSide &&
			buttonArray[5].text == playerSide) {
			GameOver(playerSide);
		}
		else if (
			buttonArray[6].text == playerSide &&
			buttonArray[7].text == playerSide &&
			buttonArray[8].text == playerSide) {
			GameOver(playerSide);
		}
		else if (
			buttonArray[0].text == playerSide &&
			buttonArray[3].text == playerSide &&
			buttonArray[6].text == playerSide) {
			GameOver(playerSide);
		}
		else if (
			buttonArray[1].text == playerSide &&
			buttonArray[4].text == playerSide &&
			buttonArray[7].text == playerSide) {
			GameOver(playerSide);
		}
		else if (
			buttonArray[2].text == playerSide &&
			buttonArray[5].text == playerSide &&
			buttonArray[8].text == playerSide) {
			GameOver(playerSide);
		}
		else if (
			buttonArray[0].text == playerSide &&
			buttonArray[4].text == playerSide &&
			buttonArray[8].text == playerSide) {
			GameOver(playerSide);
		}
		else if (
			buttonArray[2].text == playerSide &&
			buttonArray[4].text == playerSide &&
			buttonArray[6].text == playerSide) {
			GameOver(playerSide);
		}

		if (moveCount >= 9) {
			GameOver("draw");
		}

		ChangeSides();
	}

	void GameOver(string winningPlayer) {
		SetBoardInteractable(false);
		restartButton.SetActive(true);
		if (winningPlayer == "draw") {
			SetGameOverText("It's a draw!");
		}
		else {
			SetGameOverText(winningPlayer + " Wins!");
		}

	}

	void ChangeSides() {
		playerSide = (playerSide == "X") ? "O" : "X";
		if (playerSide == "X") {
			SetPlayerColors(playerX, playerO);
		}
		else {
			SetPlayerColors(playerO, playerX);
		}
	}

	void SetGameOverText(string value) {
		gameOverPanel.SetActive(true);
		gameOverText.text = value;
	}

	public void RestartGame() {
		playerSide = "X";
		moveCount = 0;
		gameOverPanel.SetActive(false);
		restartButton.SetActive(false);


		ResetButtonsText();
		SetBoardInteractable(true);
		SetPlayerColors(playerX, playerO);
	}

	void SetBoardInteractable (bool toggle) {
		for (int i = 0; i < buttonArray.Length; i++) {
			buttonArray[i].GetComponentInParent<Button>().interactable = toggle;
		}
	}

	void ResetButtonsText () {
		for (int i = 0; i < buttonArray.Length; i++) {
			buttonArray[i].text = "";
		}
	}

	void SetPlayerColors(Player newPlayer, Player oldPlayer) {
		newPlayer.panel.color = activePlayerColor.panelColor;
		newPlayer.text.color = activePlayerColor.textColor;
		oldPlayer.panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;
	}
}
