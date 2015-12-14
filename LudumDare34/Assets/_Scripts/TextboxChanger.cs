using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextboxChanger : MonoBehaviour
{

    public GameObject[] textboxes;
    int stage = 0;
    public float timer = 0.0f;
    public float timerDelay = 10.0f;
    float disappearDelay = 8.0f;
    public bool animating = false;
    Vector3 target;
    float speed = 20.0f;
    float speedDefault = 50.0f;
    float speedIncrement = 100.0f;
    // Use this for initialization
    void Awake()
    {
        setStage(1);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (animating)
        {
            speed += speedIncrement * Time.deltaTime;
            textboxes[this.stage].transform.position = Vector3.MoveTowards(textboxes[this.stage].transform.position, target, speed * Time.deltaTime);
            if(Vector3.Distance(textboxes[this.stage].transform.position,target) <= 1.0f && timer >= disappearDelay)
            {
                Color color = textboxes[this.stage].transform.GetComponent<Image>().color;
                Color fontColor = textboxes[this.stage].transform.FindChild("Text").GetComponent<Text>().color;
                textboxes[this.stage].transform.GetComponent<Image>().color = new Color(color.r,color.g,color.b,color.a - 1f * Time.deltaTime);
                textboxes[this.stage].transform.FindChild("Text").GetComponent<Text>().color = new Color(fontColor.r, fontColor.g, fontColor.b, fontColor.a - 1f * Time.deltaTime);
            }
            if (timer > timerDelay)
            {
                textboxes[stage].SetActive(false);
                animating = false;
            }
        }

    }
    public void setStage(int stage)
    {
        if (stage > textboxes.Length)
            return;
        this.stage = stage - 1;
        for (int i = 0; i < textboxes.Length; i++)
        {
            textboxes[i].SetActive(false);
        }
        textboxes[this.stage].SetActive(true);
        animating = true;
        timer = 0.0f;
        target = textboxes[this.stage].transform.position;
        textboxes[this.stage].transform.position = new Vector3(GameObject.Find("Canvas").transform.GetComponent<RectTransform>().rect.width / 2, -textboxes[this.stage].GetComponent<RectTransform>().rect.height / 2) ;
        speed = speedDefault;
    }

}
