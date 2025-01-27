using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_strings
{
    // digspot IDS
    private static int prevDSID = -1;
    private static string[] DigSpotType = { "", "", ""};

    public static string[][] digSpotOptions =
    {
    new string[] { "tennisball", "1", "0" },
    new string[] { "bigball", "2", "1" },
    new string[] { "bone", "3", "2" },
    new string[] { "toybear", "5", "3" }
    };

    public static string[] AssignSpotType()
    {
        int randomNumber;

        do
        {
            randomNumber = UnityEngine.Random.Range(0, digSpotOptions.Length);
        } while (randomNumber == prevDSID);


        prevDSID = randomNumber;
        DigSpotType = digSpotOptions[randomNumber];
        Debug.Log($"Assigned DigSpotType: {string.Join(", ", DigSpotType)}");

        return DigSpotType;

    }
    
}
