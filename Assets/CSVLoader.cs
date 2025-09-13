using System;
using System.Collections.Generic;
using System.Linq;
using Sinbad;
using UnityEngine;

public class BugInfo
{
    public string Identifier;
    public string Desc;
    public string Hint;
    public string Reason;
    public string Title;
}

public class CSVLoader : Singleton<CSVLoader>
{
    public List<BugInfo> bugs = new List<BugInfo>();
    public Dictionary<string, BugInfo> bugsMap = new Dictionary<string, BugInfo>();

    public void Init()
    {
         bugs = CsvUtil.LoadObjects<BugInfo>("bug");
         foreach (var bug in bugs)
         {
             bugsMap.Add(bug.Identifier, bug);
         }
    }
}