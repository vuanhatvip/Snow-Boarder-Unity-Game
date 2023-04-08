using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [Tooltip("The delay time before reload the current scene")] [SerializeField] private float m_loadDelay;
    [Tooltip("The Effect when player crash")] [SerializeField] private ParticleSystem m_crashEffect;
    [Tooltip("Crash Sound Effect")] [SerializeField] private AudioClip m_crashSFX;

    private Scene _scene;
    private bool _hasCrashed = false;

    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !_hasCrashed)
        {
            _hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControl();
            m_crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(m_crashSFX);
            Invoke("ReloadScene", m_loadDelay); 
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadSceneAsync(_scene.buildIndex);
    }
}
