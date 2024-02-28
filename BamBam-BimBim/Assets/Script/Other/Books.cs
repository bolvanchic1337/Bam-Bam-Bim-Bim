using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class Books : MonoBehaviour {
    public QuestionList[] questions;
    public Text[] answersText;
    public Text qText;
    List<object> qList;
    QuestionList crntQ;
    int randQ;
    public int points;
    public float time;
    public GameObject Game;
    public Text pointText;
    public Text timeText;
    public int arcane;
    public bool play;
    private void Awake()
    {
        arcane = PlayerPrefs.GetInt("CharactersCount");
    }
    void Update(){
        pointText.text = points.ToString();
        timeText.text = time.ToString();
        if (points >= 8){
            print("You win");
            if(arcane < 1)
            {
                PlayerPrefs.SetInt("CharactersCount", 1);
            }
            else if(arcane >= 1)
            {
                print("Books");
            }
        }
        else if(time <= 0){
            play = false;
            time = 35;
            points = 0;
            Game.SetActive(false);
            }
        switch(play)
        {
            case true:
                time -= Time.deltaTime;
                break;
        }
    }
    public void OnClickPlay()
    {
        points = 0;
        qList = new List<object>(questions);
        questionGenerate();
        play = true;
    }
    public void questionGenerate()
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestionList;
            qText.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.answers);
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
        }
        else
        {
            print("Вы прошли игру");
        }
    }
        public void AnswerBttns(int index)
    {
        if (answersText[index].text.ToString() == crntQ.answers[0])
        {
            questionGenerate();
            points++;

            print("Правильный ответ");
        } 
        else if(time>= 0){
            time = 35;
            points = 0;
            Game.SetActive(false);

        }
        else{

            points = 0;
            Game.SetActive(false);
            time = 0;
            print("Неправильный ответ");
        } 
    }
    public void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.layer == LayerMask.NameToLayer("MainCharacter"))
        {
            Game.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D o)
    {
        if (o.gameObject.layer == LayerMask.NameToLayer("MainCharacter"))
        {
            Game.SetActive(false);
        }
    }
}
[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[3];
}