using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller {

    public Transform startPoint;
    public GameObject playerPrefab;
    public GameManager gameManager;


    public override void InstallBindings() {
        BindGameManager();
        BindPlayer();
        BindPlayerController();
    }

    private void BindPlayerController() {
        Container.Bind<PlayerController>().FromComponentInHierarchy().AsSingle();
    }


    private void BindGameManager() {
        Container.Bind<GameManager>().FromInstance(gameManager).AsSingle();
    }

    private void BindPlayer() {
        Player player = Container.InstantiatePrefabForComponent<Player>(playerPrefab, startPoint.position, Quaternion.identity, null);
        Container.Bind<Player>().FromInstance(player).AsSingle();
    }
}
