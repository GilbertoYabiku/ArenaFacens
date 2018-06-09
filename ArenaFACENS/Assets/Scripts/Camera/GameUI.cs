using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public CameraBehaviours cam;
    public Text playerName, playerScore, playerHunger;
    public GameObject panel;
    Transform currentPlayer;

    private void Update()
    {
        if (cam.IsTracking && cam.Target != currentPlayer)
        {
            panel.SetActive(true);
            UpdatePanel();
        }
        if (!cam.IsTracking)
        {
            panel.SetActive(false);
        }
    }

    void UpdatePanel()
    {
        CharacterBehaviours player = cam.Target.GetComponent<CharacterBehaviours>();
        playerName.text = player.name;
        playerScore.text = "Score: " + player.Score.ToString();
        playerHunger.text = "Energy: " + player.Energy.ToString();
    }
}
