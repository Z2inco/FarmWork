using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] ScreenTint screenTint;
    [SerializeField] CameraConfiner cameraConfiner;
    string currentScene;
    AsyncOperation unload;
    AsyncOperation load;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;    
    }

    public void InitSwitchScene(string to, Vector3 targetPosition)
    {
        StartCoroutine(Transition(to, targetPosition));
    }

    IEnumerator Transition(string to, Vector3 targetPosition)
    {
        screenTint.Tint();

        yield return new WaitForSeconds(1f / screenTint.speed + 0.1f);

        SwitchScene(to, targetPosition);

        while (load != null & unload != null)
        {
            if (load.isDone) { load = null; }
            if (unload.isDone) { unload = null; }
            yield return new WaitForSeconds(0.1f);
            
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentScene));

        cameraConfiner.UpdateBounds();

        screenTint.UnTint();
    }

    public void SwitchScene(string to,Vector3 targetPosition)
    {
        load = SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        unload = SceneManager.UnloadSceneAsync(currentScene);
        currentScene = to;
        Transform playerTranform = GameManager.instance.player.transform;

        CinemachineBrain currentCamera = Camera.main.GetComponent<CinemachineBrain>();
        currentCamera.ActiveVirtualCamera.OnTargetObjectWarped(playerTranform, targetPosition - playerTranform.position);

        playerTranform.position = new Vector3(
            targetPosition.x,
            targetPosition.y,
            playerTranform.position.z
            );
    }
   
}
