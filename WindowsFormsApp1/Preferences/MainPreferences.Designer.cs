﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kenvix.ClipboardSync.Preferences {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.4.0.0")]
    internal sealed partial class MainPreferences : global::System.Configuration.ApplicationSettingsBase {
        
        private static MainPreferences defaultInstance = ((MainPreferences)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new MainPreferences())));
        
        public static MainPreferences Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(Kenvix.ClipboardSync.Preferences.AppConfigProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DeviceAddress {
            get {
                return ((string)(this["DeviceAddress"]));
            }
            set {
                this["DeviceAddress"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(Kenvix.ClipboardSync.Preferences.AppConfigProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DeviceName {
            get {
                return ((string)(this["DeviceName"]));
            }
            set {
                this["DeviceName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(Kenvix.ClipboardSync.Preferences.AppConfigProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("256")]
        public int MinGzipCompressSize {
            get {
                return ((int)(this["MinGzipCompressSize"]));
            }
            set {
                this["MinGzipCompressSize"] = value;
            }
        }
    }
}
