using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quizgame : MonoBehaviour
{

    public QuestionList[] questions;
    public Text[] answersText;
    public Text qText;
    public GameObject headPanel;
    public Button[] answerBttns = new Button[3];
    public Sprite[] TFIcons = new Sprite[2];
    public Image TFIcon;
    public Text TFText;
    int countbonus = 0;
    public Text cnttext;
    public GameObject nextt;
    
    


    List<object> qList;
    QuestionList crntQ;
    int randQ;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    

    public void OnClickPlay()
    {
        qList = new List<object>(questions);
        questionGenerate();
        if (!headPanel.GetComponent<Animator>().enabled) headPanel.GetComponent<Animator>().enabled = true;
        else headPanel.GetComponent<Animator>().SetTrigger("In");
    }
    //public void Next()
    //{
     //   if (countbonus >= 3)
     //   {
     //       nextt.SetActive(true); 
     //   }

        
    //}

    void questionGenerate()
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestionList;
            qText.text = crntQ.question;
            qText.gameObject.GetComponent<Animator>().SetTrigger("In");
            List<string> answers = new List<string>(crntQ.answers);
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
            StartCoroutine(animBttns());
            //answersText[i].text = crntQ.answers[i];
            //qText.text = questions[Random.Range(0, questions.Length)].question;
        }
        else
        {
            print("Вы прошли игру");
            headPanel.GetComponent<Animator>().SetTrigger("Out");
        }
    }

    IEnumerator animBttns()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = false;
        int a = 0;
        while (a < answerBttns.Length)
        {
            if (!answerBttns[a].gameObject.activeSelf) answerBttns[a].gameObject.SetActive(true);
            else answerBttns[a].gameObject.GetComponent<Animator>().SetTrigger("In");
            a++;
            yield return new WaitForSeconds(1);
        }
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = true;
        yield break;
    }

    IEnumerator trueOrFalse(bool check)
    {
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = false;
        yield return new WaitForSeconds(1);
        qText.gameObject.GetComponent<Animator>().SetTrigger("Out");
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].gameObject.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(0.5f);
        if (!TFIcon.gameObject.activeSelf) TFIcon.gameObject.SetActive(true);
        else TFIcon.gameObject.GetComponent<Animator>().SetTrigger("In");

        if (countbonus >= 3)
        {
            nextt.SetActive(true);
        }

        if (check)
        {
            countbonus = countbonus + 1;
            cnttext.text = countbonus.ToString();
            TFIcon.sprite = TFIcons[0];
            TFText.text = "Правильный ответ";
            yield return new WaitForSeconds(1);
            TFIcon.gameObject.GetComponent<Animator>().SetTrigger("Out");

            TFIcon.gameObject.GetComponent<Animator>().SetTrigger("Out2");
            
            qList.RemoveAt(randQ);
            questionGenerate();
            yield break;
        }
        else
        {
            TFIcon.sprite = TFIcons[1];
            TFText.text = "Неправильный ответ";
            countbonus = 0;
            cnttext.text = countbonus.ToString();
            yield return new WaitForSeconds(1);
            TFIcon.gameObject.GetComponent<Animator>().SetTrigger("Out");
            TFIcon.gameObject.GetComponent<Animator>().SetTrigger("Out2");
            headPanel.GetComponent<Animator>().SetTrigger("Out");
            cnttext.text = "";
            yield break;            
        }
    }

    public void answersBttns(int index)
    {
        if (answersText[index].text.ToString() == crntQ.answers[0]) StartCoroutine(trueOrFalse(true));
        else StartCoroutine(trueOrFalse(false));
        //qList.RemoveAt(randQ);
        //questionGenerate();
       // qList.RemoveAt(randQ);
        //questionGenerate();
    }



}

[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[3];
}