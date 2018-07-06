using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMrg : MonoBehaviour {
    private NPCMrg(){}
    public static NPCMrg instance;
    private Dictionary<string, GameActor> actorDic = new Dictionary<string, GameActor>();
    [HideInInspector]
    public GameActor player;
    private void Awake()
    {
        instance = this;
    }
    public void Regist(GameActor actor)
    {
        actorDic.Add(actor.name, actor);
    }
}
