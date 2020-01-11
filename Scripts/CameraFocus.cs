using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{

    public GameObject player1, player2;
    public float camZoomCoefficient = 0.35f;

    private void Update()
    {
        HandleCamera();
    }

    private void HandleCamera()
    {
        float width = player1.transform.position.x + player2.transform.position.x;
        float height = player1.transform.position.y + player2.transform.position.y;
        float CenterPositionX = width / 2;
        float CenterPositionY = height / 2;

        float widthAbs = Mathf.Abs(player1.transform.position.x - player2.transform.position.x);
        float heightAbs = Mathf.Abs(player1.transform.position.y - player2.transform.position.y);

        float zoom = -5 - (camZoomCoefficient * (widthAbs + heightAbs)); 
       
        this.transform.position = new Vector3(CenterPositionX, CenterPositionY, zoom);
    }
}
