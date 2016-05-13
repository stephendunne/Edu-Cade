using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum Genre {Action,Casual,Simulator,Racer};

public class Game 
{
	public string Title;
	public string Description;
	public string TechnologyUsed;
	//public Image Icon;
	public int Rating;
	public Genre GameGenre;

	public Game(string title, string desc, string technologyUsed, int rating, Genre gameGenre)
	{
		Title = title;
		Description = desc;
		TechnologyUsed = technologyUsed;
		//Icon = icon;
		Rating = rating;
		GameGenre = gameGenre;
	}

	public Game(string title, string desc, string technologyUsed, Genre gameGenre)
	{
		Title = title;
		Description = desc;
		TechnologyUsed = technologyUsed;
		//Icon = icon;
		Rating = 1;
		GameGenre = gameGenre;
	}
}
