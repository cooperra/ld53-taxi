using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public enum Conditions
{
    finish,
    win,
    lose,
    start,
    exit
}

public class GameManager : MonoBehaviour
{
    public System.Action<int> MoneyChanged;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private float time = 2;
    private float seconds;
    private float minutes;
    public static GameManager instance;
    /*
     * This manages start, win, conditions
     * Handles Score that is read by playerMovement and UI Money
     * At the end of the game the player explodes.
     * exit the game exits
     * doesn't do anything until the player starts
     * Game Ends at 2 minutes FinishLine Appears a few seconds after the finish line is crossed the car Explodes!!!
     */
    //Trying to add events maybe?..nah
    private int money;
    public int startMoney = 250;
    public int Money { get { return money; } set { money = value; MoneyChanged?.Invoke(money); } }
    private Conditions condition;
    public Conditions Conditions
    {
        get { return condition; }
        set { condition = value; }
    }

    private void Timer()
    {
        seconds += 1 * Time.deltaTime;
       
        if(seconds > 60)
        {
            seconds = 0;
            minutes += 1;
            Debug.Log(minutes);
        }
        if(minutes == time)
        {
            condition = Conditions.finish;
        }
        if(minutes == 2 && seconds == 15)
        {
            condition = Conditions.win;
        }
        timeText.text = minutes.ToString() + ":" + seconds.ToString();
    }
    private void Awake()
    {

        condition = Conditions.start;
        if (instance != this && instance != null)
        {
         Destroy(this);
           
        }
        else
        {
            instance = this;
        }
        StartGame();

    }

    private void Exit()
    {
        if (condition == Conditions.exit)
        {

            Application.Quit();
        }
       
            return;
        
    }
    private void Lose()
    {
        if (condition == Conditions.lose)
        {
            Scene currentLevel = SceneManager.GetActiveScene();

            if (currentLevel != SceneManager.GetSceneAt(0))
            {
                SceneManager.LoadScene(0);
            }


        }
        return;
    }
    
    public void Win(GameObject car)
    {
        if (condition == Conditions.win)
        {
            //Explode Car

            Destroy(car);
        
        }
        return;
    }

    public void StartGame()
    {
        Money = startMoney;
        condition = Conditions.start;
        Scene currentLevel = SceneManager.GetActiveScene();
        if (condition == Conditions.start)
        {
            if (currentLevel != SceneManager.GetSceneAt(0))
            {
                SceneManager.LoadScene(0);
            }
        }
        return;
    }
   
    private void Update()
    {
        Timer();
        Exit();
        Lose();
        
    
    }
}
