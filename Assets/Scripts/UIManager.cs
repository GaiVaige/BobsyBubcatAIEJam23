using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //references
    [Header("Reference Stuff")]
    public Health _playerHP;

    public Player _pc;
    public TextMeshProUGUI _hpText;
    public TextMeshProUGUI _ammoText;
    public GameObject _hpUI;
    public GameObject _creditsUI;
    public GameObject _pauseUI;
    public GameObject _deathUI;

    public void Start()
    {
        _playerHP = _pc.GetComponent<Health>();
        Debug.Log("_playerHP");
        _creditsUI.SetActive(false);
        _pauseUI.SetActive(false);
        _deathUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Resume();
        }
        _hpText.text = _playerHP.currentHealth.ToString();
        _ammoText.text = _pc.currentAmmo.ToString();

    }
    public void Resume()
    {
        if (_pauseUI.active)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _pc.inUI = false;
            Time.timeScale = 1;
            _hpUI.SetActive(true);
            _pauseUI.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            _pc.inUI = true;
            Time.timeScale = 0;
            _hpUI.SetActive(false);
            _pauseUI.SetActive(true);
        }
    }

    public void PlayerIsDie()
    {
        _pc.inUI = true;
        _hpUI.SetActive(false);
        _deathUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Application.LoadLevel("Test");
    }

    public void Credits()
    {
        if(_creditsUI.active)
        {
            _pauseUI.SetActive(true);
            _creditsUI.SetActive(false);
        }
        else
        {
            _pauseUI.SetActive(false);
            _creditsUI.SetActive(true);
        }
    }
}