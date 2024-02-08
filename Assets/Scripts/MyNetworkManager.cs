using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;
using Unity.Netcode.Transports.UTP;
using TMPro;
using UnityEngine.SceneManagement;

public class MyNetworkManager : NetworkManager
{
    //public event Action onServerInitiated;
    private GameObject[] players;
    int localPlayerIndex;
    private GameObject localPlayer;
    NetworkManager m_NetworkManager;

    UnityTransport m_Transport;

    GUIStyle m_LabelTextStyle;

    // This is needed to make the port field more convenient. GUILayout.TextField is very limited and we want to be able to clear the field entirely so we can't cache this as ushort.
    string m_PortString = "7777";
    string m_ConnectAddress = "127.0.0.1";
    const int maxPlayers = 10;

    private void Awake()
    {
        m_NetworkManager = GetComponent<NetworkManager>();
        m_Transport = (UnityTransport)m_NetworkManager.NetworkConfig.NetworkTransport;
    }
    public GameObject FindLocalPlayer()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<NetworkObject>().IsOwner)
            {
                localPlayerIndex = i;
                break;
            }
        }
        //if this function is called before the local is spawned
        try
        {
            return players[localPlayerIndex];
        }
        catch
        {
            Debug.Log("Player not spawned yet");
            return null;
        }

    }

    public GameObject[] FindListOfPlayers()
    {
        return players;
    }

    /*public GameObject FindLocalPlayerBeforeSpawning()
    {
        StartCoroutine(CheckForPlayer());
        Debug.Log("i got called");
        return localPlayer;
    }

    IEnumerator CheckForPlayer()
    {
        //recursive coroutine that runs every 2s until it finds the localplayer
        localPlayer = FindLocalPlayer();
        yield return new WaitForSecondsRealtime(2f);
        if (localPlayer == null)
        {
            StartCoroutine(CheckForPlayer());
        }
        
    }*/
    public void Host()
    {
        //m_ConnectAddress = ipField.text;
        //m_PortString = portField.text;
        if (ushort.TryParse(m_PortString, out ushort port))
        {
            m_Transport.SetConnectionData(m_ConnectAddress, port);
        }
        else
        {
            m_Transport.SetConnectionData(m_ConnectAddress, 7777);
        }
        NetworkManager.Singleton.ConnectionApprovalCallback += NetworkManager_ConnectionApprovalCallback;
        StartHost();
    }

    private void NetworkManager_ConnectionApprovalCallback(ConnectionApprovalRequest arg1,
        ConnectionApprovalResponse connectionApproval)
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Lobby")
        {
            connectionApproval.Approved = false;
            return;
        }
        if (NetworkManager.Singleton.ConnectedClients.Count >= maxPlayers)
        {
            connectionApproval.Approved = false;
            return;
        }
        connectionApproval.Approved = true;
        Debug.Log("connection approved");
    }

    public void ChangeIp(string ip)
    {
        m_ConnectAddress = ip;
    }
    public void ChangePort(string port)
    {
        m_PortString = port;
    }
    public void Client()
    {
        //m_ConnectAddress = ipField.text;
        //m_PortString = portField.text;
        if (ushort.TryParse(m_PortString, out ushort port))
        {
            m_Transport.SetConnectionData(m_ConnectAddress, port);
        }
        else
        {
            m_Transport.SetConnectionData(m_ConnectAddress, 7777);
        }
        StartClient();
    }

}

