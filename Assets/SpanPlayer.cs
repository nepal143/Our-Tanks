using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun  ; 
public class SpanPlayer : MonoBehaviour
{
    public GameObject playerPrefab ; 
    public int minX ; 
    public int maxX ; 
    public int minZ ; 
    public int maxZ ; 

    // Start is called before the first frame update
    void Start()
    {

        Vector3 randomPosition = new Vector3(Random.Range(minX , maxX) , 10, Random.Range(minZ , maxZ)); 
        PhotonNetwork.Instantiate(playerPrefab.name , randomPosition , Quaternion.identity) ; 

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
