using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;

class Checker
{
    static void Main()
    {
        
         
            System.Console.WriteLine("hello");
         Assembly assem =typeof(en_US).Assembly;
      
         
      // Enumerate the resource files.
      string[] resNames = assem.GetManifestResourceNames();
      if (resNames.Length == 0)
         Console.WriteLine("   No resources found.");

      foreach (var resName in resNames)
         Console.WriteLine("   Resource: {0}", resName.Replace(".resources", ""));
        
        
    }
}

