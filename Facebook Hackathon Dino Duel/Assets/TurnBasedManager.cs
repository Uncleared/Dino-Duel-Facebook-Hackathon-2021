using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class TurnBasedManager : MonoBehaviour
{
    public GameObject hintGuide;
    AmbientManager ambientManager;
    public GameObject pokeball1;
    public GameObject pokeball2;
    public GameObject dinoLogo;
    public GameObject spawnParticlesPrefab;
    GameManager gameManager;
    public TurnBasedController player1;
    public TurnBasedController player2;
    // either you or me

    [SerializeField]
    int turn = -1;

    public void SpawnPokemon()
    {
        turn = -1;

        dinoLogo.SetActive(false);
        hintGuide.SetActive(false);
        StartCoroutine(SpawnPokemonCoroutine());
       
        player1.Init(this, player2);
        player2.Init(this, player1);
        NextTurn(null);
    }

    
    IEnumerator SpawnPokemonCoroutine()
    {
        GameObject spawnP1 = Instantiate(spawnParticlesPrefab, player1.transform.position, Quaternion.identity);
        player1.transform.gameObject.SetActive(true);
        player1.transform.Find("ModelRoot").transform.localScale = Vector3.zero;
        player1.transform.Find("ModelRoot").transform.DOScale(Vector3.one, 0.45f).SetEase(Ease.InElastic);

        yield return new WaitForSeconds(0.2f);
        GameObject spawnP2 = Instantiate(spawnParticlesPrefab, player2.transform.position, Quaternion.identity);

        player2.transform.Find("ModelRoot").transform.localScale = Vector3.zero;
        player2.transform.Find("ModelRoot").transform.DOScale(Vector3.one, 0.45f).SetEase(Ease.InElastic);
        player2.transform.gameObject.SetActive(true);
        ambientManager.PlayBattle();
    }
    // Start is called before the first frame update
    void Awake()
    {
        ambientManager = FindObjectOfType<AmbientManager>();
        gameManager = FindObjectOfType<GameManager>();
        Restart();
    }

    public void Restart()
    {
        ambientManager.PlayIdle();
        pokeball1.SetActive(true);
        pokeball2.SetActive(true);
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        dinoLogo.SetActive(true);
        hintGuide.SetActive(true);
        player1.Revive();
        player2.Revive();
    }
    public void NextTurn(TurnBasedController currentController)
    {
        if(gameManager.gameOver)
        {
            return;
        }
        print("next turn");

        turn++;
        if(currentController != null)
        {
            currentController.DeactivateTurn();
        }
        if(turn % 2 == 0)
        {
            player1.SelectTurn();
        }
        else
        {
            player2.SelectTurn();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
