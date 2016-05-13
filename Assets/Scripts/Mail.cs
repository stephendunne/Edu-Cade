using UnityEngine;
using System.Collections;
using System;

public class Mail
{

	public User FromUser;
	public User ToUser;
	public DateTime SendDate;
	public string Subject;
	public string Message;

	public Mail(User from, User to, string subject, string message)
	{
		FromUser = from;
		ToUser = to;
		SendDate = DateTime.Now;
		Subject = subject;
		Message = message;
	}
}
