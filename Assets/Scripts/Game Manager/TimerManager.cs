using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countUp;

    // Start is called before the first frame update
    void Start()
    {
        countUp = true;
        if(PlayerPrefs.HasKey("timeValue")) {
            currentTime = PlayerPrefs.GetFloat("timeValue");
        }
    }

    void OnApplicationQuit() {
        PlayerPrefs.DeleteKey("timeValue");
        currentTime = 0;
    }

    void updateTimer(float timer) {
        timer += 1;
        float min = Mathf.FloorToInt(timer / 60);
        float sec = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{00} : {1:00}", min, sec);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime >= 0 && countUp) {
            currentTime = currentTime += Time.deltaTime;
            PlayerPrefs.SetFloat("timeValue", currentTime);
            updateTimer(currentTime);
            //timerText.text = currentTime.ToString();
        }
        if(Input.GetKey("escape")) {
            OnApplicationQuit();
        }

        //SetTimerText();
    }

    //private void SetTimerText() {
        //timerText.text = currentTime.ToString("00.00");
    


    //public void resetTimer {

    //}
} // class