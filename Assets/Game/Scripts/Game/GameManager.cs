using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum Conditions
{
    win,
    lose,
    start,
    exit
}

public class GameManager : MonoBehaviour
{
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
    public int money;
    private Conditions condition;
    public Conditions Conditions
    {
        get { return condition; }
        set { condition = value; }
    }
    private void Start()
    {
       
        if (this.gameObject != null && this != null)
        {
         Destroy(this);
           
        }
        else
        {
            instance = this;
        }
       
        
    }

    public void Exit()
    {
        if (condition == Conditions.exit)
        {

            Application.Quit();
        }
    }
    public void Lose()
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
}
