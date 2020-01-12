using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button Play, Quit, Credit, HowToPlay, BackToMenuPlay, BackToMenuCredit;
    public GameObject PanelCode1, PanelCode2, PanelCode3;

    private int code = 1;
    private GameObject[] panels = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        HowToPlay.onClick.AddListener(() => ChangePanel(2));
        BackToMenuPlay.onClick.AddListener(() => ChangePanel(1));
        BackToMenuCredit.onClick.AddListener(() => ChangePanel(1));
        Play.onClick.AddListener(PlayGame);
        Credit.onClick.AddListener(() => ChangePanel(3));
        Quit.onClick.AddListener(EndApplication);

        panels[0] = PanelCode1;
        panels[1] = PanelCode2;
        panels[2] = PanelCode3;
    }

    void ChangePanel(int Code)
    {
        panels[code - 1].SetActive(false);
        code = Code;
        for(int i = 0; i < panels.Length; i++){
            if (i + 1 == Code) panels[i].SetActive(true);
            else panels[i].SetActive(false);
        }
    }

    void EndApplication()
    {
        Application.Quit();
    }

    void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
