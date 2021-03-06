/*
 
 2008 Jos� Manuel Men�ndez Poo
 * 
 * Please give me credit if you use this code. It's all I ask.
 * 
 * Contact me for more info: menendezpoo@gmail.com
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace SoftLogik.Win.UI.Controls
{
    internal class RibbonPanelDesigner
        : RibbonElementWithItemCollectionDesigner
    {

        public override Ribbon Ribbon
        {
            get
            {
                if (Component is RibbonPanel)
                {
                    return (Component as RibbonPanel).Owner;
                }
                return null;
            }
        }

        public override RibbonItemCollection Collection
        {
            get
            {
                if (Component is RibbonPanel)
                {
                    return (Component as RibbonPanel).Items;
                }
                return null;
            }
        }
    }
}
