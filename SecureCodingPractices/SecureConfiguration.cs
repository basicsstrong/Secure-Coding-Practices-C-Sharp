using System;
using System.IO;

class SecureFileConfiguration
    {
        public static void Trigger()
        {
            string username = "<username>";
            Console.WriteLine(ReadSensitiveFile("Authentication.cs", username));
        }

        public static string ReadSensitiveFile(string filePath, String username)
        {
            if(HasPermission(filePath, username)){
                try
                {
                    return File.ReadAllText(filePath);
                }
                catch (IOException)
                {
                    return "Error reading the file.";
                }
            }else{
                throw new UnauthorizedAccessException("Illegal access to sensitive file");
            }
            
            }

    private static bool HasPermission(string filePath, string username)
    {
        var fileInfo = new FileInfo(filePath);
        var owner = GetFileOwner(fileInfo);
        return owner.Equals(username);
    }

    private static object GetFileOwner(FileInfo fileInfo)
    {
        var processStartInfo = new System.Diagnostics.ProcessStartInfo{
            FileName = "/usr/bin/stat",
            Arguments = $"-f%Su \"{fileInfo.FullName}\"",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = System.Diagnostics.Process.Start(processStartInfo);
        if(process != null){
           string output =  process.StandardOutput.ReadToEnd();
           process.WaitForExit();
           if(process.ExitCode ==0){
            return output.Trim();
           }
        }

        throw new IOException("Error while retrieving file owner");
    }
}
    
