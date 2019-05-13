﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CamerState
{
    public enum TriggerType { Position,Object}
    public TriggerType triggerType;

    public float speed;
    public Vector3 direction;
    public Vector3 triggerPosition;
    public GameObject triggerObject;

}

public class CameraMove : MonoBehaviour
{
    public float baseSpeed=1f;
    public Vector3 initMoveDirection = Vector3.right;

    public float speed;
    public Vector3 moveDirection = Vector3.right;

    public CamerState[] camerStates;
    private int currentStateIdx=0;

    // Start is called before the first frame update
    void Start()
    {
        SetSpeed(baseSpeed);
        setMoveDirection(initMoveDirection);
    }

    // Update is called once per frame
    void Update()
    {
        CamerState currentState = camerStates[currentStateIdx];

        if (currentState.triggerType == CamerState.TriggerType.Object)
        {
            if(currentState.triggerObject == null)
            {
                Debug.Log("CheckPoint");
                SetSpeed(currentState.speed);
                setMoveDirection(currentState.direction);
                currentStateIdx++;
            }

            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
        else
        {
            if (Mathf.Abs(transform.position.x - currentState.triggerPosition.x) < 0.1f&&Mathf.Abs(transform.position.y - currentState.triggerPosition.y)<0.1f)
            {
                Debug.Log("CheckPoint");
                SetSpeed(currentState.speed);
                setMoveDirection(currentState.direction);
                currentStateIdx++;
            }

            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }

    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void setMoveDirection(Vector3 newDirection)
    {
        moveDirection = newDirection.normalized;
    }

    private void OnDrawGizmos()
    {
        for(int i =0; i<camerStates.Length; i++)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(camerStates[i].triggerPosition, Vector3.one * 1);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(camerStates[i].triggerPosition, camerStates[i].direction + camerStates[i].direction * camerStates[i].speed);

        }
    }
}
