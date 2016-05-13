using UnityEngine;
using System.Collections;

public class DebugPropertyGenerator : MonoBehaviour
{

	// Use this for initialization
	void Start () 
	{
		var userA = new User("steveydunne","password","Stephen Dunne","IT Sligo","4th","C#","Unity");
		var userB = new User("qwerty","password","Robert Matthews","DIT","3rd","C++","Visual Studios");
		var userC = new User("celticbeast","password","Matt Murdoch","IT Sligo","2nd","C#","Game Maker");

		var inboxA = new Mail(userB,userA,"Nice game","Hey steve,\n just wanted to say that your HCI project is pretty awesome. Good work!\n Bob");
		var inboxB = new Mail(userC,userA,"Good work","Steveydunne,\n How are you, just noticed a bug in Racing Pro!\nWant some help with it?\n Matty");

		userA.Inbox.Add (inboxA);
		userA.Inbox.Add (inboxB);

		userB.Sentbox.Add (inboxA);
		userC.Sentbox.Add (inboxB);

		var gameA = new Game ("Racing Pro", "First racing game prototype developed in Unity", "Unity", 5, Genre.Racer);
		var gameB = new Game ("DigiCenter", "Digital City Simulator. Just a tester to see if uploading to this works", "Unity", 5, Genre.Simulator);
		var gameC = new Game ("Rover", "Project for Games Fleadh. Made in 48 hours", "Visual Studio", 3, Genre.Action);
		var gameD = new Game ("BuilderBlocks", "Just learning the ropes with Game Maker. Sorry if it's not good!", "Game Maker", 4, Genre.Casual);

		userA.Games.Add (gameA);
		userA.Games.Add (gameB);
		userB.Games.Add (gameC);
		userC.Games.Add (gameD);


		Accounts.Users.Add (userA);
		Accounts.Users.Add (userB);
		Accounts.Users.Add (userC);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
