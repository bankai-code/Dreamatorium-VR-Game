using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DartHitShereSpawn : MonoBehaviourPunCallbacks
{
    [SerializeField] public Vector3 Position;
    [SerializeField] public float scale;

    public GameObject BoardSmall;
    public GameObject BoardLarge;

    private GameObject DartHitSphere;
    

    GameObject new_hitsphere;
    // Start is called before the first frame update
    void Start()
    {
        DartHitSphere = GameObject.Find("dartHitSphere");
    }
    public void SpawnSphere(Vector3 position, float scale)
    {
        photonView.RPC("SpawnSphereRPC", RpcTarget.All, position, scale);
    }
    [PunRPC]
    public void SpawnSphereRPC(Vector3 position, float scale)
    {
        new_hitsphere = (GameObject)Instantiate(DartHitSphere);
        new_hitsphere.transform.position = new Vector3(position.x, position.y, position.z);

        if(scale > 1f)
        {
            new_hitsphere.transform.SetParent(BoardLarge.transform);
        }
        else
        {
            new_hitsphere.transform.SetParent(BoardSmall.transform);
        }
        // 

        new_hitsphere.GetComponent<Outline>().enabled = true;
    }
}
