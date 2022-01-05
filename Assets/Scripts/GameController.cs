using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int whoesTurn; //0 ==x , 1 == o
    public int turnCount; //    couts the number of tur played
    public GameObject[] turnIcons; //displays whoes turn is it
    public Sprite[] playIcons; // 0=x icons & 1=y  icon
    public Button[] ticktacktoeSpaces; // 0=x icons & 1=o  icon
    public int[] markedSpaces; //ids which spaces marked by which palyer
    public Text winnerText;
    public GameObject[] winningLine; //hold the cross lines
    public GameObject winnerPanel;
    public int xScore;
    public int oScore;
    public Text xScoreText;
    public Text oScoreText;
    public GameObject catImage;



    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }
    void GameSetup()
    {
        whoesTurn = 0;
        turnCount = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for (int i = 0; i < ticktacktoeSpaces.Length; i++)
        {
            ticktacktoeSpaces[i].interactable = true;
            ticktacktoeSpaces[i].GetComponent<Image>().sprite = null;
        }

        for (int i = 0; i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void TicTacToeButton(int whichNumber)
    {
        ticktacktoeSpaces[whichNumber].image.sprite = playIcons[whoesTurn];
        ticktacktoeSpaces[whichNumber].interactable = false;

        markedSpaces[whichNumber] = whoesTurn + 1;
        turnCount++;
        if (turnCount > 4)
        {
            bool isWinner = WinnerCheck();
            if (turnCount == 9 && isWinner == false)
            {
                Cat();
                SoundManagerScript.PlaySound("draw");
            }

        }
        if (whoesTurn == 0)
        {
            SoundManagerScript.PlaySound("turn");
            whoesTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else
        {
            SoundManagerScript.PlaySound("xturn");
            whoesTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }


    bool WinnerCheck()
    {
        //8 posible solutions
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        int s7 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];
        int s8 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];

        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };

        for (int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 3 * (whoesTurn + 1))
            {
                // Debug.Log("Player "+whoesTurn+ " won!");
                WinnerDisplay(i);
                return true;
            }
        }
        return false;
    }




    void WinnerDisplay(int indexIn)
    {
        winnerPanel.gameObject.SetActive(true);
        SoundManagerScript.PlaySound("win");
        if (whoesTurn == 0)
        {
            xScore++;
            xScoreText.text = xScore.ToString();
            winnerText.text = "Player X Wins!";
        }
        else
        {
            oScore++;
            oScoreText.text = oScore.ToString();
            winnerText.text = "Player O Wins!";
        }
        winningLine[indexIn].SetActive(true);
        // for (int i = 0; i < ticktacktoeSpaces.Length ; i++)
        // {
        //     ticktacktoeSpaces[i].interactable = false;
        // } //to avoid white disabled buttons
    }

    public void Rematch()
    {
        GameSetup();
        for (int i = 0; i < winningLine.Length; i++)
        {
            winningLine[i].SetActive(false);
        }
        winnerPanel.SetActive(false);
        catImage.SetActive(false);

    }

    public void Restart()
    {
        Rematch();
        xScore = 0;
        oScore = 0;

        xScoreText.text = "0";
        oScoreText.text = "0";
    }


    void Cat()
    {
        winnerPanel.SetActive(true);
        catImage.SetActive(true);
        winnerText.text = "Its a draw..";
    }
}
