using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static int GetIntFromName(string name)
    {
        if (char.IsDigit(name[^1]))
        {
            // If the second-to-last character is also a digit, include both; otherwise, include only the last character
            string numberPart = char.IsDigit(name[^2]) ? name.Substring(name.Length - 2) : name.Substring(name.Length - 1);
        
            return int.Parse(numberPart);
        }
        
        return -1;
    }
}