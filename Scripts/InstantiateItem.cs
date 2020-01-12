using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateItem : MonoBehaviour
{
    private int primarySelector;
    private float primaryTime;
    private float primaryTimer = 0f;


    private int secondarySelector;
    private float secondaryTime;
    private float secondaryTimer = 0f;

    public GameObject shieldPrefab;

    void resetPrimary()
    {
        primarySelector = Random.Range(0, 0);
        //primaryTime = Random.Range(15f, 30f);
        primaryTime = Random.Range(15f, 30f);
        primaryTimer = 0f;
    }

    void resetSecondary()
    {
        secondarySelector = Random.Range(0, 0);
        //secondaryTime = Random.Range(15f, 30f);
        secondaryTime = Random.Range(15f, 30f);
        secondaryTimer = 0f;
    }

    void Start()
    {
        resetPrimary();
        resetSecondary();
    }

    // Update is called once per frame
    void Update()
    {
        primaryUpdate();
        secondaryUpdate();
    }

    void primaryUpdate()
    {
        // Keep running the timer until it reaches the item drop-off time
        if (primaryTimer < primaryTime)
        {
            primaryTimer += Time.deltaTime;
        }
        else
        {
            // Instantiates item
            pickASide(1, primarySelector);

            resetPrimary();
        }
    }

    void secondaryUpdate()
    {
        if(secondaryTimer < secondaryTime)
        {
            secondaryTimer += Time.deltaTime;
        }
        else
        {
            pickASide(2, secondarySelector);


            // prepares again to prepare another item
            resetSecondary();
        }
    }

    void pickASide(int player, int item)
    {
        switch(player)
        {
            case 1:
                Vector2 newLocation1 = new Vector2(Random.Range(-3f, -1f), Random.Range(-5f, 5f));
                pickAnItem(item, newLocation1);
                break;
            case 2:
                Vector2 newLocation2 = new Vector2(Random.Range(1f, 3f), Random.Range(-5f, 5f));
                pickAnItem(item, newLocation2);
                break;
        }
    }

    void pickAnItem(int item, Vector2 newLocation)
    {
        switch (item)
        {
            // Shield
            case 0:
                GameObject Shield = Instantiate(shieldPrefab,
                                         newLocation,
                                         Quaternion.Euler(0, 0, 0));
                Shield.tag = "Shield";
                break;
        }
    }
}
