using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeCounter : MonoBehaviour
{

    Image Life1, Life2, Life3;

    PlayerController controller;

    [SerializeField]
    private int remainingLives = 3;

    private void Start()
    {
        controller = GetComponent<PlayerController>();

        Life1.enabled = true;
        Life2.enabled = true;
        Life3.enabled = true;
    }

    private void Update()
    {
        if (controller.Dead)
        {
            switch (remainingLives)
            {
                case (3):
                    {
                        SetLives(true, true, true);
                        break;
                    }
                case (2):
                    {
                        SetLives(true, true, false);
                        break;
                    }
                case (1):
                    {
                        SetLives(true, false, false);
                        break;
                    }
                case (0):
                    {
                        SetLives(false, false, false);
                        break;
                    }
                case (-1):
                    {
                        // Game over code here.

                        break;
                    }
                default:
                    {
                        Debug.Log("Error with LifeCounter.Update().");

                        break;
                    }
            }

            controller.Dead = true;
        }
    }

    void SetLives(bool b_Life1, bool b_Life2, bool b_Life3)
    {
        Life1.enabled = b_Life1;
        Life2.enabled = b_Life2;
        Life3.enabled = b_Life3;
    }
}