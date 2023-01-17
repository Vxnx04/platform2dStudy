using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vini.Core.Singleton;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [Header ("Player")]
    public GameObject playerPrefab;


    [Header ("Enemies")]
    public List <GameObject> enemies;

    [Header ("References")]
    public Transform startPoint;

    private GameObject _currentPlayer;

    [Header("Animation")]
    public float duration = 1f;
    public float delay = .1f;
    public Ease ease = Ease.OutBack;


    void Start()
    {
        Init();
    }


    public void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From();
    }

}
