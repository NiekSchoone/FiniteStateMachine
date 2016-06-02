//Created by: Niek Schoone

using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Names
{
    private string lineRead;
    private int lineNumber;

    private string[][] allNames;

    public List<List<string>> nameList = new List<List<string>>();

    void GetNames()
    {
        StreamReader reader = new StreamReader("Names.txt");

        lineRead = reader.ReadToEnd();
        lineNumber++;
        allNames = lineRead.Split(',').Select(t => t.Split('\n')).ToArray();
        for (int i = 0; i < allNames.Length; i++)
        {
            List<string> getNewList = new List<string>(allNames[i]);

            nameList.Add(getNewList);

            nameList[i].RemoveAt(0);
        }
    }
}