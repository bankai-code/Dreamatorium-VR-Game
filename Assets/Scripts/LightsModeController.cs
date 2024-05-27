using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
 
public class LightsModeController : MonoBehaviourPunCallbacks
{
    private GameObject[] pointLights;
 
    public Button Mode1;
    public Button Mode2;
    public Button Mode3;

    public Color Mode1Color;
    public Color Mode2Color;
    public Color Mode3Color;
 
    // Start is called before the first frame update
    void Start()
    {
        pointLights = GameObject.FindGameObjectsWithTag("Lights");
 
        LightMode2();
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
 
    public void LightMode1()
    {
        photonView.RPC("LightMode1RPC", RpcTarget.All);
 
    }
 
    [PunRPC]
    public void LightMode1RPC(){
        foreach(GameObject pointLight in pointLights)
        {
            pointLight.GetComponent<Light>().color = Mode1Color;
        }
 
        Mode1.image.color = Color.red;
        Mode2.image.color = Color.white;
        Mode3.image.color = Color.white;
    }
 
 
    public void LightMode2()
    {
        photonView.RPC("LightMode2RPC", RpcTarget.All);
 
    }
 
    [PunRPC]
    public void LightMode2RPC(){
        foreach(GameObject pointLight in pointLights)
        {
            pointLight.GetComponent<Light>().color = Mode2Color;
        }
        Mode1.image.color = Color.white;
        Mode2.image.color = Color.red;
        Mode3.image.color = Color.white;
    }
 
 
    public void LightMode3()
    {
        photonView.RPC("LightMode3RPC", RpcTarget.All);
 
    }
 
    [PunRPC]
    public void LightMode3RPC(){
        foreach(GameObject pointLight in pointLights)
        {
            pointLight.GetComponent<Light>().color = Mode3Color;
        }
        Mode1.image.color = Color.white;
        Mode2.image.color = Color.white;
        Mode3.image.color = Color.red;
    }
}