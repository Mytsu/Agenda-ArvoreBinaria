using System;

namespace AgendaArvore
{
    class Program
    {
        static BinaryTree agenda = new BinaryTree();
        static void Main(string[] args)
        {
            int leitor = 0;
            while(leitor != 4) {
                ExibirMenu();
                if(Int32.TryParse(Console.ReadLine(), out leitor)) {
                    switch (leitor)
                    {
                        case 1:
                            AdicionarContato();
                            break;

                        case 2:
                            PesquisarContato();
                            break;
                        
                        case 3:
                            RemoverContato();
                            break;
                    }
                }                
            }
            
        }

        public static void ExibirMenu() {
            Console.WriteLine("Agenda de Contatos: ");
            Console.WriteLine("\t1. Adicionar Contato");
            Console.WriteLine("\t2. Pesquisar Contato");
            Console.WriteLine("\t3. Remover Contato");
            Console.WriteLine("\t4. Sair");
        }

        public static void AdicionarContato() {
            Console.WriteLine("Digite o nome do contato");
            String nome = Console.ReadLine();
            Console.WriteLine("Digite o telefone do contato");
            String telefone = Console.ReadLine();
            Console.WriteLine("Digite o endr do contato");
            String endr = Console.ReadLine();
            int id = GerarId(nome);
            agenda.InsertNode(agenda.AddNode(id, nome, telefone, endr));
        }

        public static void PesquisarContato() {
            Console.WriteLine("Digite o nome do contato");
            String nome = Console.ReadLine();
            int id = GerarId(nome);
            Node contato = agenda.Pesquisa(id);
            if(contato != null) {
                Console.WriteLine("Dados do contato");
                Console.WriteLine("Nome: " + contato.getNome());
                Console.WriteLine("Telefone: " + contato.getTelefone());
                Console.WriteLine("Endereço: " + contato.getEndr());
            } else Console.WriteLine("Contato não encontrado.");
        }

        public static void RemoverContato() {
            Console.WriteLine("Digite o nome do contato");
            String nome = Console.ReadLine();
            int id = GerarId(nome);
            agenda.Remover(id);
        }

        public static int GerarId(String nome) {
            int id = 0;
            int i = 1;
            foreach(char c in nome) {
                id += Convert.ToInt32(c) *i;
                ++i;
            }
            return id;
        }
    }
}
