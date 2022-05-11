using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : singleton<sceneController>
{
    GameObject player;
    public void TransitionToDestination(transitionPoint _transitionPoint)
    {
        switch (_transitionPoint.transitionType)
        {
            case transitionPoint.TransitionType.SameScene:
                StartCoroutine(Transition(SceneManager.GetActiveScene().name, _transitionPoint.destinationTag));
                break;
            case transitionPoint.TransitionType.DifferentScene:
                break;
            default:
                break;
        }
    }
    IEnumerator Transition(string sceneName, transitionDestination.DestinationTag destinationTag)
    {
        //player = GameManager.Instance.playerStats.gameObject;
        player.transform.SetPositionAndRotation(GetDestination(destinationTag).transform.position, GetDestination(destinationTag).transform.rotation);
        return null;
    }
    public transitionDestination GetDestination(transitionDestination.DestinationTag destinationTag)
    {
        var entrances = FindObjectsOfType<transitionDestination>();
        for(int i=0; i< entrances.Length;i++)
        {
            if (entrances[i].destinationTag == destinationTag)
                return entrances[i];
        }
        return null;
    }
}
