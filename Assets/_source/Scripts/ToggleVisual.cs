using UnityEngine;

public class ToggleVisual : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameObjects;

    internal void Active(bool v)
    {
        int id = v ? 1 : 0;

        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(id == i);
        }
    }
}
