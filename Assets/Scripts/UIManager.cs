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
    public GameObject _pauseUI;
    public GameObject _deathUI;

    public void Start()
    {
        Debug.Log("_playerHP");
        _pauseUI.SetActive(false);
        _deathUI.SetActive(false);
    }

    private void Update()
    {
        _hpText.text = _playerHP.currentHealth.ToString();
        _ammoText.text = _pc.currentAmmo.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseUI.active)
            {
                _pc.inUI = true;
                Time.timeScale = 1;
                _hpUI.SetActive(true);
                _pauseUI.SetActive(false);
            }
            else
            {
                _pc.inUI = false;
                Time.timeScale = 0;
                _hpUI.SetActive(false);
                _pauseUI.SetActive(true);
            }
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
}