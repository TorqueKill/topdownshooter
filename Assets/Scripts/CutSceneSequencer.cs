using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Playables;

public class CutSceneSequencer : MonoBehaviour
{
    // Assume that the director is already assigned if this script is attached to the same GameObject
    public PlayableDirector director;

    void Start()
    {
        // Start the coroutine to load the scene after the timeline has finished playing
        StartCoroutine(LoadSceneAfterTimeline());
    }

    private IEnumerator LoadSceneAfterTimeline()
    {
        // Wait for the timeline to finish playing
        yield return new WaitUntil(() => director.state != PlayState.Playing);

        // Load your desired scene here
        SceneManager.LoadScene("StartScene");
    }
}

