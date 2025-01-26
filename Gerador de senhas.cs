using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Geardor_de_senhas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao Gerador de Senhas");
            Console.WriteLine();

            // Solicita o comprimento da senha do usuário
            Console.Write("Digite o comprimento da senha: ");
            int comprimento = int.Parse(Console.ReadLine());

            //Configurações de opções
            Console.WriteLine("Incluir letras maiúsculas? (s/n): ");
            bool incluirMaiusculas = Console.ReadLine().Trim().ToLower() == "s";

            Console.WriteLine("Incluir letras minusculas? (s/n): ");
            bool incluirMinusculas = Console.ReadLine().Trim().ToLower() == "s";

            Console.WriteLine("Incluir Números? (s/n): ");
            bool incluirNumeros = Console.ReadLine().Trim().ToLower() == "s";

            Console.WriteLine("Incluir caracteres especiais? (s/n): ");
            bool incluirEspeciais = Console.ReadLine().Trim().ToLower() == "s";

            // Gera e exibe a senha
            string senha = GerarSenha(comprimento, incluirMaiusculas, incluirMinusculas, incluirNumeros, incluirEspeciais);
            Console.WriteLine($"\nSenha gerada: {senha}");

        }
            static string GerarSenha(int comprimento, bool incluirMaiusculas, bool incluirMinusculas, bool incluirNumeros, bool incluirEspeciais)
            {
            const string letrasMaiusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string letrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
            const string numeros = "0123456789";
            const string caracteresEspeciais = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            StringBuilder caracteres = new StringBuilder();

            if (incluirMaiusculas) caracteres.Append(letrasMaiusculas);
            if (incluirMinusculas) caracteres.Append(letrasMinusculas);
            if (incluirNumeros) caracteres.Append(numeros);
            if (incluirEspeciais) caracteres.Append(caracteresEspeciais);

            if (caracteres.Length == 0)
            {
                throw new ArgumentException("Pelo menos uma opção deve ser selecionada para gerar a senha.");
            }

            StringBuilder senha = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < comprimento; i++)
            {
                int index = random.Next(caracteres.Length);
                senha.Append(caracteres[index]);
            }

            return senha.ToString();

        }
    }
}