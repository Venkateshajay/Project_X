using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class MySceneManager : NetworkBehaviour
{

    private int noOfPlayersConnected = 0;
    private int noOfPlayersAreReady = 0;
    private MyNetworkManager networkManager;
    public bool allReady = false;
    [SerializeField] private bool imReady = false;

    private void Start()
    {
        networkManager = FindObjectOfType<MyNetworkManager>().GetComponent<MyNetworkManager>();
        networkManager.OnClientConnectedCallback += UpdatePlayersConnected;
    }

    private void UpdatePlayersConnected(ulong clientId)
    {
        if (!IsServer) return;
        noOfPlayersConnected = networkManager.ConnectedClients.Count;
    }

    public void Ready()
    {
        if (IsServer)
        {
            if (allReady || networkManager.ConnectedClients.Count <= 1)
            {
                LoadNextScene();
            }
        }
        else
        {
            imReady = !imReady;
            UpdateNoOfPlayersReadyServerRpc(imReady);
        }

    }

    [ServerRpc(RequireOwnership = false)]

    private void UpdateNoOfPlayersReadyServerRpc(bool value)
    {
        if (value)
        {
            noOfPlayersAreReady++;
        }
        else
        {
            noOfPlayersAreReady--;
        }

    }

    private void LoadNextScene()
    {
        NetworkManager.Singleton.SceneManager.LoadScene("CodexScene", LoadSceneMode.Single);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void Update()
    {
        if (!IsServer) return;
        if (noOfPlayersConnected - 1 == noOfPlayersAreReady)
        {
            allReady = true;
        }
        else
        {
            allReady = false;
        }
    }
}
