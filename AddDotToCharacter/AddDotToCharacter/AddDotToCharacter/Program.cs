using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AddDotToCharacter
{
    class Program
    {
        static void AddDot(string link)
        {
            var imputCode = ReadFile(link);
                                   
            foreach (string imput in imputCode)
            {                
                if (imput.Contains("R") && !imput.Contains("("))
                {                    
                    var splitChars = imput.ToCharArray();
                    for(int i=0;i<splitChars.Length;i++)
                    {
                        if(splitChars[i] == 'R' && splitChars[i+2] != '.')
                        {
                            File.AppendAllText(link, "R2.");                            
                            i++;
                            continue;
                        }
                        if (splitChars[i] == 'P' && splitChars[i+2] != '.')
                        {
                            File.AppendAllText(link, "P1.");
                            i++;
                            continue;
                        }
                        else
                        {
                            var add = Char.ToString(splitChars[i]);
                            File.AppendAllText(link, add);
                        }                        
                    }
                    File.AppendAllText(link, Environment.NewLine);
                }
                else
                {
                    File.AppendAllText(link, imput + Environment.NewLine);
                }               
            }
        }
        
        static string[] ReadFile(string link)
        {
            var imputCode = File.ReadAllLines(link);
            File.Delete(link);

            return imputCode;
        }
        
        static void Main(string[] args)
        {
            string link = @"C:\Users\Dom\Desktop\C# Projekty\AddDotToCharacter\O00001.NC";
            AddDot(link);
        }
    }
}
