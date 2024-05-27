using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDart : MonoBehaviour
{
    private Rigidbody rb;

    private bool onBoard = false;
    
    public float force = 1000f;
    public string dartBoardTag = "DartBoard";

    private GameObject DartHitSphere;
    private GameObject DartHitSphereMULTI;
    private GameObject new_hitsphere;

    private DartScoreSystem dartScoreSystem;

    private DartHitShereSpawn dartHitShereSpawn;

    public AudioClip dartHitsound; // The audio clip to be played
    private AudioSource audioSource;

    // private bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.AddForce(transform.forward * force);

        DartHitSphere = GameObject.Find("dartHitSphere");
        DartHitSphereMULTI = GameObject.Find("DartHitSphereMULTI");

        dartScoreSystem = GameObject.Find("DartScoreSystem").GetComponent<DartScoreSystem>();

        dartHitShereSpawn = DartHitSphereMULTI.GetComponent<DartHitShereSpawn>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.CompareTag(dartBoardTag))
            {
                if(transform.parent == null)
                {
                    FreezePosition();
                    
                    // Calculate the vector from the center of the collided object to the contact point
                    Vector3 vectorToContactPoint = contact.point - collision.transform.position;

                    dartHitShereSpawn.SpawnSphere(contact.point, collision.gameObject.transform.localScale.x);
                        
                    // Calculate the Euclidean distance (magnitude) of the vector
                    if(!onBoard)
                    {
                        new_hitsphere = (GameObject)Instantiate(DartHitSphere);
                        new_hitsphere.transform.position = new Vector3(contact.point.x, contact.point.y, contact.point.z);
                        new_hitsphere.transform.SetParent(collision.gameObject.transform);
                        new_hitsphere.GetComponent<Outline>().enabled = true;

                        audioSource.clip = dartHitsound;
                        audioSource.Play();

                        transform.SetParent(new_hitsphere.transform);

                        onBoard = true;

                        float distance = vectorToContactPoint.magnitude;

                        // Debug.Log("Distance from center to collision point: " + distance);

                        dartScoreSystem.GetComponent<DartScoreSystem>().UpdateScore(distance, collision.gameObject.transform.localScale.x);
                    }
                }
            }
        }
        
    }

    void FreezePosition()
    {
        // Freeze the position along the X axis
        rb.constraints |= RigidbodyConstraints.FreezePositionX;
        
        // Freeze the position along the Y axis
        rb.constraints |= RigidbodyConstraints.FreezePositionY;
        
        // Freeze the position along the Z axis
        rb.constraints |= RigidbodyConstraints.FreezePositionZ;
    }
}
