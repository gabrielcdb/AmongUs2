using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject startMenu;
    public GameObject startButton;
    public GameObject resetButton;

    public GameObject NbImpostor;
    public GameObject ConfirmEject;
    public GameObject EmergencyMeeting;
    public GameObject EmergencyCooldown;
    public GameObject DiscussionTime;
    public GameObject VotingTime;
    public GameObject PlayerSpeed;
    public GameObject CrewmateVision;
    public GameObject ImpostorVision;
    public GameObject KillCooldown;
    public GameObject KillDistance;
    public GameObject VisualTasks;
    public GameObject FastTasks;
    public GameObject MediumTasks;
    public GameObject LongTasks;
    public GameObject Nbjoueurs;

    private string nbImpostor = 2.ToString();
    private string confirmEject = "V";
    private string emergencyMeeting = 2.ToString();
    private string emergencyCooldown = 30.ToString();
    private string discussionTime = 30.ToString();
    private string votingTime = 60.ToString();
    private string playerSpeed = 1.ToString();
    private string crewmateVision = 1.ToString();
    private string impostorVision = 1.ToString();
    private string killCooldown = 30.ToString();
    private string killDistance = 5.ToString();
    private string visualTasks = "V";
    private string fastTasks = 2.ToString();
    private string mediumTasks = 3.ToString();
    private string longTasks = 1.ToString();
    private string nbjoueurs = 10.ToString();

    public GameObject caller;

    /// <summary>Attempts to connect to the server.</summary>
    public void Reset()
    {
        nbImpostor = 2.ToString();
        confirmEject = "V";
        emergencyMeeting = 2.ToString();
        emergencyCooldown = 30.ToString();
        discussionTime = 30.ToString();
        votingTime = 60.ToString();
        playerSpeed = 1.ToString();
        crewmateVision = 1.ToString();
        impostorVision = 1.ToString();
        killCooldown = 30.ToString();
        killDistance = 5.ToString();
        visualTasks = "V";
        fastTasks = 2.ToString();
        mediumTasks = 3.ToString();
        longTasks = 1.ToString();
        nbjoueurs = 10.ToString();
        SetValues();
    }
    public void OpenSeeSettings()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        startMenu.SetActive(true);
        startButton.SetActive(false);
        resetButton.SetActive(false);
    }
    public void OpenModifySettings()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        startMenu.SetActive(true);
        startButton.SetActive(true);
        resetButton.SetActive(true);
    }
    public void Close()
    {
        startButton.SetActive(false);
        resetButton.SetActive(false);
        startMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        caller.GetComponent<Control>().isMenuOpened = false;
    }
    
    public void StartGame()
    {
        GetValues();
        int a = int.Parse(nbImpostor);
        bool confirmeject = false;
        if (confirmEject == "V")
        {
            confirmeject = true;
        }
        int c = int.Parse(emergencyMeeting);
        int d = int.Parse(emergencyCooldown);
        int e = int.Parse(discussionTime) ;
        int f = int.Parse(votingTime);
        int g = int.Parse(playerSpeed);
        int h = int.Parse(crewmateVision);
        int i = int.Parse(impostorVision);
        int j = int.Parse(killCooldown);
        int k = int.Parse(killDistance);
        bool l = false;
        if (visualTasks == "V")
        {
            l = true;
        }
        int m = int.Parse(fastTasks);
        int n = int.Parse(mediumTasks);
        int o = int.Parse(longTasks);
        int p = int.Parse(nbjoueurs);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        caller.GetComponent<Control>().isMenuOpened = false;
        PhotonNetwork.LoadLevel("GameScene");
        SceneManager.LoadScene("GameScene");
        
    }

    private void GetValues()
    {
        nbImpostor =  NbImpostor.GetComponent<UnityEngine.UI.Text>().text;
        confirmEject = ConfirmEject.GetComponent<UnityEngine.UI.Text>().text;
        emergencyMeeting = EmergencyMeeting.GetComponent<UnityEngine.UI.Text>().text;
        emergencyCooldown = EmergencyCooldown.GetComponent<UnityEngine.UI.Text>().text;
        discussionTime = DiscussionTime.GetComponent<UnityEngine.UI.Text>().text;
        votingTime = VotingTime.GetComponent<UnityEngine.UI.Text>().text;
        playerSpeed = PlayerSpeed.GetComponent<UnityEngine.UI.Text>().text;
        crewmateVision = CrewmateVision.GetComponent<UnityEngine.UI.Text>().text;
        impostorVision = ImpostorVision.GetComponent<UnityEngine.UI.Text>().text;
        killCooldown = KillCooldown.GetComponent<UnityEngine.UI.Text>().text;
        killDistance = KillDistance.GetComponent<UnityEngine.UI.Text>().text;
        visualTasks = VisualTasks.GetComponent<UnityEngine.UI.Text>().text;
        fastTasks = FastTasks.GetComponent<UnityEngine.UI.Text>().text;
        mediumTasks = MediumTasks.GetComponent<UnityEngine.UI.Text>().text;
        longTasks = LongTasks.GetComponent<UnityEngine.UI.Text>().text;
        nbjoueurs = Nbjoueurs.GetComponent<UnityEngine.UI.Text>().text;
    }
    private void SetValues()
    {
        NbImpostor.GetComponent<UnityEngine.UI.Text>().text = nbImpostor;
        ConfirmEject.GetComponent<UnityEngine.UI.Text>().text = confirmEject;
        EmergencyMeeting.GetComponent<UnityEngine.UI.Text>().text = emergencyMeeting;
        EmergencyCooldown.GetComponent<UnityEngine.UI.Text>().text = emergencyCooldown;
        DiscussionTime.GetComponent<UnityEngine.UI.Text>().text = discussionTime;
        VotingTime.GetComponent<UnityEngine.UI.Text>().text = votingTime;
        PlayerSpeed.GetComponent<UnityEngine.UI.Text>().text = playerSpeed;
        CrewmateVision.GetComponent<UnityEngine.UI.Text>().text = crewmateVision;
        ImpostorVision.GetComponent<UnityEngine.UI.Text>().text = impostorVision;
        KillCooldown.GetComponent<UnityEngine.UI.Text>().text = killCooldown;
        KillDistance.GetComponent<UnityEngine.UI.Text>().text = killDistance;
        VisualTasks.GetComponent<UnityEngine.UI.Text>().text = visualTasks;
        FastTasks.GetComponent<UnityEngine.UI.Text>().text = fastTasks;
        MediumTasks.GetComponent<UnityEngine.UI.Text>().text = mediumTasks;
        LongTasks.GetComponent<UnityEngine.UI.Text>().text = longTasks;
        Nbjoueurs.GetComponent<UnityEngine.UI.Text>().text = nbjoueurs;
    }
    public void Impostor(int quantity)
    {
        nbImpostor = (int.Parse(nbImpostor) + quantity).ToString();
        NbImpostor.GetComponent<UnityEngine.UI.Text>().text = nbImpostor;
    }
    public void ConfirmEjection()
    {
        confirmEject = (confirmEject == "V") ? "X" : "V";
        ConfirmEject.GetComponent<UnityEngine.UI.Text>().text = confirmEject;
    }
    public void EmerMeetings(int quantity)
    {
        emergencyMeeting = (int.Parse(emergencyMeeting) + quantity).ToString();
        EmergencyMeeting.GetComponent<UnityEngine.UI.Text>().text = emergencyMeeting;
    }
    public void EmerCooldown(int quantity)
    {
        emergencyCooldown = (int.Parse(emergencyCooldown) + quantity).ToString();
        EmergencyCooldown.GetComponent<UnityEngine.UI.Text>().text = emergencyCooldown;
    }
    public void DiscuTime(int quantity)
    {
        discussionTime = (int.Parse(discussionTime) + quantity).ToString();
        DiscussionTime.GetComponent<UnityEngine.UI.Text>().text = discussionTime;
    }
    public void VoteTime(int quantity)
    {
        votingTime = (int.Parse(votingTime) + quantity).ToString();
        VotingTime.GetComponent<UnityEngine.UI.Text>().text = votingTime;
    }
    public void Playerspeed(int quantity)
    {
        playerSpeed = (int.Parse(playerSpeed) + quantity).ToString();
        PlayerSpeed.GetComponent<UnityEngine.UI.Text>().text = playerSpeed;
    }
    public void CrewVision(int quantity)
    {
        crewmateVision = (int.Parse(crewmateVision) + quantity).ToString();
        CrewmateVision.GetComponent<UnityEngine.UI.Text>().text = crewmateVision;
    }
    public void ImpoVision(int quantity)
    {
        impostorVision = (int.Parse(impostorVision) + quantity).ToString();
        ImpostorVision.GetComponent<UnityEngine.UI.Text>().text = impostorVision;
    }
    public void Killcooldown(int quantity)
    {
        killCooldown = (int.Parse(killCooldown) + quantity).ToString();
        KillCooldown.GetComponent<UnityEngine.UI.Text>().text = killCooldown;
    }
    public void Killdistance(int quantity)
    {
        killDistance = (int.Parse(killDistance) + quantity).ToString();
        KillDistance.GetComponent<UnityEngine.UI.Text>().text = killDistance;
    }
    public void VisualTask()
    {
        visualTasks = (visualTasks == "V") ? "X" : "V";
        VisualTasks.GetComponent<UnityEngine.UI.Text>().text = visualTasks;
    }
    public void FastTask(int quantity)
    {
        fastTasks = (int.Parse(fastTasks) + quantity).ToString();
        FastTasks.GetComponent<UnityEngine.UI.Text>().text = fastTasks;
    }
    public void MediumTask(int quantity)
    {
        mediumTasks = (int.Parse(mediumTasks) + quantity).ToString();
        MediumTasks.GetComponent<UnityEngine.UI.Text>().text = mediumTasks;
    }
    public void LongTask(int quantity)
    {
        longTasks = (int.Parse(longTasks) + quantity).ToString();
        LongTasks.GetComponent<UnityEngine.UI.Text>().text = longTasks;
    }
    public void NbJoueurs(int quantity)
    {
        nbjoueurs = (int.Parse(nbjoueurs) + quantity).ToString();
        Nbjoueurs.GetComponent<UnityEngine.UI.Text>().text = nbjoueurs;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(nbImpostor);
            stream.SendNext(confirmEject);
            stream.SendNext(emergencyMeeting);
            stream.SendNext(emergencyCooldown);
            stream.SendNext(discussionTime);
            stream.SendNext(votingTime);
            stream.SendNext(playerSpeed);
            stream.SendNext(crewmateVision);
            stream.SendNext(impostorVision);
            stream.SendNext(killCooldown);
            stream.SendNext(killDistance);
            stream.SendNext(visualTasks);
            stream.SendNext(fastTasks);
            stream.SendNext(mediumTasks);
            stream.SendNext(longTasks);
            stream.SendNext(nbjoueurs);
        }
        else
        {
            nbImpostor = (string)stream.ReceiveNext();
            confirmEject = (string)stream.ReceiveNext();
            emergencyMeeting = (string)stream.ReceiveNext();
            emergencyCooldown = (string)stream.ReceiveNext();
            discussionTime = (string)stream.ReceiveNext();
            votingTime = (string)stream.ReceiveNext();
            playerSpeed = (string)stream.ReceiveNext();
            crewmateVision = (string)stream.ReceiveNext();
            impostorVision = (string)stream.ReceiveNext();
            killCooldown = (string)stream.ReceiveNext();
            killDistance = (string)stream.ReceiveNext();
            visualTasks = (string)stream.ReceiveNext();
            fastTasks = (string)stream.ReceiveNext();
            mediumTasks = (string)stream.ReceiveNext();
            longTasks = (string)stream.ReceiveNext();
            nbjoueurs = (string)stream.ReceiveNext();
            SetValues();
        }
    }
}
