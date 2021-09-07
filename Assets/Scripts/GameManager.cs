using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int highScore = 0;

    public GameObject ball;

    public GameObject player1;

    public GameObject player2;

    public TextMeshProUGUI player1PointText;

    public TextMeshProUGUI player2PointText;

    public TextMeshProUGUI player1NameText;

    public TextMeshProUGUI player2NameText;

    private int player1Point = 0;

    private int player2Point = 0;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        highScore = PlayerPrefs.GetInt("score", 0);
        player1NameText.text = Menu.Instance.player1.text;
        player2NameText.text = Menu.Instance.player2.text;
        player1NameText.color = Menu.Instance.player1.color;
        player2NameText.color = Menu.Instance.player2.color;

        player1PointText.color = Menu.Instance.player1.color;
        player2PointText.color = Menu.Instance.player2.color;

        player1.GetComponent<SpriteRenderer>().color =
            Menu.Instance.player1.color;
        player2.GetComponent<SpriteRenderer>().color =
            Menu.Instance.player2.color;

        DontDestroyOnLoad (gameObject);
    }

    public void ChangePoints(int player)
    {
        if (player == 1)
        {
            player1Point++;
            player1PointText.text = player1Point.ToString();
            setHighScore (player1NameText.text, player1Point);
        }
        else
        {
            player2Point++;
            player2PointText.text = player2Point.ToString();
            setHighScore (player2NameText.text, player2Point);
        }

        ball.transform.position = new Vector2();
    }

    private void setHighScore(string name, int score)
    {
        if (highScore < score)
        {
            PlayerPrefs.SetString("name", name);
            PlayerPrefs.SetInt("score", score);
        }
    }
}
