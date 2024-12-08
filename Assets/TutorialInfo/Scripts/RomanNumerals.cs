using TMPro;
using UnityEngine;

public class RomanNumerals : MonoBehaviour
{
    public TextMeshPro textMeshPro;

    void Start()
    {
        int number = 5; // Örneğin: 5
        string romanNumeral = ToRoman(number);
        textMeshPro.text = romanNumeral;
    }

    string ToRoman(int number)
    {
        string[] thousands = { "", "M", "MM", "MMM" };
        string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        return thousands[number / 1000] +
               hundreds[(number % 1000) / 100] +
               tens[(number % 100) / 10] +
               units[number % 10];
    }
}
