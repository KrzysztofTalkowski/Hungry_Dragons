using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;
    private static int _nextLevelIndex = 1;
    public GameObject EndScreen;
    public float seconds = 5f;

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(seconds);

        EndScreen.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    void Update()
    {
        


        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null)
                return;
        }

        Debug.Log("You killed all enemies");
        StartCoroutine(LateCall());

        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;

        SceneManager.LoadScene(nextLevelName);

    }
}
