using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace Bull_Crypt
{
    public class Parametriza
    {

      public  static void Menu()
        {
            ConfigurarCorDaFonte(ConsoleColor.Green);

            Console.WriteLine("\n**********Cryptography v1.0**********\n");

            ConfigurarCorDaFonte(ConsoleColor.Gray);

            Console.WriteLine(" Criptografar    Credenciais - > 'C'");

            Console.WriteLine(" Descriptografar Credenciais - > 'D'");

            Console.WriteLine(" Ajuda                       - > 'A'");

            Console.WriteLine(" Sair                        - > 'S'");

            OpcaoSelecionada();
        }


       public static void ConfigurarCorDaFonte(ConsoleColor corDaFonte)
        {
            Console.ForegroundColor = corDaFonte;
        }

      public  static void ConfigurarJanela()
        {
            
            Console.Title = "<<BULL CRYPT>>";
            Console.BufferHeight = 40;
            Console.BufferWidth = 100;
            Console.SetWindowSize(100, 40);

        }


    public    static void OpcaoSelecionada()
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            cki = Console.ReadKey(true);

            if (cki.Key == ConsoleKey.C)
            {
                
                Criptografia.CriptografarArquivo();
                Console.Beep();
                Console.Beep();
            }
            else if (cki.Key == ConsoleKey.D)
            {
                Criptografia.DesCriptografarArquivo();
                Console.Beep();
                Console.Beep();
                Console.Beep();

                return;
            }
            else if (cki.Key == ConsoleKey.A)
            {
                Console.Beep();
                OpcaoAjuda();
            }
            else if (cki.Key == ConsoleKey.S)
            {
                Console.Beep();
                Environment.Exit(0);
                
            }

            Menu();
        }

    public static void OpcaoAjuda()
    {
        Parametriza.ConfigurarCorDaFonte(ConsoleColor.Blue);
        Console.WriteLine("\nPara criptografar a string, basta inserir na chave VALUE da entrada appSettings no arquivo Bull_Crypt.exe.conf ");
        Console.WriteLine("\n<add key=ConnectionString  value=Password=XXXXXX;Persist Security Info=True;User ID=XXXXXX;Data Source=XXXXXX  /> \n");
        Console.WriteLine("A string criptografada será exibida e logo gravada no arquivo Bull_Crpt.exe.conf, basta copiar a chave criptografada para o arquivo .CONF do componente desejado, salvar o arquivo e inicializar o serviço. A string criptografada será reconhecida automaticamente pelo serviço. \n");
        Console.WriteLine("EXEMPLO ENTRADA ARQUIVO .CONF \n");
        Console.WriteLine("\n");
        Parametriza.ConfigurarCorDaFonte(ConsoleColor.Yellow);
        Console.WriteLine("<appSettings>\n");
        Console.WriteLine("<add key=ConnectionString value=Password=xxxxxx;Persist Security Info=True;User ID=xxxxxx;Data Source=xxxxxx  />    \n");
        Console.WriteLine("</appSettings>\n");


    }

  

    }   
    
    }

