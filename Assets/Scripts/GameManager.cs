using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player {
	public Image panel;
	public Text text;
	public Button button;
}

[System.Serializable]
public class PlayerColor {
	public Color panelColor;
	public Color textColor;
}

public class GameManager : MonoBehaviour
{
	public Text[] buttonArray;
	public GameObject gameOverPanel;
	public Text gameOverText;
	public GameObject restartButton;
	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor inactivePlayerColor;

	private string playerSide;
	private int moveCount;

	void Awake() {
		SetGameManagerReferenceOnButtons();
		gameOverPanel.SetActive(false); 
		moveCount = 0;
		restartButton.SetActive(false);
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
		else if (moveCount >= 9) {
			GameOver("draw");
		}
		else {
			ChangeSides();
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

	void SetPlayerColors(Player newPlayer, Player oldPlayer) {
		newPlayer.panel.color = activePlayerColor.panelColor;
		newPlayer.text.color = activePlayerColor.textColor;
		oldPlayer.panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;
	}

	void GameOver(string winningPlayer) {
		SetBoardInteractable(false);
		if (winningPlayer == "draw") {
			SetGameOverText("It's a Draw!");
			SetPlayerColorsInactive();
		}
		else {
			SetGameOverText(winningPlayer + " Wins!");
		}
		restartButton.SetActive(true);
	}

	void SetGameOverText(string value) {
		gameOverPanel.SetActive(true);
		gameOverText.text = value;
	}

	public void RestartGame() {
		moveCount = 0;
		gameOverPanel.SetActive(false);
		restartButton.SetActive(false);
		SetPlayerButtons(true);
		SetPlayerColorsInactive();
		ResetButtonsText();
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

	public void SetStartindSide(string startingSide) {
		playerSide = startingSide;
		if (playerSide == "X") {
			SetPlayerColors(playerX, playerO);
		}
		else {
			SetPlayerColors(playerO, playerX);
		}

		StartGame();
	}

	public void StartGame() {
		SetBoardInteractable(true);
		SetPlayerButtons(false);

	}

	void SetPlayerButtons(bool toggle) {
		playerX.button.interactable = toggle;
		playerO.button.interactable = toggle;
	}

	void SetPlayerColorsInactive() {
		playerX.panel.color = inactivePlayerColor.panelColor;
		playerX.text.color = inactivePlayerColor.textColor;
		playerO.panel.color = inactivePlayerColor.panelColor;
		playerO.text.color = inactivePlayerColor.textColor;
	}

}
