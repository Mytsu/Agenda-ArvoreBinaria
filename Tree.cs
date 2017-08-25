using System;

namespace AgendaArvore {
    class Node {
        private int id;
        private String nome;
        private String telefone;
        private String endr;
        private Node left, right;

        public Node(int id, String nome, String telefone, String endr) {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
            this.endr = endr;
            left = null;
            right = null;
        }

        public int getId() {
            return this.id;
        }

        public String getNome() {
            return this.nome;
        }

        public String getTelefone() {
            return this.telefone;
        }

        public String getEndr() {
            return this.endr;
        }

        public Node getLeft() {
            return this.left;
        }

        public Node getRight() {
            return this.right;
        }

        public void setId(int id) {
            this.id = id;
        }

        public void setNome(String nome) {
            this.nome = nome;
        }

        public void setTelefone(String telefone) {
            this.telefone = telefone;
        }

        public void setEndr(String endr) {
            this.endr = endr;
        }

        public void setLeft(Node root) {
            this.left = root;
        }

        public void setRight(Node root) {
            this.right = root;
        }
    }
    class BinaryTree {
        public Node root;
        static int count = 0;

        public BinaryTree() {
            root = null;
        }

        public BinaryTree(int id, String nome, String telefone, String endr) {
            root = new Node(id, nome, telefone, endr);
        }

        public Node AddNode(int id, String nome, String telefone, String endr) {
            return new Node(id, nome, telefone, endr);
        }

        public void InsertNode(Node newNode) {
            Node atual = this.root, pai = null;
            while(atual != null)
            {
                if(atual.getId() == newNode.getId())
                {
                    // dados iguais, ignorar
                    return;
                }
                else if(atual.getId() > newNode.getId())
                {
                    // valor atual > entrada, adicionar a esquerda
                    pai = atual;
                    atual = atual.getLeft();
                }
                else if(atual.getId() < newNode.getId())
                {
                    // valor atual < entrada, adicionar a direita
                    pai = atual;
                    atual = atual.getRight();
                }
            }
            count++;
            if(pai == null)
            {
                // arvore vazia, fazer deste a raiz
                pai = newNode;
            }
            else
            {
                if (pai.getId() > newNode.getId())
                {
                    pai.setLeft(newNode);
                }
                else
                    pai.setRight(newNode);
            }
        }

        public Node Pesquisa(int data) {
            return this.Pesquisa(this.root, data);
        }

        public Node Pesquisa(Node root, int data) {
            if(root == null) return null;
            if (root.getId() == data) return root;            
            else if (root.getId() > data && root.getLeft() != null) {
                return Pesquisa(root.getLeft(), data);
            }
            else if (root.getId() < data && root.getRight() != null) {
                return Pesquisa(root.getRight(), data);
            } else return null;
        }

        public Node Remover(int data) {
            return Remover(this.root, data);
        }

        public Node Remover(Node root, int data) {
            // funcao Remover recursiva
            // caso base, arvore vazia
            if(this.root == null) return this.root;
            // recursao, descendo a arvore
            if(this.root.getId() < data) {
                this.root.setLeft(Remover(this.root.getLeft(), data));
            } 
            else if(this.root.getId() > data) {
                this.root.setRight(Remover(this.root.getRight(), data));
            }
            // chave (data) e a mesma da raiz atual
            // deletando
            else {
                // node com apenas um filho ou nenhum
                if (this.root.getLeft() == null) {
                    return this.root.getRight();
                }
                else if (this.root.getRight() == null) {
                    return this.root.getLeft();
                }

                // node com 2 filhos, pegar o sucessor em ordem (o menor)
                this.root.setId(MenorValor(this.root.getLeft()));
                // deletar sucessor em ordem
                this.root.setLeft(Remover(this.root.getLeft(), data));
            }
            return this.root;
        }

        public int MenorValor(Node root) {
            int min = root.getId();
            while (root.getLeft() != null) {
                min = root.getLeft().getId();
                root = root.getLeft();
            }
            return min;
        }

        public int Altura(Node root) {
            if (root == null || root.getLeft() == null || root == null) return 0;
            else {
                return 1 + Maior(a: Altura(root.getLeft()), b: Altura(root.getRight()));
            }
        }

        public int Maior(int a, int b) {
            if(a > b) {
                return a;
            } else return b;
        }
    }
}