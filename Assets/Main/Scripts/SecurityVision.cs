using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityVision : MonoBehaviour {

    GameManager GM;

    void Awake() {

        GM = GameManager.Instance;
        GM.OnStateChange += HandleOnStateChange;

        Debug.Log("Current game state when Awakes: " + GM.gameState);

    }

    void Start()
    {
        Debug.Log("Current game state when Starts: " + GM.gameState);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GM.SecurityCollisionDetected(collider);
        }
        
    }

    public void HandleOnStateChange()
    {
        
    }


}
