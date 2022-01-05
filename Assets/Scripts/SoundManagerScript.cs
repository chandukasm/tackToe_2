using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip draw, turn, xturn, win;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        draw = Resources.Load<AudioClip>("draw");
        turn = Resources.Load<AudioClip>("turn");
        xturn = Resources.Load<AudioClip>("xturn");
        win = Resources.Load<AudioClip>("win");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "draw":
                audioSrc.PlayOneShot(draw);
                break;
            case "turn":
                audioSrc.PlayOneShot(turn);
                break;
            case "xturn":
                audioSrc.PlayOneShot(xturn);
                break;
            case "win":
                audioSrc.PlayOneShot(win);
                break;


        }
    }
}
