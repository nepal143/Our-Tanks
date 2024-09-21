using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private InputField createInput;
    private InputField joinInput;

    private void Start()
    {
        // Find input fields by their tag names
        createInput = GameObject.FindWithTag("CreateInput").GetComponent<InputField>();
        joinInput = GameObject.FindWithTag("JoinInput").GetComponent<InputField>();
    }

    public void CreateRoom()
    {
        Debug.Log("aa");
        PhotonNetwork.CreateRoom("aa");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("aa");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
