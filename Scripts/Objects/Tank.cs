using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private bool isInvincible = false;
    private float invincibleTimer = 0f;
    private const float maxInvincibleTimer = 3f;
    private int numLife = 3;
    private bool hasFell = false;

    private const float fallTime = 1.5f;
    private float fallTimer = 0f;

    public void setAsFall(bool _hasFell)
    {
        this.hasFell = _hasFell;
    }
    public bool getHasFell()
    {
        return this.hasFell;
    }

    public int getLife()
    {
        return this.numLife;
    }
    public void decreaseLife()
    {
        this.numLife--;
    }
    public bool isDead()
    {
        return numLife <= 0;
    }

    public bool getInvincible()
    {
        return this.isInvincible;
    }

    public void setInvincible(bool _invincible)
    {
        this.isInvincible = _invincible;
    }

    public void resetInvincTimer()
    {
        this.invincibleTimer = 0f;
    }

    public void runInvincTimer()
    {
        this.invincibleTimer += Time.deltaTime;
    }

    public float getInvincTimer()
    {
        return this.invincibleTimer;
    }

    public void resetFallTimer()
    {
        this.fallTimer = 0f;
    }

    public void runFallTimer()
    {
        this.fallTimer += Time.deltaTime;
    }

    public float getFallTimer()
    {
        return this.fallTimer;
    }

    public float getFallTime()
    {
        return this.fallTimer;
    }

    private void Update()
    {
        if (isInvincible)
        {
            this.runInvincTimer();
            if(invincibleTimer > maxInvincibleTimer)
            {
                this.resetInvincTimer();
                isInvincible = false;
            }
        }

        //Debug.Log(this.gameObject);
        //if(hasFell && numLife > 0)
        //{
        //    //Debug.Log("Hello");
        //    this.runFallTimer();
        //    if(fallTimer > fallTime)
        //    {
        //        this.resetFallTimer();
        //        hasFell = false;

        //        // Sets new position for the fallen player
        //        this.transform.position = new Vector3(Random.Range(-11f, -9f), Random.Range(-5f, 5f), 0);
        //        this.gameObject.SetActive(true);
        //    }
        //}
    }

}
