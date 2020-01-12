using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JukeBoxManager : MonoBehaviour
{

    public AudioSource tankBorn, tankStart, mainSong, loserSong, winnerSong;

    private AudioSource tank;
    private int songCode = 0;


    // Update is called once per frame
    void Update()
    {
        switch (songCode)
        {
            case 0:
                tank = Instantiate(tankBorn);
                tank.Play();
                songCode = 1;
                break;
            case 1:
                if (tank.isPlaying) break;
                Destroy(tank.gameObject);
                tank = Instantiate(tankStart);
                tank.Play();
                songCode = 2;
                break;
            case 2:
                if (tank.isPlaying) break;
                Destroy(tank.gameObject);
                tank = Instantiate(mainSong);
                tank.Play();
                tank.loop = false;
                songCode = 3;
                break;
            case 3:
                if (tank.isPlaying) break;
                Destroy(tank.gameObject);
                tank = Instantiate(loserSong);
                tank.Play();
                songCode = 4;
                break;
            case 4:
                if (tank.isPlaying) break;
                Destroy(tank.gameObject);
                tank = Instantiate(winnerSong);
                tank.Play();
                break;
        }
      
    }
}
