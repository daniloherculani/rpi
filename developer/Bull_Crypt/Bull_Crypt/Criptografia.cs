using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Bull_Crypt;
using System.Configuration;



namespace Bull_Crypt
{
    public class Criptografia
    {

        
        public static string Codificar(string entrada)
        {
            TripleDESCryptoServiceProvider tripledescryptoserviceprovider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5cryptoserviceprovider = new MD5CryptoServiceProvider();

            try
            {
                if (entrada.Trim() != "")
                {
                    string myKey = "Discovery$001";  //Chave base para cifrar,  deve ser a mesma no método Decodificar
                    tripledescryptoserviceprovider.Key = md5cryptoserviceprovider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
                    tripledescryptoserviceprovider.Mode = CipherMode.ECB;
                    ICryptoTransform desdencrypt = tripledescryptoserviceprovider.CreateEncryptor();
                    ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
                    byte[] buff = Encoding.ASCII.GetBytes(entrada);

                    return Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));

                }
                else
                {
                    return "";
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                tripledescryptoserviceprovider = null;
                md5cryptoserviceprovider = null;
            }

        }

        public static string Decodificar(string entrada)
        {
            TripleDESCryptoServiceProvider tripledescryptoserviceprovider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5cryptoserviceprovider = new MD5CryptoServiceProvider();

            try
            {
                if (entrada.Trim() != "")
                {
                    string myKey = "Discovery$001";   //  deve ser a mesma no método codificar
                    tripledescryptoserviceprovider.Key = md5cryptoserviceprovider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
                    tripledescryptoserviceprovider.Mode = CipherMode.ECB;
                    ICryptoTransform desdencrypt = tripledescryptoserviceprovider.CreateDecryptor();
                    byte[] buff = Convert.FromBase64String(entrada);

                    return ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
                }
                else
                {
                    return "";
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                tripledescryptoserviceprovider = null;
                md5cryptoserviceprovider = null;
            }

        }

        //---

           public static void CriptografarArquivo()
        {
            Parametriza.ConfigurarCorDaFonte(ConsoleColor.Green);
            Console.WriteLine("\n<<< -INICIANDO - >>>:");
            Console.WriteLine("\n");
            Console.WriteLine("\n");           
            Console.WriteLine("\n<<< - STRING ORIGINAL >>>:");
            Console.WriteLine("\n");
               
                string str_conn = ConfigurationManager.AppSettings["ConnectionString"].ToString();
                if (!String.IsNullOrEmpty(str_conn) && str_conn.Contains("Data Source"))
                {

                    Parametriza.ConfigurarCorDaFonte(ConsoleColor.White);
                    Console.WriteLine(str_conn);

                    Parametriza.ConfigurarCorDaFonte(ConsoleColor.Blue);
                    int cont = 0;
                    while (cont <= 3)
                    {
                        Console.WriteLine("\n<<< CRIANDO CHAVES DE CRIPTOGRAFIA EM - >>>:" + cont);
                        cont++;
                        System.Threading.Thread.Sleep(100);
                    }

                    Parametriza.ConfigurarCorDaFonte(ConsoleColor.Green);
                    try
                    {
                        string a = Criptografia.Codificar(str_conn);
                        Console.WriteLine("\nSTRING CRIPTOGRAFADA:");
                        Parametriza.ConfigurarCorDaFonte(ConsoleColor.White);
                        Console.WriteLine(a);

                        UpdateAppSettings("ConnectionString", a);

                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }

                }
                else
                {
                    Parametriza.ConfigurarCorDaFonte(ConsoleColor.Red);
                    Console.WriteLine("\nSTRING DE CONEXÃO NÃO ENCONTRADA ou JÁ CRIPTOGRAFADA! - VERIFIQUE O ARQUIVO .CONF");
                }

            //if (str_conn_ret != "")
            //{
                //Password=sifra;Persist Security Info=True;User ID=FRAUSR06_CTR;Data Source=xe

                /*
                     int[] pos_str_conn = new int[4];
 
                     pos_str_conn[0] = str_conn.IndexOf("ID=");
                     pos_str_conn[1] = str_conn.IndexOf(";D" ) ;
                     pos_str_conn[2] = str_conn.IndexOf("rd=");
                     pos_str_conn[3] = str_conn.IndexOf(";P" );

                     string str_username = str_conn.Substring(pos_str_conn[0] + 3, pos_str_conn[1] - pos_str_conn[0] - 3);
                     string str_userpwd  = str_conn.Substring(pos_str_conn[2] + 3, pos_str_conn[3] - pos_str_conn[2] - 3);

                     Console.WriteLine("\nSTRING:" + str_username);
                     Console.WriteLine("\nSTRING:" + str_userpwd );

                     */


              

           // }
                Parametriza.Menu();



        }//public static void CriptografarArquivo()


           public static void DesCriptografarArquivo()
           {
               Parametriza.ConfigurarCorDaFonte(ConsoleColor.Green);
               Console.WriteLine("\n<<< -INICIANDO - >>>:");
               Console.WriteLine("\n");
               Console.WriteLine("\n");
               Console.WriteLine("\n<<< - STRING CRIPTOGRAFADA >>>:");
               Console.WriteLine("\n");
               string str_conn = ConfigurationManager.AppSettings["ConnectionString"].ToString();

               if (!String.IsNullOrEmpty(str_conn) && !str_conn.Contains("Data Source"))
               {
                  
                   Parametriza.ConfigurarCorDaFonte(ConsoleColor.White);
                   Console.WriteLine(str_conn);

                   Parametriza.ConfigurarCorDaFonte(ConsoleColor.Blue);
                   int cont = 0;
                   while (cont <= 3)
                   {
                       Console.WriteLine("\n<<< ABRINDO CHAVES DE CRIPTOGRAFIA  - >>>:" + cont);
                       cont++;
                       System.Threading.Thread.Sleep(100);
                   }

                   Parametriza.ConfigurarCorDaFonte(ConsoleColor.Green);
                   try
                   {
                       string a = Criptografia.Decodificar(str_conn);
                       Console.WriteLine("\nSTRING DESCRIPTOGRAFADA:");
                       Parametriza.ConfigurarCorDaFonte(ConsoleColor.White);
                       Console.WriteLine(a);
                       UpdateAppSettings("ConnectionString", a);
                   }
                   catch
                   {
                       Parametriza.ConfigurarCorDaFonte(ConsoleColor.Red);
                       Console.WriteLine("\n<<< PROBLEMAS AO DESCRIPTOGRAFAR A STRING DE CONEXÃO, REVISE O ARQUIVO .CONF >>>");

                   }

               }
               else
               {
                   Parametriza.ConfigurarCorDaFonte(ConsoleColor.Red);
                   Console.WriteLine("\nSTRING DE CONEXÃO NÃO ENCONTRADA ou JÁ DESCRIPTOGRAFADA! - VERIFIQUE O ARQUIVO .CONF");
               }
               
               Parametriza.Menu();
           }//public static void DesCriptografarArquivo()
          
        
        
        public  static void UpdateAppSettings(string chave, string valor)
        {
            // Abre arquivo de parametrização .CONFIG
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
           
            // Remove e cria a chave com os novos valores
            config.AppSettings.Settings.Remove(chave);
            config.AppSettings.Settings.Add(chave, valor);
           
            // Salva a modificação no arquivo fisico.
            config.Save(ConfigurationSaveMode.Modified);
           
            // Atualiza em memória o arquivo .CONFIG.
            ConfigurationManager.RefreshSection("appSettings");

        }//UpdateAppSettings(string chave, string valor)          

    }//public class Criptografia
}//namespace Bull_Crypt
 