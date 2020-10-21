using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
	public Button button;
	public Text buttonText;

	private GameManager gameManager;
	public AudioManager audioManager;

	public void SetGameManagerReference(GameManager manager) {
		gameManager = manager;
	}

	public void SetSpace() {
		buttonText.text = gameManager.GetPlayerSide();
		button.interactable = false;
		gameManager.EndTurn();

		if (buttonText.text == "X") {
			gameManager.PlayAudio(gameManager.audioManager.playerX);
		}
		if (buttonText.text == "O") {
			gameManager.PlayAudio(gameManager.audioManager.playerO);
		}
	}

}
