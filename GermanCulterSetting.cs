using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;


public class GermanCulterSetting : ICulterSet
{
    public ResourceManager SetLanguage()
    {
        ResourceManager resourceManager = new ResourceManager("checker.de-DE.resx",
            Assembly.GetExecutingAssembly());
        return resourceManager;
    }
}
