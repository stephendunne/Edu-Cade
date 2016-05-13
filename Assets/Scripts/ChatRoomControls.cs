using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatRoomControls : MonoBehaviour 
{
	public GameObject userNameInput;
	public GameObject errorLabel;

	public GameObject chatroomButtonsPanelUI;
	public GameObject searchUserPanelUI;
	public GameObject searchProfilePanelUI;
	public GameObject generalControlsPanelUI;

	public GameObject searchProfilePage1;
	public GameObject searchProfilePage2;

	public GameObject profileUserNameLabel;
	public GameObject profileRealNameLabel;
	public GameObject profileCollegeLabel;
	public GameObject profileYearLabel;
	public GameObject profileProgLangLabel;
	public GameObject profileIDELabel;
	public GameObject profileGamesCountLabel;
	public Transform profileGamesListPanel;
	public Transform profileGameObjPrefab;

	public User searchedUser;

	public void OpenSearchUser()
	{
		searchUserPanelUI.SetActive (true);
		generalControlsPanelUI.SetActive (false);
		chatroomButtonsPanelUI.SetActive (false);
		searchProfilePanelUI.SetActive (false);

		errorLabel.GetComponent<Text>().text ="Hi, My Name Is..";
	}

	public void CloseSearchUser()
	{
		searchUserPanelUI.SetActive (false);
		generalControlsPanelUI.SetActive (true);
		chatroomButtonsPanelUI.SetActive (true);
		searchProfilePanelUI.SetActive (false);

	}

	public void SearchUserButton()
	{
		string xSearchString = userNameInput.GetComponent<Text> ().text;

		bool UserFound = false;

		if (xSearchString != "") 
		{
			foreach (User u in Accounts.Users)
			{
				if (u.Username == xSearchString)
				{
					searchedUser = u;
					Profile_Open();
					Button_Profile_Next();
					Button_Profile_Prev();
					UserFound = true;
				}
			}
		}
		if (!UserFound) 
		{
			errorLabel.GetComponent<Text>().text ="User Not Found";
		}
	}

	public void Profile_Open()
	{
		searchProfilePanelUI.SetActive (true);
		searchUserPanelUI.SetActive (false);
		generalControlsPanelUI.SetActive (false);
		chatroomButtonsPanelUI.SetActive (false);

		profileUserNameLabel.GetComponent<Text> ().text = searchedUser.Username;
		profileRealNameLabel.GetComponent<Text> ().text = "(" + searchedUser.Realname + ")";
		profileCollegeLabel.GetComponent<Text> ().text = "College: " + searchedUser.College;
		profileYearLabel.GetComponent<Text> ().text = "Year: " + searchedUser.Year;
		profileProgLangLabel.GetComponent<Text> ().text = "Fav Prog Lang: " + searchedUser.ProgLanguage;
		profileIDELabel.GetComponent<Text> ().text = "Fav IDE: " + searchedUser.IDE;
		
		searchProfilePanelUI.SetActive (true);
		generalControlsPanelUI.SetActive (false);
	}
	
	public void Button_Profile_Close()
	{
		searchProfilePanelUI.SetActive (false);
		searchUserPanelUI.SetActive (false);
		generalControlsPanelUI.SetActive (true);
		chatroomButtonsPanelUI.SetActive (true);
	}
	
	public void Button_Profile_Next()
	{
		searchProfilePage1.SetActive (false);
		searchProfilePage2.SetActive (true);
		
		profileGamesCountLabel.GetComponent<Text> ().text = "Games: " + searchedUser.Games.Count;
		
		foreach(Transform child in profileGamesListPanel)
		{
			child.gameObject.SetActive(false);
		}
		
		foreach (Game g in searchedUser.Games) {
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

	public void DoNothing()
	{
	}

	public void Button_Profile_Prev()
	{
		searchProfilePage1.SetActive (true);
		searchProfilePage2.SetActive (false);
	}
}
