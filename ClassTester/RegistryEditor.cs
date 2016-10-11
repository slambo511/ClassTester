using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ClassTester
{
    /// <summary>
    /// Import class with using statement and instantiate in custom fashion i.e. RegistryEditor editor = new RegistryEditor();
    /// The initial three properties have these default values but can be modified (in code) to suit:
    /// Property                Default Value                           Example
    /// _showError              true                                    editor._showError = false;
    /// _baseRegistryKey        Registry.LocalMachine                   editor._baseRegistryKey = Registry.CurrentUser;
    /// _subKey                 "SOFTWARE\\" + Application.ProductName  editor._subKey = "SOFTWARE\\MYPROGRAM\\MYSUBKEY";
    /// The code can of course be altereed to add getters and setters for these properties to make the amendable by the calling code.
    /// 
    /// Examples:
    /// 
    /// Read:               editor.Read("MY_KEY");
    /// Write:              editor.Write("MY_KEY", "MY_VALUE");
    /// Delete single:      editor.Delete("MY_KEY");
    /// Delete subkey tree: editor.DeleteSubKeyTree();
    /// Count subkeys:      editor.SubKeyCount();
    /// Count values inkey: editor.ValueCount(); 
    ///
    /// ...
    /// RegistryEditor myRegistry = new RegistryEditor();
    /// myRegistry.SubKey = "SOFTWARE\\RTF_SHARP_EDIT\\RECENTFILES";
    /// myRegistry.ShowError = true;
    /// int numberValues = myRegistry.ValueCount();
    /// loop
    /// arrayRecentFiles[i] = myRegistry.Read(i.ToString());
    /// ...
    /// 
    /// ...
    /// RegistryEditor myRegistry = new RegistryEditor();
    /// myRegistry.SubKey = "SOFTWARE\\APP_NAME\\RECENTFILES";
    /// myRegistry.ShowError = true; // if getter setter bound
    /// myRegistry.DeleteSubKeyTree();
    /// loop
    /// if (arrayRecentFiles[i] == null)
    ///     break;
    /// myRegistry.Write(i.ToString(), arrayRecentFiles[i]);
    /// ...
    ///  </summary>
    class RegistryEditor
    {
        private readonly bool _showError = true;
        private readonly RegistryKey _baseRegistryKey = Registry.LocalMachine;
        private readonly string _subKey = "SOFTWARE\\" + Application.ProductName;

        // Read function
        public string Read(string keyName)
        {
            RegistryKey rk = _baseRegistryKey;
            RegistryKey sk1 = rk.OpenSubKey(_subKey);
            if (sk1 == null)
            {
                return null;
            }
            else
            {
                try
                {
                    return (string) sk1.GetValue(keyName.ToUpper());
                }
                catch (Exception e)
                {
                    ShowErrorMessage(e, "Reading Registry " + keyName.ToUpper());
                    return null;
                }
            }
        }

        // Write function
        public bool Write(string keyName, object value)
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(_subKey);
                sk1?.SetValue(keyName.ToUpper(), value);

                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Writing registry " + keyName.ToUpper());
                return false;
            }
        }

        // Delete key function
        public bool DeleteKey(string keyName)
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(_subKey);
                sk1?.DeleteValue(keyName);

                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Deleting subkey " + _subKey);
                return false;
            }
        }

        // Delete subkey tree function
        public bool DeleteSubKeyTree()
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(_subKey);
                if (sk1 != null)
                {
                    rk.DeleteSubKeyTree(_subKey);
                }
                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Deleting Subkey tree " + _subKey);
                return false;
            }
        }

        // Sukey count function
        public int SubKeyCount()
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(_subKey);
                if (sk1 != null)
                {
                    return sk1.SubKeyCount;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Retriving subkeys of " + _subKey);
                return 0;
            }
        }

        public int ValueCount()
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(_subKey);
                if (sk1 != null)
                {
                    return sk1.ValueCount;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Retrieving keys of " + _subKey);
                return 0;
            }
        }

        private void ShowErrorMessage(Exception e, string title)
        {
            if (_showError)
            {
                MessageBox.Show(e.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
