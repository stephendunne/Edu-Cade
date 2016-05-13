using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MailControls : MonoBehaviour {

	public GameObject mailBoxPanelUI;
	public GameObject messageListPanelUI;
	public GameObject messagePanelUI;
	public GameObject composeMessagePanelUI;

	public GameObject mailFromText;
	public GameObject mailToText;
	public GameObject mailSendDateText;
	public GameObject mailSubjectText;
	public GameObject mailMessageText;

	public Transform messageButtonPrefab;

	public enum MailBoxOptions {inbox,sentbox}

	public UserControls userControls;

	public GameObject newMessageUsernameText;
	public GameObject newMessageSubjectText;
	public GameObject newMessageMessageText;

	//DROPDOWN RELATED METHODS
	public Dropdown mailboxDropdown;

	void Start() {
		mailboxDropdown.onValueChanged.AddListener(delegate {
			mailboxDropdownValueChangedHandler(mailboxDropdown);
		});
	}
	void Destroy() {
		mailboxDropdown.onValueChanged.RemoveAllListeners();
	}
	
	private void mailboxDropdownValueChangedHandler(Dropdown target) {
		if (target.value == 0) 
		{
			OpenInbox();
		}

		if (target.value == 1) 
		{
			OpenSentbox();
		}
	}
	
	public void SetDropdownIndex(int index) {
		mailboxDropdown.value = index;
	}
	//END OF DROPDOWN RELATED METHODS


	public void OpenInbox()
	{
		foreach(Transform child in messageListPanelUI.transform)
		{
			child.gameObject.SetActive(false);
		}

		foreach(Mail m in Accounts.LoggedInUser.Inbox)
		{
			Transform messageButton = Instantiate(messageButtonPrefab);
			messageButton.parent =  messageListPanelUI.transform; 
			messageButton.GetComponentInChildren<Text>().text = "From: " + m.FromUser.Username + ". Subject: " + m.Subject + ". Received: " + m.SendDate;
			messageButton.GetComponent<Button>().onClick.AddListener(() => 
			                                                         { OpenMessage(m);});
		}
	}

	public void OpenSentbox()
	{
		foreach(Transform child in messageListPanelUI.transform)
		{
			child.gameObject.SetActive(false);
		}

		foreach (Mail m in Accounts.LoggedInUser.Sentbox) 
		{
			Transform messageButton = Instantiate (messageButtonPrefab);
			messageButton.parent = messageListPanelUI.transform; 
			messageButton.GetComponentInChildren<Text> ().text = "To: " + m.ToUser.Username + ". Subject: " + m.Subject + ". Sent: " + m.SendDate;
			messageButton.GetComponent<Button>().onClick.AddListener(() => 
			                                                         { OpenMessage(m);});
		}
	}

	public void OpenMessage(Mail mail)
	{
		mailBoxPanelUI.SetActive (false);
		composeMessagePanelUI.SetActive (false);
		messagePanelUI.SetActive (true);

		mailFromText.GetComponent<Text>().text = "From: " + mail.FromUser.Username;
		mailToText.GetComponent<Text>().text = "To: " + mail.ToUser.Username;
		mailSendDateText.GetComponent<Text>().text = "Sent: " + mail.SendDate.ToString();
		mailSubjectText.GetComponent<Text>().text = "Subject: " + mail.Subject;
		mailMessageText.GetComponent<Text>().text = mail.Message;
	}

	public void OpenComposeMessagePanel()
	{
		mailBoxPanelUI.SetActive (false);
		messagePanelUI.SetActive (false);
		composeMessagePanelUI.SetActive (true);
	}

	public void CancelComposeMessage()
	{
		newMessageUsernameText.GetComponent<Text> ().text = "";
		newMessageSubjectText.GetComponent<Text> ().text = "";
		newMessageMessageText.GetComponent<Text> ().text = "";

		mailBoxPanelUI.SetActive (true);
		messagePanelUI.SetActive (false);
		composeMessagePanelUI.SetActive (false);
	}

	public void SendNewMessage()
	{
		string xUsername = newMessageUsernameText.GetComponent<Text> ().text;
		string xSubject = newMessageSubjectText.GetComponent<Text> ().text;
		string xMessage = newMessageMessageText.GetComponent<Text> ().text;


		foreach (User u in Accounts.Users) 
		{
			if (u.Username == xUsername)
			{
				Mail newMail = new Mail (Accounts.LoggedInUser, u, xSubject, xMessage);
				Accounts.LoggedInUser.Sentbox.Add (newMail);
				u.Inbox.Add (newMail);
			}
		}

		CancelComposeMessage ();
	}

	public void CloseMessage()
	{
		mailBoxPanelUI.SetActive (true);
		composeMessagePanelUI.SetActive (false);
		messagePanelUI.SetActive (false);
	}

}
