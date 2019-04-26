using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GuessNumGame
{
    public class AssemblyInfo
    {
        private Assembly CheckedAssembly;

        public AssemblyInfo(Assembly assembly)
        {
            CheckedAssembly = assembly;
        }

        public void PrintAssemblyInfo()
        {
            foreach (TypeInfo type in CheckedAssembly.GetTypes())
            {
                Console.WriteLine($"{type.FullName}");


                foreach (var field in type.DeclaredFields)
                {
                    Console.WriteLine($"\t{field.Name}\t{field.FieldType}");
                }

                foreach (var method in type.DeclaredMethods)
                {
                    Console.WriteLine($"\t{method.Name}\t{method.ReturnType}");

                    foreach(var param in method.GetParameters())
                    {
                        Console.WriteLine($"\t\t{param.Name}");
                    }
                }
                Console.WriteLine("_______________________________________________________");
            }
        }
        
    }
}
