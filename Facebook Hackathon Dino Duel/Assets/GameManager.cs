using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    public AmbientManager ambientManager;
    public bool gameOver = false;
    public TextMeshPro winnerText;
    public TurnBasedManager turnBasedManager;
    public void GameOver(GameObject loser)
    {
        gameOver = true;
        winnerText.gameObject.SetActive(true);
        GameObject winner = turnBasedManager.player1.gameObject;
        winnerText.text = "Winner is Player 1!";
        if(loser == winner)
        {
            ambientManager.PlayLose();
            winnerText.text = "Winner is Player 2!";
            winner = turnBasedManager.player2.gameObject;
        }
        else
        {

            ambientManager.PlayWin();
        }
        StartCoroutine(RestartCoroutine());
    }

    IEnumerator RestartCoroutine()
    {
        yield return new WaitForSeconds(7f);
        Restart();
    }
    // Start is called before the first frame update
    void Start()
    {
        winnerText.gameObject.SetActive(false);
        ambientManager = FindObjectOfType<AmbientManager>();
    }

    public void Restart()
    {
        gameOver = false;
        winnerText.gameObject.SetActive(false);

        turnBasedManager.Restart();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }
}
