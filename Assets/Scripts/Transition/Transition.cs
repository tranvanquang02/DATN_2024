using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TransitionType
{
    Warp,
    Sence
}
public class Transition : MonoBehaviour
{
    [SerializeField] TransitionType transitionType;
    [SerializeField] string sceneNameToTransition;
    [SerializeField] Vector3 targetPositon;

    Transform destination;

    
    void Start()
    {
        destination = transform.GetChild(1);
    }
    internal void InitTransition(Transform toTransition)
    {
        
        switch (transitionType)
        {
            case TransitionType.Warp:
                Cinemachine.CinemachineBrain currentCamera = Camera.main.GetComponent<CinemachineBrain>();

                currentCamera.ActiveVirtualCamera.OnTargetObjectWarped(toTransition,
            destination.position - toTransition.position);
                toTransition.position = new Vector3(
                                  destination.position.x,
                                  destination.position.y,
                                  destination.position.z);
                break;
            case TransitionType.Sence:
                GameSceneManager.Instance.InitSwitchSence(sceneNameToTransition, targetPositon);
                break;
        }
    }

}
