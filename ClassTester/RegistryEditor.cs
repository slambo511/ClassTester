using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ClassTester
{
    class RegistryEditor
    {
        private readonly bool _showError = true;
        private readonly RegistryKey _baseRegistryKey;
        private readonly string _subKey;

        public RegistryEditor(RegistryKey baseRegistryKey, string subKey)
        {
            _baseRegistryKey = baseRegistryKey;
            _subKey = subKey;
        }

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
