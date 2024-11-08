using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriangleColor : MonoBehaviour
{
    private readonly List<Color> colors = new()
    {
        Color.blue,
        Color.green,
        Color.red,
        Color.cyan,
        Color.magenta,
        Color.yellow,
        new(1f, 0.5f, 0f),
        new(0.7f, 0f, 0.7f),
        new(0.2f, 0.5f, 0.2f)
    };

    public void AssignColor(GameObject tile)
    {
        TMP_Text topText = tile.transform.Find("Top/Canvas/Text").GetComponent<TMP_Text>();
        TMP_Text bottomText = tile.transform.Find("Bottom/Canvas/Text").GetComponent<TMP_Text>();
        TMP_Text leftText = tile.transform.Find("Left/Canvas/Text").GetComponent<TMP_Text>();
        TMP_Text rightText = tile.transform.Find("Right/Canvas/Text").GetComponent<TMP_Text>();

        int topNumber = int.Parse(topText.text);
        int bottomNumber = int.Parse(bottomText.text);
        int leftNumber = int.Parse(leftText.text);
        int rightNumber = int.Parse(rightText.text);

        SpriteRenderer topSprite = tile.transform.Find("Top").GetComponent<SpriteRenderer>();
        SpriteRenderer bottomSprite = tile.transform.Find("Bottom").GetComponent<SpriteRenderer>();
        SpriteRenderer leftSprite = tile.transform.Find("Left").GetComponent<SpriteRenderer>();
        SpriteRenderer rightSprite = tile.transform.Find("Right").GetComponent<SpriteRenderer>();

        topSprite.color = colors[topNumber - 1];
        bottomSprite.color = colors[bottomNumber - 1];
        leftSprite.color = colors[leftNumber - 1];
        rightSprite.color = colors[rightNumber - 1];
    }
}