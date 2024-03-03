using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationPortals : MonoBehaviour, IPlayerTrigger
{
    [SerializeField] DestinationIdentifier destinationPortal;
    [SerializeField] Transform spawnPoint;
    PlayerController player;
    public void onPlayerTrigger(PlayerController player)
    {
        player.Character.Animator.IsMoving = false;
        this.player = player;
        StartCoroutine(Teleport());
    }
    Fader fader;
    private void Start()
    {
        fader = FindObjectOfType<Fader>();
    }
    IEnumerator Teleport()
    {
        GameController.Instance.PauseGame(true);
        yield return fader.FadeIn(0.5f);

        var destPortal = FindObjectsOfType<LocationPortals>().First(x => x != this && x.destinationPortal == this.destinationPortal);
        player.Character.SetPositionAndSnapToTile(destPortal.SpawnPoint.position);

        yield return fader.FadeOut(0.5f);
        GameController.Instance.PauseGame(false);
    }
    public Transform SpawnPoint => spawnPoint;
}
