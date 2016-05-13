using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GeneralControls : MonoBehaviour {
	
	public static int roomNum;
	public static int prevRoomNum;

	public GameObject returnButton; 

	public GameObject mapPanelUI;
	public GameObject profilePanelUI;
	public GameObject mailPanelUI;

	public GameObject generalControlsUI;

	public GameObject profilePage1;
	public GameObject profilePage2;

	public GameObject profileUserNameLabel;
	public GameObject profileRealNameLabel;
	public GameObject profileCollegeLabel;
	public GameObject profileYearLabel;
	public GameObject profileProgLangLabel;
	public GameObject profileIDELabel;

	public Transform profileGameObjPrefab;
	public GameObject profileGamesCountLabel;
	public Transform profileGamesListPanel;

	void Start()
	{
		if (roomNum == 1) 
		{
			returnButton.SetActive (false);
		} 
		else 
		{
			returnButton.SetActive (true);
		}
	}
	
	public void Button_Map_Open()
	{
		mapPanelUI.SetActive (true);
		generalControlsUI.SetActive (false);
	}

	public void Button_Map_Close()
	{
		mapPanelUI.SetActive (false);
		generalControlsUI.SetActive (true);
	}

	public void Button_Profile_Open()
	{
		profileUserNameLabel.GetComponent<Text> ().text = Accounts.LoggedInUser.Username;
		profileRealNameLabel.GetComponent<Text> ().text = "(" + Accounts.LoggedInUser.Realname + ")";
		profileCollegeLabel.GetComponent<Text> ().text = "College: " + Accounts.LoggedInUser.College;
		profileYearLabel.GetComponent<Text> ().text = "Year: " + Accounts.LoggedInUser.Year;
		profileProgLangLabel.GetComponent<Text> ().text = "Fav Prog Lang: " + Accounts.LoggedInUser.ProgLanguage;
		profileIDELabel.GetComponent<Text> ().text = "Fav IDE: " + Accounts.LoggedInUser.IDE;

		profilePanelUI.SetActive (true);
		generalControlsUI.SetActive (false);
	}

	public void DoNothing()
	{
	}
	
	public void Button_Profile_Close()
	{
		profilePanelUI.SetActive (false);
		generalControlsUI.SetActive (true);
	}

	public void Button_Profile_Next()
	{
		profilePage1.SetActive (false);
		profilePage2.SetActive (true);

		profileGamesCountLabel.GetComponent<Text> ().text = "Games: " + Accounts.LoggedInUser.Games.Count;

		foreach(Transform child in profileGamesListPanel)
		{
			child.gameObject.SetActive(false);
		}

		foreach (Game g in Accounts.LoggedInUser.Games) {
			Transform gameObjPanel = Instantiate (profileGameObjPrefab);
			gameObjPanel.parent = profileGamesListPanel; 
			
			foreach (Transform child in gameObjPanel.transform) {
				if (child.gameObject.tag == "GameDetails") {
					child.GetComponent<Text> ().text = g.Title + "\n" + g.GameGenre.ToString () + "\n" + g.Rating.ToString () + " star rating";
				} else if (child.gameObject.tag == "GameGoTo") {
					child.GetComponent<Button> ().onClick.AddListener (() => 
					{
						DoNothing ();});
				} else if (child.gameObject.tag == "GameForums") {
					child.GetComponent<Button> ().onClick.AddListener (() => 
					{
						DoNothing ();});
				}
			}
		}
	}
		
	public void Button_Profile_Prev()
	{
		profilePage1.SetActive (true);
		profilePage2.SetActive (false);
	}

	public void Button_Mail_Open()
	{
		mailPanelUI.SetActive (true);
		generalControlsUI.SetActive (false);
		MailControls mailControls = GetComponent < MailControls> ();
		mailControls.OpenInbox ();
	}

	public void Button_Mail_Close()
	{
		mailPanelUI.SetActive (false);
		generalControlsUI.SetActive (true);
	}

	public void Button_Return()
	{
		if (prevRoomNum >= 1)
		{
			int temp = prevRoomNum;
			prevRoomNum = roomNum;
			roomNum = temp;
			
			Application.LoadLevel(roomNum);
		}
	}

	public void Button_MainMenu()
	{
		prevRoomNum = -1;
		Application.LoadLevel(1);
	}
	
	public void Button_Games()
	{
		prevRoomNum = 1;
		Application.LoadLevel(2);
	}
	
	public void Button_Uploads()
	{
		prevRoomNum = 1;
		Application.LoadLevel(3);
	}
	
	public void Button_Chats()
	{
		prevRoomNum = 1;
		Application.LoadLevel(4);
	}

	public void Button_Logout()
	{
		Application.LoadLevel (0);
	}
}
