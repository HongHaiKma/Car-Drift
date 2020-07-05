using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FormatTextTool : MonoBehaviour
{
    // public static string FormatText(float num)
    // {
    //     string formattedText = "";
    //     float reducNum;
    //     // char[] reducChar;

    //     if (num >= 1000000000)
    //     {
    //         reducNum = num / 1000000000;
    //         // formattedText = reducNum.ToString("F1") + "B";
    //         // formattedText = string.Format("{0:0.00000000}", reducNum) + "B";
    //         formattedText = (Mathf.Round(reducNum * 10000000000f) / 10000000000f) + "B";
    //     }
    //     else if (num >= 1000000)
    //     {
    //         reducNum = num / 1000000;
    //         // formattedText = reducNum + "M";
    //         formattedText = string.Format("{0:0.0}", reducNum) + "M";
    //     }
    //     else if (num >= 10000)
    //     {
    //         reducNum = num / 1000;
    //         // formattedText = reducNum + "K";
    //         formattedText = string.Format("{0:0.0}", reducNum) + "K";
    //     }
    //     else
    //     {
    //         formattedText = num.ToString();
    //     }

    //     return formattedText;
    // }

    public static string FormatText(int coin)
    {
        string _coinResponse = "";
        string _coin = "";

        char[] charArray = coin.ToString().ToCharArray();
        switch (charArray.Length)
        {
            case 4:
                _coin = "{0}K";
                if (Int32.Parse(charArray[1].ToString()) >= 5) _coin = "{0}.{1}K";
                break;
            case 5:
                _coin = "{0}{1}K";
                if (Int32.Parse(charArray[2].ToString()) >= 5) _coin = "{0}{1}.{2}K";
                break;
            case 6:
                _coin = "{0}{1}{2}K";
                if (Int32.Parse(charArray[3].ToString()) >= 5) _coin = "{0}{1}{2}.{3}K";
                break;
            case 7:
                _coin = "{0}M";
                if (Int32.Parse(charArray[1].ToString()) >= 5) _coin = "{0}.{1}M";
                break;
            case 8:
                _coin = "{0}{1}M";
                if (Int32.Parse(charArray[2].ToString()) >= 5) _coin = "{0}{1}.{2}M";
                break;
            case 9:
                _coin = "{0}{1}{2}M";
                if (Int32.Parse(charArray[3].ToString()) >= 5) _coin = "{0}{1}{2}.{3}M";
                break;
            case 10:
                _coin = "{0}B";
                if (Int32.Parse(charArray[1].ToString()) >= 5) _coin = "{0}.{1}B";
                break;
            default:
                Array.Reverse(charArray);
                return new string(charArray);
        }

        _coinResponse = string.Format(_coin, charArray[0], charArray[1], charArray[2], charArray[3]);

        return _coinResponse;
    }

    public static string FormatText(float coin)
    {
        string _coinResponse = "";
        string _coin = "";

        char[] charArray = coin.ToString().ToCharArray();
        switch (charArray.Length)
        {
            case 4:
                _coin = "{0}K";
                if (Int32.Parse(charArray[1].ToString()) >= 5) _coin = "{0}.{1}K";
                break;
            case 5:
                _coin = "{0}{1}K";
                if (Int32.Parse(charArray[2].ToString()) >= 5) _coin = "{0}{1}.{2}K";
                break;
            case 6:
                _coin = "{0}{1}{2}K";
                if (Int32.Parse(charArray[3].ToString()) >= 5) _coin = "{0}{1}{2}.{3}K";
                break;
            case 7:
                _coin = "{0}M";
                if (Int32.Parse(charArray[1].ToString()) >= 5) _coin = "{0}.{1}M";
                break;
            case 8:
                _coin = "{0}{1}M";
                if (Int32.Parse(charArray[2].ToString()) >= 5) _coin = "{0}{1}.{2}M";
                break;
            case 9:
                _coin = "{0}{1}{2}M";
                if (Int32.Parse(charArray[3].ToString()) >= 5) _coin = "{0}{1}{2}.{3}M";
                break;
            case 10:
                _coin = "{0}B";
                if (Int32.Parse(charArray[1].ToString()) >= 5) _coin = "{0}.{1}B";
                break;
            default:
                Array.Reverse(charArray);
                return new string(charArray);
        }

        _coinResponse = string.Format(_coin, charArray[0], charArray[1], charArray[2], charArray[3]);

        return _coinResponse;
    }
}
