using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GMBackgroundSpeedDificultyManager : MonoBehaviour
{
    [SerializeField]
    UnityEvent<float> toDo;
    [SerializeField]
    UnityEvent<float> showCurrentDificulty;
    float currentSpeed = 0;
    List<float> lastSpeeds = new();
    bool waitToIncreaseSpeed = false;

    public static event Action increaseDificulty;
    private void OnEnable()
    {
        GameManager.SetUpDificulty += SetUpSpeed;
    }

    public void ChangeSpeed(float newSpeed)
    {
        lastSpeeds.Add(currentSpeed);
        toDo?.Invoke(newSpeed);
        currentSpeed = newSpeed;
        Debug.Log("Speed " + currentSpeed);
    } 

    public void ChangeSpeedFactor(float factor)
    {
        lastSpeeds.Add(currentSpeed);
        currentSpeed *= factor;
        toDo?.Invoke(currentSpeed);
    }

    private void SetUpSpeed(GMDificulty gMDificulty)
    {
        Debug.Log("I get here " + gMDificulty.BackgroundSpeed);
        lastSpeeds.Add(gMDificulty.BackgroundSpeed);
        toDo?.Invoke(gMDificulty.BackgroundSpeed);
        currentSpeed = gMDificulty.BackgroundSpeed;
    }

    public void ReturnToLastSpeed()
    {
        if (lastSpeeds.Count > 0)
        {
            int bigger = lastSpeeds.IndexOf(lastSpeeds.OrderBy(e => e).Last());
            currentSpeed = lastSpeeds[bigger];

            lastSpeeds.RemoveAt(bigger);
            toDo?.Invoke(currentSpeed);
        }
    }
    private void OnDisable()
    {
        GameManager.SetUpDificulty -= SetUpSpeed;
    }

    public void ShowCurrentDificulty()
    {
        showCurrentDificulty?.Invoke(GameManager.instance.GAMEDIFICULTY.dificultyFactor);
    }

    public void StartIncreaseDificulty()
    {
        StartCoroutine(IncreaseSpeed());
    }

    IEnumerator IncreaseSpeed()
    {
        //GameManager.instance.GAMEDIFICULTY.dificultyFactor = 0;
        while (true) {
            yield return new WaitForSeconds(5f);
            while (waitToIncreaseSpeed)
                yield return null;

            //GameManager.instance.GAMEDIFICULTY.dificultyFactor = Mathf.Clamp(GameManager.instance.GAMEDIFICULTY.dificultyFactor += Time.deltaTime, 0, 1);
            increaseDificulty?.Invoke();
            ChangeSpeed(Mathf.Clamp(currentSpeed * (1 + GameManager.instance.GAMEDIFICULTY.dificultyFactor),0,800));
        }
    }

    public bool WAITTOINCREASESPEED
    {
        set { waitToIncreaseSpeed = value; }
    }
}
