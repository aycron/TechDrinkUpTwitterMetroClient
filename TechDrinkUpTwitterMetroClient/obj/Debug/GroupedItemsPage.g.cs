﻿

#pragma checksum "C:\Users\Lucas\Dropbox\projects\vsProjects\TechDrinkUpTwitterMetroClient\TechDrinkUpTwitterMetroClient\GroupedItemsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D13F7FC9A8121EB86F921BF16F892780"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace TechDrinkUpTwitterMetroClient
{
    partial class GroupedItemsPage : TechDrinkUpTwitterMetroClient.Common.LayoutAwarePage, IComponentConnector
    {
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 117 "..\..\GroupedItemsPage.xaml"
                ((Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.ItemView_ItemClick;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 47 "..\..\GroupedItemsPage.xaml"
                ((Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


