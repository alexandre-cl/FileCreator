using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace Dir_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Environment.UserName;
            Console.WriteLine("Bem vindo ao criador de diretórios de Alexandre!");
            Console.Write("Digite o nome do diretório que deseja criar: ");
            string dirName = Console.ReadLine();
            string path = @"c:\Users\"+username+@"\Desktop\"+dirName+@"\";
            try
            {
                if(Directory.Exists(path))
                {
                    Console.WriteLine("Diretório já existente em => " + path);
                    Console.WriteLine("Acessando...");
                    string argument = @"c:\select, " + path;
                    Process.Start("explorer.exe",argument);
                    return;
                }

                Console.WriteLine("Criando Diretório {0} em => {1}", dirName, path);
                DirectoryInfo dir = Directory.CreateDirectory(path);
                Console.WriteLine("Diretório Criado!!");
                char delete = ' ';
                bool invalidChoice = true;
                string userComand;
                while (invalidChoice)
                {
                    Console.WriteLine(new String('-', 10));
                    Console.Write("Deseja exluí-lo?(y/n): ");
                    userComand = Console.ReadLine();
                    if (userComand.Length > 1)
                        continue;
                    delete = userComand.ToLower().ToCharArray()[0];
                    Console.WriteLine("Opção selecionada => " + delete);
                    if (delete != 'y' && delete != 'n')
                    {
                        Console.WriteLine(@"Digite 'y' para sim e 'n' para não...");
                        invalidChoice = true;
                    }
                    else 
                    {
                        invalidChoice = false;
                    }
                        
                }

                if(delete == 'y')
                {
                    Console.WriteLine("Excluíndo diretório {0}", dirName);
                    dir.Delete();
                    Console.WriteLine("Diretório excluído com sucesso!");
                }
                    
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro de execução: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Digite enter para sair.");
                Console.ReadLine();
            }
        }
    }
}
