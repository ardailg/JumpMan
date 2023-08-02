using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public void DeactivateExistingBomb()
    {
        foreach (GameObject bombObject in ObjectPoolBomb.instance.activePooledBombs) // pool'daki bombaların içinde teker teker dönüyor ve SetActive(false) ediyor
        {
            bombObject.SetActive(false);
        }
    }
}
