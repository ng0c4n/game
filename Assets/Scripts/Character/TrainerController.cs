using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrainerController : MonoBehaviour, Interactable
{
    [SerializeField] string trainerName;
    [SerializeField] Sprite sprite;
    [SerializeField] Dialog dialog;
    [SerializeField] Dialog dialogAfterBattle;
    [SerializeField] AudioClip trainerAppearsClip;

    //State 
    bool battleLost = false;
    Character character;
    private void Awake()
    {
        character = GetComponent<Character>();
    }
    private void Start()
    {
    }
    private void Update()
    {
        character.HandleUpdate();
    }
    public void Interact(Transform initiator)
    {
        character.LookTowards(initiator.position);
        if (!battleLost)
        {
            AudioManager.i.PlayMusic(trainerAppearsClip);
            StartCoroutine(DialogManager.Instance.ShowDialog(dialog, () =>
            {
                GameController.Instance.StartTrainerBattle(this);
            }));
        }
        else
        {
            StartCoroutine(DialogManager.Instance.ShowDialog(dialogAfterBattle));
        }
    }
    public IEnumerator TriggerTrainerBattle(PlayerController player)
    {
        AudioManager.i.PlayMusic(trainerAppearsClip);
        //Show dialog
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog, () =>
        {
            GameController.Instance.StartTrainerBattle(this);
        }));
        yield return null;
    }
    public void BattleLost()
    {
        battleLost = true;
    }

    public string Name
    {
        get => trainerName;
    }
    public Sprite Sprite
    {
        get => sprite;
    }
}
