namespace ValidadorCPFCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o CPF a ser validado: ");
            var cpf = Console.ReadLine();

            if (ValidarCPF(cpf))
            {
                Console.WriteLine($"O CPF " + cpf + " é válido!");
            }
            else
            {
                Console.WriteLine($"O CPF " + cpf + " é inválido!");
            }
        }

        public static bool ValidarCPF(string cpf)
        {

            if (string.IsNullOrEmpty(cpf))
                return false;


            cpf = cpf.Replace(".", "").Replace("-", "");

            
            if (cpf.Length != 11)
                return false;

      
            if (!cpf.All(char.IsDigit))
                return false;

            
            var cpfArray = cpf.ToCharArray();


            var peso = 10;
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += (cpfArray[i] - '0') * peso--;
            var resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            if ((cpfArray[9] - '0') != resto)
                return false;


            peso = 11;
            soma = 0;

            for (var i = 0; i < 10; i++)
                soma += (cpfArray[i] - '0') * peso--;
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            if ((cpfArray[10] - '0') != resto)
                return false;

            return true;
        }
    }
}
