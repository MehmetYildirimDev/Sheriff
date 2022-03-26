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

    }
    public void ScorePlus()
    {
        Debug.Log("ScorePlusa giriyoz");
        audioSource.PlayOneShot(audioClips[0]);
    }

}
