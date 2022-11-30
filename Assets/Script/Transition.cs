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

    //������ƶ���Ŀ�ĵ�
    internal void InitiateTransition(Transform toTransition)
    {
        //�������������Ч��

        switch (transitionType)
        {
            case TransitionType.Warp:
                Cinemachine.CinemachineBrain currentCamera = Camera.main.GetComponent<Cinemachine.CinemachineBrain>();
                currentCamera.ActiveVirtualCamera.OnTargetObjectWarped(toTransition, destination.position - toTransition.position);

                toTransition.position = new Vector3(
                    destination.position.x, 
                    destination.position.y, 
                    toTransition.position.z
                    );//��Ŀ��λ�ø�����ɫ,�����ֽ�ɫz��
                break;
            case TransitionType.Scene:
                GameSceneManager.instance.InitSwitchScene(sceneNameToTransition, targetPosition);
                break;
        } 
       
    }
}
