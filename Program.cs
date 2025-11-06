namespace FilaLinearCircular
{
    public class Lista
    {
        int[] dados;
        int tamAtual, tamMax;
        public Lista(int tam)
        {
            tamMax = tam;
            dados = new int[tamMax];
            tamAtual = 0;
        }
        public bool EstaVazia()
        {
            return tamAtual == 0;
        }
        public bool EstaCheia()
        {
            return tamAtual == tamMax;
        }
        public int Tamanho()
        {
            return tamAtual;
        }
        public void InserirInicio(int v)
        {
            if (EstaCheia())
            {
                Console.WriteLine("Erro: Lista cheia!");
                return;
            }
            for (int i = tamAtual; i > 0 ; i--){
                dados[i] = dados[i - 1];
            }
            dados[0] = v;
            tamAtual++;
        }
        public void InserirFinal(int v)
        {
            if (EstaCheia())
            {
                Console.WriteLine("Erro: Lista cheia!");
                return;
            }
            dados[tamAtual] = v;
            tamAtual++;
        }
        public void InserirPosicao(int v, int pos)
        {
            if(pos < 0 || pos > tamAtual)
            {
                Console.WriteLine("Erro: Posição inválida!");
                return;
            }
            if (EstaCheia())
            {
                Console.WriteLine("Erro: Lista cheia!");
                return;
            }
            for (int i = tamAtual; i > pos; i--)
            {
                dados[i] = dados[i - 1];
            }
            dados[pos] = v;
            tamAtual++;
        }
        public int RemoverInicio()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Lista vazia!");
                return -1;
            }
            int x = dados[0];
            for(int i = 0; i < tamAtual - 1; i++)
            {
                dados[i] = dados[i + 1];
            }
            tamAtual--;
            return x;
        }
        public int RemoverFinal()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Lista vazia!");
                return -1;
            }
            tamAtual--;
            return dados[tamAtual];
        }
        public int RemoverPosicao(int pos)
        {
            if (pos < 0 || pos >= tamAtual)
            {
                Console.WriteLine("Erro: Posição inválida!");
                return -1;
            }
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Lista vazia!");
                return -1;
            }
            int x = dados[pos];
            for(int i = pos; i < tamAtual-1; i++)
            {
                dados[i] = dados[i + 1];
            }
            tamAtual--;
            return x;
        }
        public void Imprimir()
        {
            if (EstaVazia()) Console.Write("Lista vazia: ");
            Console.Write("[ ");
            for(int i = 0; i < tamAtual; i++)
            {
                Console.Write($"{dados[i]} ");
            }
            Console.WriteLine("]");
        }

    }

    public class Pilha
    {
        int[] dados;
        int topo, tamMax;
        public Pilha(int tam)
        {
            tamMax = tam;
            dados = new int[tamMax];
            topo = 0;
        }
        public bool EstaVazia()
        {
            return topo == 0;
        }
        public bool EstaCheia()
        {
            return topo == tamMax;
        }
        public void Empilhar(int v)
        {
            if (EstaCheia()) { 
                Console.WriteLine("Erro: Pilha cheia!");
                return;
            }
            dados[topo] = v;
            topo++;
        }
        public int Desempilhar()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Pilha vazia!");
                return -1;
            }
            topo--;
            return dados[topo];
        }
        public int Topo()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Pilha vazia!");
                return -1;
            }
            return dados[topo-1];
        }
        public void Imprimir()
        {
            if (EstaVazia()) Console.Write("Pilha vazia: ");
            Console.Write("[ ");
            for (int i = topo-1; i >= 0; i--)
            {
                Console.Write($"{dados[i]} ");
            }
            Console.WriteLine("]");
        }
    }

    public class Fila
    {
        int[] dados;
        int primeiro, ultimo, tamAtual, tamMax;

        // Método construtor da Fila
        public Fila(int tam)
        {
            tamMax = tam;
            dados = new int[tamMax];
            primeiro = ultimo = tamAtual = 0;
        }

        // Método para verificar se a Fila está vazia
        public bool EstaVazia()
        {
            return tamAtual == 0;
        }

        // Método para verificar se a Fila está cheia
        public bool EstaCheia()
        {
            return tamAtual == tamMax;
        }

        // Método para retornar o tamanho atual da Fila
        public int Tam()
        {
            return tamAtual;
        }

        // Método para enfileirar um elemento na Fila (inserir no final)
        public void Enqueue(int v)
        {
            if (EstaCheia())
            {
                Console.WriteLine("Erro: Fila cheia!");
                return;
            }
            dados[ultimo] = v;
            ultimo = (ultimo + 1) % tamMax;
            tamAtual++;
        }

        // Método para desenfileirar um elemento (remover do início)
        public int Dequeue()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Fila vazia.");
                return -1;
            }
            int x = dados[primeiro];
            primeiro = (primeiro + 1) % tamMax;
            tamAtual--;
            return x;
        }

        // Método para imprimir todos os elementos da Fila
        public void Imprimir()
        {
            if (EstaVazia())
            {
                Console.Write("Fila vazia: ");
            }
            int count = 0;
            int i = primeiro;
            Console.Write("[ ");
            while (count < tamAtual)
            {
                Console.Write($"{dados[i]} ");
                i = (i + 1) % tamMax;
                count++;
            }
            Console.WriteLine("]");

        }
    }

    public class Celula
    {
        public int Dado;
        public Celula Proximo;
        public Celula(int d)
        {
            Dado = d;
            Proximo = null;
        }
    }


    public class FilaFlexivel
    {
        private Celula primeiro;
        private Celula ultimo;
        private int tamanho;

        // Construtor sem sentinela
        public FilaFlexivel()
        {
            primeiro = null;
            ultimo = null;
            tamanho = 0;
        }

        // Método para verificar se a fila está vazia
        public bool EstaVazia()
        {
            return primeiro == null;
        }

        // Método para enfileirar um elemento (enqueue)
        public void Enfileirar(int item)
        {
            Celula novaCelula = new Celula(item);

            // Se a fila estiver vazia, o novo nó será tanto o front quanto o rear
            if (EstaVazia())
            {
                primeiro = novaCelula;
                ultimo = novaCelula;
            }
            else
            {
                // Caso contrário, adiciona o novo nó no rear da fila
                ultimo.Proximo = novaCelula;
                ultimo = novaCelula;
            }

            tamanho++;
        }

        // Método para desenfileirar um elemento (dequeue)
        public int Desenfileirar()
        {
            // Verifica se a fila está vazia
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Fila vazia!");
                return -1; // Valor de erro
            }

            // Obtém o valor do nó do front
            int valorRemovido = primeiro.Dado;

            // Atualiza o front para o próximo nó
            primeiro = primeiro.Proximo;

            // Se a fila ficar vazia, atualiza também o rear para null
            if (primeiro == null)
            {
                ultimo = null;
            }

            tamanho--;
            return valorRemovido;
        }

        // Método para consultar o primeiro elemento sem removê-lo (peek)
        public int Primeiro()
        {
            // Verifica se a fila está vazia
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Fila vazia!");
                return -1; // Valor de erro
            }

            return primeiro.Dado;
        }

        // Método para retornar o tamanho atual da fila
        public int Tamanho()
        {
            return tamanho;
        }

        // Método para limpar a fila
        public void Limpar()
        {
            primeiro = null;
            ultimo = null;
            tamanho = 0;
        }
        // Método para imprimir os elementos da fila (do front para o rear)
        public void Imprimir()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Fila vazia!");
                return;
            }

            Console.WriteLine("Elementos da fila flexível:");
            Celula aux = primeiro;
            Console.Write("[ ");
            while (aux != null)
            {
                Console.Write($"{aux.Dado} ");
                aux = aux.Proximo;
            }
            Console.WriteLine("]");
        }

    }

    public class PilhaFlexivel
    {
        int tamanho;
        Celula topo;
        public PilhaFlexivel()
        {
            topo = null;
            tamanho = 0;
        }
        public bool EstaVazia()
        {
            return tamanho == 0;
        }
        public void Empilhar(int v)
        {
            Celula nova = new Celula(v);
            nova.Proximo = topo;
            topo = nova;
            tamanho++;
        }
        public int Desempilhar()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Pilha vazia!");
                return -1;
            }
            int v = topo.Dado;
            topo = topo.Proximo;
            tamanho--;
            return v;
        }
        public int Topo()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Pilha vazia!");
                return -1;
            }
            return topo.Dado;
        }
        public void Imprimir()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Pilha vazia!");
                return;
            }
            Celula aux = topo;
            Console.Write("[ ");
            while(aux != null)
            {
                Console.Write($"{aux.Dado} ");
                aux = aux.Proximo;
            }
            Console.WriteLine("]");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implementando TAD Lista Linear:");
            Lista lista = new Lista(5);
            lista.InserirFinal(1);
            lista.InserirFinal(2);
            lista.InserirFinal(3);
            lista.InserirInicio(4);
            lista.InserirPosicao(7,2);
            lista.InserirFinal(3); // Lista cheia
            lista.Imprimir();
            Console.WriteLine($"Remover inicio: {lista.RemoverInicio()}");
            Console.WriteLine($"Remover final: {lista.RemoverFinal()}");
            Console.WriteLine($"Remover posição 1: {lista.RemoverPosicao(1)}");
            lista.Imprimir();

            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine();

            Console.WriteLine("Implementando TAD Pilha Linear:");
            Pilha pilha = new Pilha(3);
            pilha.Empilhar(1);
            pilha.Empilhar(2);
            pilha.Empilhar(3);
            pilha.Empilhar(4); // Pilha cheia
            pilha.Imprimir();
            Console.WriteLine($"Removido: {pilha.Desempilhar()}");
            Console.WriteLine($"Topo: {pilha.Topo()}");
            pilha.Imprimir();

            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine();

            Console.WriteLine("Implementando TAD Fila Linear:");
            Fila fila = new Fila(5);
            fila.Enqueue(1);
            fila.Enqueue(2);
            fila.Enqueue(3);
            fila.Enqueue(4);
            fila.Enqueue(5);
            fila.Imprimir();
            fila.Enqueue(1);
            Console.WriteLine(fila.EstaVazia());
            Console.WriteLine(fila.EstaCheia());
            Console.WriteLine($"Valor removido: {fila.Dequeue()}");
            fila.Imprimir();
            Console.WriteLine($"Como 'andar para atrás' na fila circular: ( (i - 1 + n) % n ) ");

            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine();

            Console.WriteLine("Implementando TAD Fila Flexível:");
            FilaFlexivel filaFlex = new FilaFlexivel();
            filaFlex.Enfileirar(10);
            filaFlex.Enfileirar(20);
            filaFlex.Enfileirar(30);
            filaFlex.Enfileirar(40);
            filaFlex.Imprimir();
            Console.WriteLine($"Desenfileirado: {filaFlex.Desenfileirar()}");
            filaFlex.Imprimir();

            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine();

            Console.WriteLine("Implementando TAD Pilha Flexível:");
            PilhaFlexivel pilhaFlex = new PilhaFlexivel();
            pilhaFlex.Empilhar(10);
            pilhaFlex.Empilhar(20);
            pilhaFlex.Empilhar(30);
            pilhaFlex.Empilhar(40);
            pilhaFlex.Imprimir();
            Console.WriteLine($"Desempilhado: {pilhaFlex.Desempilhar()}");
            pilhaFlex.Imprimir();

        }
    }
}
