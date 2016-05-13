using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccountControls : MonoBehaviour {

	public GameObject GreetingsPanelUI;
	public GameObject LoginPanelUI;
	public GameObject RegisterPanelUI;

	public GameObject inputLoginUsername;
	public GameObject inputLoginPassword;
	public GameObject lblLoginDialog;
	public GameObject lblRegisterDialog;

	public GameObject inputRegisterUsername;
	public GameObject inputRegisterPassword;
	public GameObject inputRegisterRealname;
	public GameObject inputRegisterCollege;
	public GameObject inputRegisterYear;
	public GameObject inputRegisterProgLang;
	public GameObject inputRegisterIDE;

	public void LoginUser()
	{
		bool foundUser = false;

		foreach (User u in Accounts.Users) 
		{
			if(u.Username == inputLoginUsername.GetComponent<Text>().text && u.Password == inputLoginPassword.GetComponent<Text>().text)
			{
				Accounts.LoggedInUser = u;
				foundUser = true;
				Application.LoadLevel(1);
			}
		}

		if (!foundUser) 
		{
			lblLoginDialog.GetComponent<Text>().text = "No user found with this username or password. Try again";
		}
	}

	public void RegisterUser()
	{
		string u = inputRegisterUsername.GetComponent<Text>().text;
		string pass = inputRegisterPassword.GetComponent<Text>().text;
		string rn = inputRegisterRealname.GetComponent<Text>().text;
		string c = inputRegisterCollege.GetComponent<Text>().text;
		string y = inputRegisterYear.GetComponent<Text>().text;
		string pl = inputRegisterProgLang.GetComponent<Text>().text;
		string ide = inputRegisterIDE.GetComponent<Text>().text;

		if (u == "" || pass == "" || rn == "" || c == "" || y == "" || pl == "" || ide == "") 
		{
			lblRegisterDialog.GetComponent<Text>().text = "Please fill in all fields below to register";
		} 
		else 
		{
			bool UserWithSameName = false;
			
			foreach (User user in Accounts.Users)
				if (user.Username == u)
					UserWithSameName = true;
			
			if (!UserWithSameName) {
				User xUser = new User (u, pass, rn, c, y, pl, ide);
				Accounts.Users.Add (xUser);
				Accounts.LoggedInUser = xUser;
				Application.LoadLevel(1);
			} 
			else {
				lblRegisterDialog.GetComponent<Text> ().text = "Username taken. Try another";
			}
		}
			

	}

	public void GoToRegistration()
	{
		LoginPanelUI.SetActive (false);
		RegisterPanelUI.SetActive (true);
	}
}
