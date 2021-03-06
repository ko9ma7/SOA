﻿using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Windows.Forms;

namespace SOA
{
    class StartMain
    {
        [STAThread]
        static void Main(string[] args)
        {
            ScriptOptions option = ScriptOptions.Default;

            List<Assembly> assemblys = new List<Assembly>
            {
                typeof(object).GetTypeInfo().Assembly,
                typeof(System.Linq.Enumerable).GetTypeInfo().Assembly,
                typeof(System.Windows.Forms.Application).GetTypeInfo().Assembly,
                typeof(SOA.SOAApp).GetTypeInfo().Assembly
            };

            List<string> namespaces = new List<string>
            {
                "System",
                "System.IO",
                "System.Collections.Generic",
                "System.Windows.Forms",
                "System.Drawing",
                "System.Drawing.Imaging",
                "SOA",
                "SOA.Extension"
            };

            foreach (Assembly assemble in assemblys)
            {
                option = option.WithReferences(assemble);
            }

            foreach (string name in namespaces)
            {
                option = option.AddImports(name);
            }

            //string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "sample.csx");
            //string path = "C:/Users/adunstudio/Desktop/SOA/SOA/Sample/1_sample_keyboard.csx"; // keyboad 
            //string path = "C:/Users/adunstudio/Desktop/SOA/SOA/Sample/2_sample_mouse.csx";    // mouse
            //string path = "C:/Users/adunstudio/Desktop/SOA/SOA/Sample/3_sample_capture.csx";  // capture
            string path = "C:/Users/adunstudio/Desktop/SOA/SOA/Sample/4_sample_clip.csx";    // Clip

            var app = new SOAApp();

            Console.WriteLine("Program Start...");
            CSharpScript.RunAsync(File.ReadAllText(path), option, app).Wait();

            app.Run();
        }
    }
}
