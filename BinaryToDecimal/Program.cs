using System;

class ConversorDecimalBinario
{
    static void Main()
    {
        while (true)
        {
            try
            {
                int opcao;
                do
                {
                    Console.WriteLine("Escolha uma opção:");
                    Console.WriteLine("1 - Decimal para binário");
                    Console.WriteLine("2 - Binário para decimal");
                    Console.WriteLine("0 - Sair");

                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Console.Write("Digite um número decimal: ");
                            int decimalNum = int.Parse(Console.ReadLine());
                            string binario = DecimalParaBinario(decimalNum);
                            Console.WriteLine($"O número {decimalNum} em binário é: {binario}");
                            break;
                        case 2:
                            Console.Write("Digite um número binário: ");
                            string binarioNum = Console.ReadLine();

                            foreach (char c in binarioNum)
                            {
                                if (c != '0' && c != '1')
                                {
                                    throw new FormatException("A entrada não é um número binário válido.");
                                }
                            }

                            int decimalNum2 = BinarioParaDecimal(binarioNum);
                            Console.WriteLine($"O número binário {binarioNum} em decimal é: {decimalNum2}");
                            break;
                        case 0:
                            Console.WriteLine("Saindo...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }

                    Console.WriteLine();
                } while (opcao != 0);

            }
            catch (FormatException)
            {
                Console.WriteLine(" A entrada não é um número válido. \n        Tente novamente!\n");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static string DecimalParaBinario(int decimalNum)
    {
        string binario = "";

        while (decimalNum > 0)
        {
            int resto = decimalNum % 2;
            binario = resto + binario; //para adicionar o bit à esquerda
            decimalNum /= 2;
        }

        return binario;
    }
    static int BinarioParaDecimal(string binarioNum)
    {
        int decimalNum = 0;
        int expoente = binarioNum.Length - 1;

        for (int i = 0; i < binarioNum.Length; i++)
        {
            int digito = int.Parse(binarioNum[i].ToString());
            decimalNum += digito * (int)Math.Pow(2, expoente); //Math.Pow define a base e o expoente, à esquerda e à direita respectivamente
            expoente--;
        }

        return decimalNum;
    }


}