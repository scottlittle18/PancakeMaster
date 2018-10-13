using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeCounter : MonoBehaviour
{
    [SerializeField]
    Image Life1, Life2, Life3;

    PlayerController controller;

    private void Start()
    {
        controller = GetComponent<PlayerController>();

        CheckLives();
    }

    private void Update()
    {
        if (controller.Dead)
        {
            CheckLives();

            controller.Dead = false;
        }
    }

    void CheckLives()
    {
        if (controller.RemainingLives >= 0)
        {
            switch (controller.RemainingLives)
            {
                case (3):
                    {
                        SetLives(true);
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
                        SetLives(false);
                        break;
                    }
                default:
                    {
                        Debug.Log("Error with LifeCounter.Update().");

                        break;
                    }
            }
        }
        else
        {
            SetLives(false);

            // Game Over Code Here
        }
    }

    void SetLives(bool b_Life1, bool b_Life2, bool b_Life3)
    {
        Life1.enabled = b_Life1;
        Life2.enabled = b_Life2;
        Life3.enabled = b_Life3;
    }

    void SetLives(bool b_Life)
    {
        Life1.enabled = b_Life;
        Life2.enabled = b_Life;
        Life3.enabled = b_Life;
    }
}