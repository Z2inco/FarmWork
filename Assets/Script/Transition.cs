using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TransitionType
{
    Warp,
    Scene
}

public class Transition : MonoBehaviour
{
    [SerializeField] TransitionType transitionType;
    [SerializeField] string sceneNameToTransition;
    [SerializeField] Vector3 targetPosition;

    Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.GetChild(1);
    }

    //将玩家移动到目的地
    internal void InitiateTransition(Transform toTransition)
    {
        //消除摄像机滑动效果

        switch (transitionType)
        {
            case TransitionType.Warp:
                Cinemachine.CinemachineBrain currentCamera = Camera.main.GetComponent<Cinemachine.CinemachineBrain>();
                currentCamera.ActiveVirtualCamera.OnTargetObjectWarped(toTransition, destination.position - toTransition.position);

                toTransition.position = new Vector3(
                    destination.position.x, 
                    destination.position.y, 
                    toTransition.position.z
                    );//将目标位置赋给角色,并保持角色z层
                break;
            case TransitionType.Scene:
                GameSceneManager.instance.InitSwitchScene(sceneNameToTransition, targetPosition);
                break;
        } 
       
    }
}
