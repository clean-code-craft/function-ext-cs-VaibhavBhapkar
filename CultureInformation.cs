using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

public static class CultureInformation
{
    public static ResourceManager resourceManager;
    public static void SetCultureInformation(ResourceManager _resourceManager)
    {
        resourceManager = _resourceManager;
    }
    public static ResourceManager GetCultureInformation()
    {
        return resourceManager;
    }
}

