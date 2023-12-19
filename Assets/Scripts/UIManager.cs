using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        _pauseUI.SetActive(false);
        _deathUI.SetActive(false);
    }


    void Update()
    {
        _hpText.text = _playerHP.currentHealth.ToString();
        _ammoText.text = _pc.currentAmmo.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pc.inUI = true;
            Time.timeScale = 0;
            _hpUI.SetActive(false);
            _pauseUI.SetActive(true);
        }

    }

    public void PlayerIsDie()
    {
        _pc.inUI = true;
        Time.timeScale = 0;
        _hpUI.SetActive(false);
        _deathUI.SetActive(true);
    }

    public void Resume()
    {
        //gtfgtd
    }

    public void Quit()
    {
        //fgdsrtgdg
    }

    public void Restart()
    {
        //ffdgdsgdfg
    }

}
