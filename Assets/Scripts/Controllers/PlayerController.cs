using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerPawn))]
public abstract class PlayerController : Controller
{
    protected PlayerPawn playerPawn;

    // Start is called before the first frame update
    protected override void Start()
    {
        //add itself to list of players
        GameManager.instance.players.Add(this);

        playerPawn = GetComponent<PlayerPawn>();
        pawn = playerPawn;
    }
    protected override void OnDestroy()
    {
        //remove itself from list of players
        GameManager.instance.players.Remove(this);
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(playerPawn != null)
        {
            ProcessInputs();
        }
    }

    protected abstract void ProcessInputs();
}
