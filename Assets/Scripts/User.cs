using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class User 
{
	public string Username;
	public string Password;

	public string Realname;
	public string College;
	public string Year;
	public string ProgLanguage;
	public string IDE;


	public List<Mail> Inbox = new List<Mail>();
	public List<Mail> Sentbox = new List<Mail>();
	public List<Game> Games = new List<Game>();

	public User(string userName, string password, string realName, string college, string year, string progLanguage, string ide)
	{
		Username = userName;
		Password = password;
		Realname = realName;
		College = college;
		Year = year;
		ProgLanguage = progLanguage;
		IDE = ide;
	}
}
