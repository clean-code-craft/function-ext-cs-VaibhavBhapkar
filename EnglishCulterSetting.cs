using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;


public class EnglishCulterSetting : ICulterSet
{
    public ResourceManager SetLanguage()
    {
        ResourceManager resourceManager = new ResourceManager("checker.en-US.resx",
            Assembly.GetExecutingAssembly());
        return resourceManager;
    }
}

