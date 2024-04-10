namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jogo jogo = new Jogo();

            jogo.DesenharForca();

            string letrasEncontradas = jogo.EscolherPalavra();

            jogo.EscreverLetrasEncontradas(letrasEncontradas);

            while (jogo.numeroErros < 5) 
            {
                char chute = jogo.Chutar();

                if (jogo.palavraEscolhida.Contains(chute))
                {
                    bool fimDeJogo = jogo.ChutesCertos(chute);
                    if (fimDeJogo)
                    {
                        break;
                    }
                }
                else
                {
                    jogo.ChutesErrados();
                }
            }
            Console.ReadLine();
        }
    }
}
