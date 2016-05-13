using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameRoomControls : MonoBehaviour {

	public Dropdown dropDownGenre;
	public Dropdown dropDownRating;
	public GameObject gameListPanelUI;
	public Transform gameCatelogObjPrefab;

	public GameObject CatelogPanelUI;
	public GameObject GeneralButtonsPanelUI;
	public GameObject GamesRoomPanelUI;
	public GameObject ArcadeGamePanelUI;

	public GameObject ArcadeGameTitle;


	void Start() 
	{
		dropDownGenre.value = 0;
		dropDownRating.value = 0;

		dropDownGenre.onValueChanged.AddListener(delegate {
			dropDownGenreValueChangedHandler(dropDownGenre);
		});

		dropDownRating.onValueChanged.AddListener(delegate {
			dropDownRatingValueChangedHandler(dropDownRating);
		});

		dropDownGenre.options.Clear();

		foreach (string name in Enum.GetNames(typeof(Genre))) 
		{
			dropDownGenre.options.Add (new Dropdown.OptionData() {text=name});
		}

		dropDownGenre.value = 1;
		dropDownGenre.value = 0;

		dropDownRating.value = 1;
		dropDownRating.value = 0;

	}

	void Destroy() {
		dropDownGenre.onValueChanged.RemoveAllListeners();
	}
	
	private void dropDownGenreValueChangedHandler(Dropdown target) {
		if (target.value == 0) 
		{
			AddGamesToList(Genre.Action);
		}
		
		if (target.value == 1) 
		{
			AddGamesToList(Genre.Casual);
			
		}
		if (target.value == 2) 
		{
			AddGamesToList(Genre.Simulator);
		}
		
		if (target.value == 3) 
		{
			AddGamesToList(Genre.Racer);
			
		}
	}

	private void dropDownRatingValueChangedHandler(Dropdown target) {
		if (target.value == 0) 
		{
			AddGamesToList(5);
		}

		if (target.value == 1) 
		{
			AddGamesToList(4);
		}

		if (target.value == 2) 
		{
			AddGamesToList(3);
		}

		if (target.value == 3) 
		{
			AddGamesToList(2);
		}

		if (target.value == 4) 
		{
			AddGamesToList(1);
		}
	}

	public void AddGamesToList(Genre genre)
	{
		foreach(Transform child in gameListPanelUI.transform)
		{
			child.gameObject.SetActive(false);
		}


		foreach (User u in Accounts.Users) 
		{
			foreach (Game g in u.Games) 
			{
				if(g.GameGenre == genre)
				{
				Transform gameObj = Instantiate (gameCatelogObjPrefab);
				gameObj.parent = gameListPanelUI.transform; 
				gameObj.GetComponentInChildren<Text> ().text = "Title: " + g.Title + "\nGenre: " + g.GameGenre + "\nRating: " + g.Rating;
				gameObj.GetComponentInChildren<Button> ().onClick.AddListener (() => 
				{
						OpenArcadeGamePanelFromCatelog (g);});
				}
			}
		}
	}

	public void AddGamesToList(int rating)
	{
		foreach(Transform child in gameListPanelUI.transform)
		{
			child.gameObject.SetActive(false);
		}
		
		foreach (User u in Accounts.Users) 
		{
			foreach (Game g in u.Games) 
			{
				if(g.Rating >= rating)
				{
					Transform gameObj = Instantiate (gameCatelogObjPrefab);
					gameObj.parent = gameListPanelUI.transform; 
					gameObj.GetComponentInChildren<Text> ().text = "Title: " + g.Title + "\nGenre: " + g.GameGenre + "\nRating: " + g.Rating;
					gameObj.GetComponentInChildren<Button> ().onClick.AddListener (() => 
					                                                     {
						OpenArcadeGamePanelFromCatelog (g);});
				}
			}
		}
	}

	void OpenArcadeGamePanelFromCatelog(Game game)
	{
		ArcadeGamePanelUI.SetActive (true);
		CatelogPanelUI.SetActive (false);
		GeneralButtonsPanelUI.SetActive (false);
		GamesRoomPanelUI.SetActive (false);

		ArcadeGameTitle.GetComponent<Text> ().text = game.Title;
	}

	public void OpenArcadeGamePanel()
	{
		ArcadeGamePanelUI.SetActive (true);
		CatelogPanelUI.SetActive (false);
		GeneralButtonsPanelUI.SetActive (false);
		GamesRoomPanelUI.SetActive (false);

		ArcadeGameTitle.GetComponent<Text> ().text = Accounts.LoggedInUser.Games[0].Title;
	}

	public void CloseArcadeGamePanel()
	{
		ArcadeGamePanelUI.SetActive (false);
		CatelogPanelUI.SetActive (false);
		GeneralButtonsPanelUI.SetActive (true);
		GamesRoomPanelUI.SetActive (true);
	}

	public void OpenCatelog()
	{
		CatelogPanelUI.SetActive (true);
		GeneralButtonsPanelUI.SetActive (false);
		GamesRoomPanelUI.SetActive (false);
	}
	
	public void CloseCatelog()
	{
		CatelogPanelUI.SetActive (false);
		GeneralButtonsPanelUI.SetActive (true);
		GamesRoomPanelUI.SetActive (true);
	}

	public void SetDropdownGenreIndex(int index) {
		dropDownGenre.value = index;
	}

	public void SetDropdownRatingIndex(int index) {
		dropDownRating.value = index;
	}

	public void OpenSourceCode()
	{
		System.Diagnostics.Process.Start("notepad.exe");
	}
}
