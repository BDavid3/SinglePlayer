using System;
using UnityEngine;
using Yarn.Unity;
using System.Collections;

public class TelephoneInteract : InteractBlueprint
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private ExplosionScript explosionScript;

    private AudioSource _audioSource;
    private TelephoneRandomTrigger _telephoneRandomTriggerScript;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _telephoneRandomTriggerScript = GetComponent<TelephoneRandomTrigger>();

        dialogueRunner.AddCommandHandler("explode", () => StartCoroutine(ExplodeDelayed()));
    }

    protected override void OnInteract()
    {
        if (IsInteract)
        {
            isLocked = true;
            _audioSource.Stop();
            dialogueRunner.StartDialogue("MyCharacter");
        }
        else
        {
            _telephoneRandomTriggerScript.Restart();
        }
    }

    IEnumerator ExplodeDelayed()
    {
        yield return new WaitForSeconds(1f);
        explosionScript.Explode();
    }

}
