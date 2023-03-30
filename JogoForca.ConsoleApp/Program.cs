internal class Program
{
    static string letraChutada;

    static int contadorCerta = 0;
    static int contadorErrada = 0;

    static int quantidadeDeErros = 0;
    static string palavrasRandom;

    static string[] letraCerta = new string[26];
    static string[] letraErrada = new string[26];

    static string[] palavras = { "Abacate", "Abacaxi", "Acerola", "Acai", "Araca", "Figo", "Bacaba", "Bacuri", "Banana", "Caja", "Caju", "Carambola", "Cupuacu", "Graviola", "Goiaba", "Jabuticaba", "Jenipapo", "Maca", "Mangaba", "Manga", "Maracuja", "Murici", "Pequi", "Pitanga", "Pitaya", "Sapoti", "Tangerina", "Umbu", "Uva", "Uvaia" };


    static void Main(string[] args)
    {

        Console.WriteLine("----------------------------");
        Console.WriteLine("       JOGO DA FORCA        ");
        Console.WriteLine("----------------------------");

        Console.WriteLine("PRESSIONE ENTER PARA COMECAR");
        Console.ReadLine();

        PalavraAleatoria();

        while (true)
        {
            Console.Clear();
            InicioDoJogo();
        }

    }

    static void PalavraAleatoria()
    {
        Random random = new Random();
        int escolhaPalavra = random.Next(0, 30);
        palavrasRandom = palavras[escolhaPalavra].ToUpper();
    }

    static void InicioDoJogo()
    {

        char[] palavraQuebrada = palavrasRandom.ToCharArray();

        do
        {
            int contador = 0;

            Console.Clear();
            Console.WriteLine(" ");
            DesenhoDaForca();

            if (quantidadeDeErros == 5)
            {
                Console.WriteLine("GAME OVER, O BONECO FOI ENFORCADO x-x");
                Console.WriteLine($"A PALAVRA ERA: {palavrasRandom.ToUpper()}");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < palavraQuebrada.Length; i++)
            {
                if (letraCerta.Contains(palavrasRandom[i].ToString()))
                {
                    Console.Write(palavrasRandom[i]);
                    contador++;
                }
                else
                {
                    Console.Write(" _ ");
                }
            }

            if (palavrasRandom.Length == contador)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("VOCÊ SALVOU O BONECO!");
                Console.ResetColor();
                Console.ReadLine();
                return;
            }


            Console.WriteLine(" ");
            Console.Write("Digite uma letra: ");
            letraChutada = Console.ReadLine().ToUpper();

            VerificarALetra(letraChutada);


        } while (quantidadeDeErros <= 5);
    }

    static void DesenhoDaForca()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(" _____________     ");
        Console.WriteLine(" |  /        T     ");
        Console.WriteLine(" | /         |     ");
        Console.WriteLine(" |/         {0}       ", (quantidadeDeErros >= 1 ? " o " : " "));
        Console.WriteLine(" |          {0}{1}{2} ", (quantidadeDeErros >= 3 ? "/" : " "), (quantidadeDeErros >= 2 ? "x" : " "), (quantidadeDeErros >= 3 ? "\\" : " "));
        Console.WriteLine(" |          {0}       ", (quantidadeDeErros >= 2 ? " x " : " "));
        Console.WriteLine(" |          {0}       ", (quantidadeDeErros >= 4 ? "/ \\" : " "));
        Console.WriteLine(" |                 ");
        Console.WriteLine(" |                 ");
        Console.WriteLine("_|____             ");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.ResetColor();
    }

    static void VerificarALetra(string letra)
    {

        int posicaoDaLetra = palavrasRandom.IndexOf(letraChutada);


        if (posicaoDaLetra < 0)
        {
            letraErrada[contadorErrada] = letraChutada;
            contadorErrada++;
            quantidadeDeErros++;

            Console.WriteLine("ERROU");
            Console.ReadLine();
            return;
        }
        else if (posicaoDaLetra >= 0)
        {
            letraCerta[contadorCerta] = letraChutada;
            contadorCerta++;

            Console.WriteLine("ACERTOU");
            Console.ReadLine();
            return;
        }
    }
}

