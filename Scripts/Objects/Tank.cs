using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private bool isInvincible = false;
    private float invincibleTimer = 0f;
    private const float maxInvincibleTimer = 3f;

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
    }

}
