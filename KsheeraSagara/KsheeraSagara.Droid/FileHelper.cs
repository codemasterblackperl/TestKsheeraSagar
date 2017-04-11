using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KsheeraSagara.Data;
using KsheeraSagara.Droid;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]
namespace KsheeraSagara.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path= Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "KsheeraSagara");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return Path.Combine(path, fileName);
        }
    }
}