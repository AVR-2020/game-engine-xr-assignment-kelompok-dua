using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSound : MonoBehaviour
{
    private AudioSource gunAudio;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    // Start is called before the first frame update
    void Start()
    {
        gunAudio = GetComponent<AudioSource>();
        StartCoroutine(ShotEffect());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        
        yield return shotDuration;
    }
}
