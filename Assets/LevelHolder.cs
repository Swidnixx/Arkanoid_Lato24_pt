using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHolder : MonoBehaviour
{
    public GameObject[] levels;
    int currentLevel;

    List<Klocek> klocki =  new List<Klocek>();

    public int IloscKlockow => klocki.Count;
    public int MaxLevel => levels.Length - 1;

    public void SetLevel(int level)
    {
        currentLevel = level;
        Instantiate(levels[currentLevel], transform);

        klocki.Clear();
        klocki.AddRange(GetComponentsInChildren<Klocek>());
    }

    public void UsunKlocek(Klocek klocek)
    {
        klocki.Remove(klocek);
    }
}
