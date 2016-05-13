using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UploadRoomControls : MonoBehaviour {
	
	public GameObject inputGameTitle;
	public GameObject inputGameDesc;
	public Dropdown dropDownGenre;
	public GameObject inputGameTech;

	public Genre selectedGenre;

	public GameObject errorLabel;

	public GameObject UploadGamePanelUI;
	public GameObject GeneralButtonsPanelUI;
	public GameObject UploadRoomPanelUI;
	public GameObject UploadInputFieldsUI;
	public GameObject UploadSuccessfulUI;
	void Start() 
	{
		dropDownGenre.onValueChanged.AddListener(delegate {
			dropDownGenreValueChangedHandler(dropDownGenre);
		});
		
		dropDownGenre.options.Clear();
		
		foreach (string name in Enum.GetNames(typeof(Genre))) 
		{
			dropDownGenre.options.Add (new Dropdown.OptionData() {text=name});
		}
		
		dropDownGenre.value = 1;
		dropDownGenre.value = 0;
	}
	
	void Destroy() {
		dropDownGenre.onValueChanged.RemoveAllListeners();
	}
	
	private void dropDownGenreValueChangedHandler(Dropdown target) {
		if (target.value == 0) 
		{
			selectedGenre = Genre.Action;
		}
		
		if (target.value == 1) 
		{
			selectedGenre = Genre.Casual;
			
		}
		if (target.value == 2) 
		{
			selectedGenre = Genre.Simulator;
		}
		
		if (target.value == 3) 
		{
			selectedGenre = Genre.Racer;
			
		}
	}

	public void SetDropdownGenreIndex(int index) {
		dropDownGenre.value = index;
	}

	public void UploadGame()
	{
		string xTitle = inputGameTitle.GetComponent<Text>().text;
		string xDesc = inputGameDesc.GetComponent<Text>().text;
		string xTech = inputGameTech.GetComponent<Text>().text;

		if (xTitle == "" || xDesc == "" || xTech == "") {
			errorLabel.GetComponent<Text> ().text = "Please fill in all the fields";
		} 
		else 
		{
			Accounts.LoggedInUser.Games.Add(new Game(xTitle,xDesc,xTech,selectedGenre));
			UploadInputFieldsUI.SetActive(false);
			UploadSuccessfulUI.SetActive(true);
		}
	}

	public void OpenUploadGamePanel()
	{
		UploadGamePanelUI.SetActive (true);
		GeneralButtonsPanelUI.SetActive (false);
		UploadRoomPanelUI.SetActive (false);

		UploadInputFieldsUI.SetActive(true);
		UploadSuccessfulUI.SetActive(false);
	}

	public void CloseUploadGamePanel()
	{
		UploadGamePanelUI.SetActive (false);
		GeneralButtonsPanelUI.SetActive (true);
		UploadRoomPanelUI.SetActive (true);
	}
}
