using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI player1;

    public TextMeshProUGUI player2;

    public InputField editPlayer1;

    public InputField editPlayer2;

    public TextMeshProUGUI highScore;

    private static Menu _instance;

    public static Menu Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Menu>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad (gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore.text =
            PlayerPrefs.GetString("name", "...") +
            " : " +
            (PlayerPrefs.GetInt("score", 0)).ToString();

        editPlayer1.characterLimit = 10;
        editPlayer2.characterLimit = 10;
        editPlayer1
            .onValueChanged
            .AddListener((name) =>
            {
                UpdateInputField(name, 1);
            });
        editPlayer2
            .onValueChanged
            .AddListener((name) =>
            {
                UpdateInputField(name, 2);
            });
    }

    // Update is called once per frame
    void Update()
    {
    }

    void UpdateInputField(string name, int player)
    {
        if (player == 1)
        {
            if (name.Length == 0)
            {
                player1.text = "Player 1";
            }
            else
            {
                player1.text = name;
            }
        }
        else
        {
            if (name.Length == 0)
            {
                player2.text = "Player 2";
            }
            else
            {
                player2.text = name;
            }
        }
    }

    public void changeColor(Color color, int player)
    {
        if (player == 1)
        {
            player1.color = color;
        }
        else
        {
            player2.color = color;
        }
    }

    void Destroy()
    {
        editPlayer1
            .onValueChanged
            .RemoveListener((name) =>
            {
                UpdateInputField(name, 1);
            });
        editPlayer2
            .onValueChanged
            .RemoveListener((name) =>
            {
                UpdateInputField(name, 2);
            });
    }

    public void init()
    {
        SceneManager.LoadScene("Pong", LoadSceneMode.Single);
    }

    public void clear()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "...";
    }
}
