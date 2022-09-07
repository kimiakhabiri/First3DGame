using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource finishSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            finishSound.Play();
            Invoke(nameof(ReloadLevel), 1.3f);
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
