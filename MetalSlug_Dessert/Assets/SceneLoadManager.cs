using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoadManager : MonoBehaviour
{
    private Animator animator;
    private GameObject canvasInitials;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) loadScene();
    }

    public void loadScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex +1;
        StartCoroutine(SceneLoad(nextSceneIndex));
    }

    public IEnumerator SceneLoad(int sceneIndex)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
    }


}
