using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;
    private AudioSource audioSource;
    private float warningSoundTimer;
    private bool playWarningSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burnShowProcessAmount = .5f;
        playWarningSound = stoveCounter.isFired() && e.progressNormalized >= burnShowProcessAmount;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool playSound = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        if (playSound)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Update()
    {
        if (playWarningSound)
        {
            PlayWarningSound();
        }

    }

    private void PlayWarningSound()
    {
        warningSoundTimer -= Time.deltaTime;
        if (warningSoundTimer <= 0f)
        {
            float warningSoundTimerMax = 0.2f;
            warningSoundTimer = warningSoundTimerMax;

            SoundManager.Instance.PlayWarningSound(stoveCounter.transform.position);
        }
    }
}