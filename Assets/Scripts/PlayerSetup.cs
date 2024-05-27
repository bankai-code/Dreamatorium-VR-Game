using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    public GameObject camera;
    public GameObject character; // Reference to the character GameObject
    public TextMeshProUGUI playerIDText; // Reference to the TextMeshPro text field

    public int playerID;

    void Start()
    {
        // Generate a random player ID between 100 and 999
        playerID = Random.Range(100, 1000);
        
        // Set the player ID text
        if (playerIDText != null)
        {
            playerIDText.text = "Player " + playerID.ToString();
        }
        else
        {
            Debug.LogError("Player ID Text field is not assigned.");
        }
    }

    public void isLocalPlayer()
    {
        camera.SetActive(true);
        
        photonView.RPC("Color", RpcTarget.All);

        // character.SetActive(false);
    }

    [PunRPC]
    public void Color()
    {
        // Change character color to a random color
        Renderer renderer = character.transform.Find("Body").gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            Debug.Log("renderer found");
            Material[] materials = renderer.materials;

            // Check if there are at least two materials (material1 and material2)
            if (materials.Length >= 2)
            {
                // Assuming material2 is the second material in the array (index 1)
                Material material2 = materials[0]; // Change the index if material2 is at a different position

                Debug.Log(material2.color);

                // Change the color of material2
                material2.color = Random.ColorHSV(); // Replace Color.red with your desired color

                Debug.Log(material2.color);
            }
        }
        else
        {
            Debug.Log("renderer not found");
            Debug.LogError("Character GameObject does not have a Renderer component.");
        }

        

        if (playerIDText != null)
        {
            playerIDText.text = "Player " + playerID.ToString();
        }
        else
        {
            Debug.LogError("Player ID Text field is not assigned.");
        }
    }
}
