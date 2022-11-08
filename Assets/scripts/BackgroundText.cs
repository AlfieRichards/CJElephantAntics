using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BackgroundText : MonoBehaviour
{
    public Color[] colors = { new Color(249, 229, 145,1), new Color(69, 153, 96,1), new Color(172, 90, 147,1), new Color(219, 245, 136,1),  new Color(128, 100, 212,1), new Color(088, 33, 0, 1)};
    public TextMeshProUGUI[] textObjects = {};
    List<Color> colorsUsing = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeColour", 0.2f, 0.2f);
    }

    void ChangeColour()
    {
        foreach(Color color in colors)
        {
            Debug.Log(color);
            colorsUsing.Add(color);
        }

        foreach(TextMeshProUGUI text in textObjects)
        {
            int i = Random.Range(0, colorsUsing.Count);
            text.color = colorsUsing[i];
            colorsUsing.RemoveAt(i);
        }
    }
}
