namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DesenharForca();

            string palavraEscolhida;
            int tamanhoDaPalavra;
            char[] palavraPreenchida;

            EscolherPalavra(out palavraEscolhida, out tamanhoDaPalavra, out palavraPreenchida);

            int numeroErros = 0;
            while (numeroErros < 5)
            {
                Console.SetCursorPosition(0, 13);
                Console.Write("                                ");
                Console.SetCursorPosition(0, 13);
                Console.Write("Qual o seu chute? ");
                char chute = Convert.ToChar(Console.ReadLine().ToUpper());

                if (palavraEscolhida.Contains(chute))
                {
                    bool fimDeJogo = ChutesCertos(palavraEscolhida, tamanhoDaPalavra, palavraPreenchida, chute);
                    if (fimDeJogo)
                    {
                        break;
                    }
                }
                else
                {
                    numeroErros = ChutesErrados(numeroErros);
                }
            }
        }
        private static void DesenharForca()
        {
            Console.WriteLine("Jogo da Forca!");
            Console.WriteLine();

            Console.SetCursorPosition(0, 1);
            Console.Write(" -----------");
            Console.SetCursorPosition(0, 2);
            Console.Write(" |/        |");
            Console.SetCursorPosition(0, 3);
            Console.Write(" |");
            Console.SetCursorPosition(0, 4);
            Console.Write(" |");
            Console.SetCursorPosition(0, 5);
            Console.Write(" |");
            Console.SetCursorPosition(0, 6);
            Console.Write(" |");
            Console.SetCursorPosition(0, 7);
            Console.Write(" |");
            Console.SetCursorPosition(0, 8);
            Console.Write(" |");
            Console.SetCursorPosition(0, 9);
            Console.Write("_|____");
        }
        private static void EscolherPalavra(out string palavraEscolhida, out int tamanhoDaPalavra, out char[] palavraInformada)
        {
            Random numeroAleatorio = new Random();
            int numeroAleatorioEscolhido = numeroAleatorio.Next(0, 29);

            string[] opcoesDePalavras = new string[] {"Abacate", "Abacaxi", "Acerola", "Açaí", "Araça", "Bacaba", "Bacuri", "Banana", "Cajá", "Cajú",
            "Carambola", "Cupuaçu", "Graviola", "Goiaba", "Jabuticaba", "Jenipapo", "Maçã", "Mangaba", "Manga", "Maracujá", "Murici", "Pequi", "Pitanga",
            "Pitaya", "Sapoti", "Tangerina", "Umbu", "Uva", "Uvaia"};

            palavraEscolhida = opcoesDePalavras[numeroAleatorioEscolhido].ToUpper();
            tamanhoDaPalavra = palavraEscolhida.Length;
            Console.SetCursorPosition(0, 11);
            Console.Write(new string('_', tamanhoDaPalavra));
            palavraInformada = new char[palavraEscolhida.Length];
            for (int i = 0; i < palavraEscolhida.Length; i++)
            {
                palavraInformada[i] = '-';
            }
        }
        private static bool ChutesCertos(string palavraEscolhida, int tamanhoDaPalavra, char[] palavraInformada, char chute)
        {
            for (int j = 0; j < tamanhoDaPalavra; j++)
            {
                if (palavraEscolhida[j].Equals(chute))
                {
                    palavraInformada[j] = chute; //tamanhoDaPalavra
                    Console.SetCursorPosition(j, 11);
                    Console.Write(chute);
                }
            }
            if (!palavraInformada.Contains('-'))
            {
                Console.SetCursorPosition(0, 13);
                Console.Write("Parabéns, você acertou!        ");
                Console.WriteLine();
                return true;
            }
            return false;
        }
        private static int ChutesErrados(int numeroErros)
        {
            numeroErros++;
            switch (numeroErros)
            {
                case 1:
                    Console.SetCursorPosition(11, 3);
                    Console.Write('o');
                    break;
                case 2:
                    Console.SetCursorPosition(10, 4);
                    Console.Write('/');
                    break;
                case 3:
                    Console.SetCursorPosition(11, 4);
                    Console.Write('x');
                    break;
                case 4:
                    Console.SetCursorPosition(12, 4);
                    Console.Write('\\');
                    break;
                case 5:
                    Console.SetCursorPosition(11, 5);
                    Console.Write('x');
                    Console.SetCursorPosition(0, 13);
                    Console.Write("O jogo acabou!        ");
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
            return numeroErros;
        }
    }
}
