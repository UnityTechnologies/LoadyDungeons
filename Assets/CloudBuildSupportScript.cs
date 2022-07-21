using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBuildSupportScript : MonoBehaviour
{
    public static void PostExportMethod(string playerPath)
    {
        var cli = Environment.GetEnvironmentVariable("CCD_BINARY_PATH");
        System.Diagnostics.ProcessStartInfo procStartInfo =
            new System.Diagnostics.ProcessStartInfo(cli,
                "--apikey " + "859c3f086ff8a56ad1238a66b81547a1" + "ucd config set environment e1ae0f2f-9a93-4c63-b9d0-72a76267fff6" + "--project=ac9fa272-0c81-486f-9fbe-90f7a0611922");

        // The following commands are needed to redirect the standard output.
        // This means that it will be redirected to the Process.StandardOutput StreamReader.
        procStartInfo.RedirectStandardOutput = true;
        procStartInfo.UseShellExecute = false;
        // Do not create the black window.
        procStartInfo.CreateNoWindow = true;
        // Now we create a process, assign its ProcessStartInfo and start it
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo = procStartInfo;
        try
        {
            proc.Start();
            // Get the output into a string
            string result = proc.StandardOutput.ReadToEnd();
            // Display the command output.
            Debug.Log(result);
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
