using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GMPlayerController : MonoBehaviour
{
    public static GMPlayerController instance;

    [SerializeField]
    GMPlayer mPlayer;
    [SerializeField]
    UnityEvent<int> increaseBananas;
    [SerializeField]
    UnityEvent<float> showDificultyFactor;
    [SerializeField]
    UnityEvent toDoWhenDead;
    [SerializeField]
    UnityEvent toDoWhenNotDead;
    [SerializeField]
    UnityEvent<float> chageGravity;
    [SerializeField]
    UnityEvent<string> showMessage;
    [SerializeField]
    UnityEvent<int> editLife;
    [SerializeField]
    UnityEvent resetDash;

    int currentLife = 0;
    public static event Action<int> increaseBabanaInject;


    List<float> lastGravity = new();
    float lastJumpForce = 0;
    int increaser = 0;
    private void Awake()
    {
        instance = this;
        mPlayer = Instantiate(mPlayer);
        currentLife = mPlayer.life;
        editLife?.Invoke(currentLife);
    }
    public void IncreaseBananaCounter(int banana)
    {
        mPlayer.bananasCounter += banana + increaser;
        increaseBananas?.Invoke(mPlayer.bananasCounter);
        increaseBabanaInject?.Invoke(mPlayer.bananasCounter);
    }

    public void ShowDificultyFactor()
    {
        showDificultyFactor?.Invoke(mPlayer.dificultyFactor);
    }
    public GMPlayer GMPlayer {  get { return mPlayer;} }
    public void ChangeDownGravity(float newGravity)
    {
        lastGravity.Add(mPlayer.gravityDown);
        //mPlayer.gravityDown = newGravity;
        chageGravity?.Invoke(newGravity);
        Debug.Log("Gravity A" + lastGravity.Count);
    }

    public void ReturnLastGravity()
    {
        if(lastGravity.Count > 0) {
            Debug.Log("Gravity R " + lastGravity.Count);
            chageGravity?.Invoke(lastGravity[lastGravity.Count - 1]);
            lastGravity.RemoveAt(lastGravity.Count - 1);
        }

    }

    public void GetDamage(float damage)
    {
        currentLife -= Mathf.CeilToInt(damage);
        editLife?.Invoke(currentLife);
        if (currentLife <= 0)
        {
            toDoWhenDead?.Invoke();
        }
        else
        {
            toDoWhenNotDead?.Invoke();
        }
    }

    public void ShowMessage(string message)
    {
        showMessage?.Invoke(message);
    }

    public void ChangeJumpForce(float newJumpForce)
    {
        lastJumpForce = mPlayer.jumpForce;
        mPlayer.jumpForce = newJumpForce;
    } 
    public void ReturnLastJumpForce()
    {
        mPlayer.jumpForce = lastJumpForce;
    }

    public int INCREASER
    {
        set { increaser = value; }
    }

    public void AddLife(int life)
    {
        currentLife += life;
        editLife?.Invoke(currentLife);
    }

    public void ResetDash()
    {
        Debug.Log("I reser the dash ");
        resetDash?.Invoke();
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
