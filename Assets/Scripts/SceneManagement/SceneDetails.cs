using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDetails : MonoBehaviour
{
    [SerializeField] List<SceneDetails> connectedScenes;
    [SerializeField] AudioClip sceneMusic;
    public bool IsLoaded {  get; private set; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log($"Entered {gameObject.name}");
            LoadScene();
            GameController.Instance.SetCurrentScene(this);
            if(sceneMusic != null ) 
                AudioManager.i.PlayMusic(sceneMusic);

            //Load all connected scenes
            foreach(var scene in connectedScenes)
            {
                scene.LoadScene();
            }
            //Unload the scenes that are no longer connected
            if(GameController.Instance.PrevScene != null)
            {
                var prevLoadedScene = GameController.Instance.PrevScene.connectedScenes;
                foreach(var scene in prevLoadedScene)
                {
                    if(!connectedScenes.Contains(scene) && scene != this)
                        scene.UnLoadScene();
                }
            }
        }
    }
    public void LoadScene()
    {
        if (!IsLoaded)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            IsLoaded = true;
        }
    }

    public void UnLoadScene()
    {
        if (IsLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            IsLoaded = false;
        }
    }
    public AudioClip SceneMusic => sceneMusic;
}
