using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraConfiner : MonoBehaviour
{
    [SerializeField] CinemachineConfiner confiner;
    void Start()
    {
        UpdateBound();
    }
    public void UpdateBound()
    {
        GameObject go = GameObject.Find("CameraConfiner");
        if(go == null)
        {
            confiner.m_BoundingShape2D = null;
            return;
        }
        Collider2D bounds = go.GetComponent<Collider2D>();
        confiner.m_BoundingShape2D = bounds;
    }
}
