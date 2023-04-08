using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinnishLine : MonoBehaviour
{
    [Tooltip("The delay time before load next scene")] [SerializeField] private float m_loadDelay;
    [Tooltip("The Effect when play cross finnish line")] [SerializeField] private ParticleSystem m_finishEffect;

    private Scene _scene;

    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", m_loadDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadSceneAsync(_scene.name);
    }
}
