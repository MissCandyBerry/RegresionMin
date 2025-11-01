using System;
using System.Windows.Forms;

namespace RegresionMinCuadUI
{
 internal static class Program
 {
 [STAThread]
 static void Main()
 {
 ApplicationConfiguration.Initialize();
 Application.Run(new MainForm());
 }
 }
}