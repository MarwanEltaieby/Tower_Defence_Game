using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    int currentBalance;
    [SerializeField] TMP_Text balanceText;
    public int CurrentBalance { get { return currentBalance; } }

    public void Deposit(int amount) {
        currentBalance += Mathf.Abs(amount);
        balanceText.SetText("Gold: " + currentBalance);
    }

    public void Withdraw(int amount) {
        currentBalance -= Mathf.Abs(amount);
        balanceText.SetText("Gold: " + currentBalance);
        if (currentBalance < 0) {
            ReloadScene();
        }
    }

    private void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start() {
        currentBalance = startingBalance;
        balanceText.SetText("Gold: " + currentBalance);
    }
}
