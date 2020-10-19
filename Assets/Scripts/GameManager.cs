using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text[] buttonArray;

	private void Awake() {
		SetGameManagerReferenceOnButtons();
	}

	void SetGameManagerReferenceOnButtons() {

		for (int i = 0; i < buttonArray.Length; i++) {
			buttonArray[i].GetComponentInParent<GridSpace>().SetGameManagerReference(this);
		}
	}

	public string GetPlayerSide() {
		return "?";
	}

	public void EndTurn() {
		Debug.Log("EndTurn is not implemented!");
	}

}
