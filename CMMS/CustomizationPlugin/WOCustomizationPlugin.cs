﻿using Customization;

namespace CMMS
{
    public class WOCustomizationPlugin : CustomizationPlugin
    {
        public override void UpdateDatabase()
        {
            WONumberingHandler.UpdateDatabase(this);
        }
    }
}
