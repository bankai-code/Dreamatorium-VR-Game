using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
 
public class AudioController : MonoBehaviourPunCallbacks
{
    [SerializeField] public AudioSource bgmSource; // The AudioSource component attached to your BGM object
    [SerializeField] public AudioClip[] bgmClips; // An array of your 3 BGM tracks
 
    //public Button button1; // Reference to Button 1 in Unity Editor
    //public Button button2; // Reference to Button 2 in Unity Editor
 
    private void Start()
    {
        // Add onClick listeners to the buttons
        // button1.onClick.AddListener(Button1Clicked);
        // button2.onClick.AddListener(Button3Clicked);
    }
 
    public void StopMusic()
    {
        // if (photonView.IsMine)
        // {
            photonView.RPC(nameof(StopMusicRPC), RpcTarget.All);
        // }
    }
 
    [PunRPC]
    public void StopMusicRPC()
    {
        bgmSource.Stop();
    }
 
    public void PlayMusic(int trackNumber)
    {
        // if (photonView.IsMine)
        // {
            photonView.RPC(nameof(PlayMusicRPC), RpcTarget.All, trackNumber);
        // }
    }
 
    [PunRPC]
    public void PlayMusicRPC(int trackNumber)
    {
        if (bgmSource.isPlaying && bgmSource.clip == bgmClips[trackNumber])
        {
            StopMusicRPC();
        }
        else
        {
            StopMusicRPC();
            bgmSource.clip = bgmClips[trackNumber];
            bgmSource.Play();
        }
    }
 
    public void Button1Clicked()
    {
        PlayMusic(0); // Play the first BGM track
    }
 
    public void Button3Clicked()
    {
        PlayMusic(2); // Play the third BGM track
    }
}