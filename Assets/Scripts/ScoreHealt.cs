using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHealt : MonoBehaviour
{
    public static int Healt = 100;
    public Text HealtText;

    public static int Score = 0;
    public Text ScoreText;

    public static int Gold;
    public Text GoldText;

    AudioSource audioSource;
    public AudioClip[] audioClips;

    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }



    private void Update()
    {

        HealtText.text = Healt.ToString();
        ScoreText.text = Score.ToString();
        GoldText.text = Gold.ToString();

    }
    public void ScorePlus()
    {
        Debug.Log("ScorePlusa giriyoz");
        audioSource.PlayOneShot(audioClips[0]);
    }

    public void GotGold()
    {
        Debug.Log("altýný aldý");
        audioSource.PlayOneShot(audioClips[1]);
    }

    public void LeaveGold()
    {
        Debug.Log("altýný exite býraktý");
        audioSource.PlayOneShot(audioClips[2]);
    }

}
