using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject[] player;

    public bool[] playerStarted;

    public GameObject[] UIselecao, UIgridTexto, UIpersonagem, UIjogador, mask;

    public float timeToWait = 0.25f;

    public float[] time;

    public List<bool> isSelected = new List<bool>();

    public List<string> selectedCharacter = new List<string>();

    public List<string> startedCharacter = new List<string>();

    public PlayerCharacter player1, player2, player3, player4;

    private void Start()
    {
        isSelected.Add(false);
        isSelected.Add(false);
        isSelected.Add(false);
        isSelected.Add(false);

        selectedCharacter.Add("P");
        selectedCharacter.Add("P");
        selectedCharacter.Add("P");
        selectedCharacter.Add("P");

    }

    void UpdateUI(int i)
    {
        if(time[i] >= timeToWait)
        {
            if (!playerStarted[i])
            {
                time[i] = 0;
                playerStarted[i] = true;
                UIselecao[i].SetActive(false);
                UIpersonagem[i].SetActive(true);
                UIjogador[i].SetActive(true);
            }
            else
            {
                SelectCharacter(i+1.ToString() + "P", i);
                UIpersonagem[i].SetActive(true);
                UIjogador[i].SetActive(true);
                mask[i].SetActive(true);

            }
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        time[0] += Time.deltaTime;
        time[1] += Time.deltaTime;
        time[2] += Time.deltaTime;
        time[3] += Time.deltaTime;
        if (Input.GetAxisRaw("Jump1") != 0 && !isSelected[0])
        {
            UpdateUI(0);
        }

        if (Input.GetAxisRaw("Jump2") != 0 && !isSelected[1])
        {
            UpdateUI(1);
        }

        if (Input.GetAxisRaw("Jump3") != 0 && !isSelected[2])
        {
            UpdateUI(2);
        }

        if (Input.GetAxisRaw("Jump4") != 0 && !isSelected[3])
        {
            UpdateUI(3);
        }


        if(Input.GetKeyDown("t"))
        {
            Ready();
        }
        if(Input.GetKeyDown("r"))
        {
            Reset();
        }
    }

    public void SelectCharacter(string input, int i)
    {
        selectedCharacter[i] = input;
        isSelected[i] = true;

    }

    public void Ready()
    {
        bool anyTrue = isSelected.Any(valor => true);

        if(!anyTrue)
        {
            return;
        }

        int index = 1;

        foreach(bool selecao in isSelected)
        {
            if(selecao == true)
            {
                startedCharacter.Add(index.ToString());
            } 
            index++;
        }
        SceneManager.LoadScene("MiniGame1");
    }

    public void Reset()
    {
        SceneManager.LoadScene("Reset");
    }
}
