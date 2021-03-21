using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;


public class CulterHelper
{
    private ICulterSet _iCulterSetting;

    public CulterHelper(ICulterSet iCulterSetting)
    {
        _iCulterSetting = iCulterSetting;
    }

    public ResourceManager SetCulter()
    {
        return _iCulterSetting.SetLanguage();
    }
}
