using System;
using System.Collections.Generic;

namespace MissaoRPG
{
    public class Personagem
    {
   
        private string nome;
        private int vida;
        private int nivel;
        public string Nome
        {
            get => nome;
            set => nome = value;
        }

        public int Vida
        {
            get => vida;
            set
            {
                if (value > 100)
                    vida = 1000;
                else if (value < 0)
                    vida = 0;
                else
                    vida = value;
            }
        }

        public int Nivel
        {
            get => nivel;
            set => nivel = value;
        }
        public Personagem(string nome, int vida, int nivel)
        {
            Nome = nome;
            Vida = vida; 
            Nivel = nivel;
        }
        public virtual void Apresentar()
        {
            Console.Write($"Nome: {Nome} | Vida: {Vida} | Nível: {Nivel}");
        }
        public virtual bool Atacar()
        {
            if (Vida <= 0)
            {
                Console.WriteLine($"{Nome} está sem vida e não pode atacar.");
                return false;
            }
            return true;
        }
        public void ReceberDano(int quantidade)
        {
            Vida -= quantidade; 
            Console.WriteLine($"{Nome} recebeu {quantidade} de dano! Vida atual: {Vida}");
        }
    }
    public class Guerreiro : Personagem
    {
        public string Arma { get; set; }
        public Guerreiro(string nome, int vida, int nivel, string arma) 
            : base(nome, vida, nivel)
        {
            Arma = arma;
        }

        public override void Apresentar()
        {
            base.Apresentar();
            Console.WriteLine($" | Classe: Guerreiro | Arma: {Arma}");
        }

        public override bool Atacar()
        {
            if (!base.Atacar()) return false;

            Console.WriteLine($"{Nome} ataca com o {Arma} e causa dano físico!");
            return true;
        }
    }
    public class Mago : Personagem
    {
        public string Elemento { get; set; }

        public Mago(string nome, int vida, int nivel, string elemento) 
            : base(nome, vida, nivel)
        {
            Elemento = elemento;
        }

        public override void Apresentar()
        {
            base.Apresentar();
            Console.WriteLine($" | Classe: Mago | Elemento: {Elemento}");
        }

        public override bool Atacar()
        {
            if (!base.Atacar()) return false;

            Console.WriteLine($"{Nome} lança uma magia de {Elemento}!");
            return true;
        }
    }
    public class Arqueiro : Personagem
    {
        public int QtdFlechas { get; set; }

        public Arqueiro(string nome, int vida, int nivel, int qtdFlechas) 
            : base(nome, vida, nivel)
        {
            QtdFlechas = qtdFlechas;
        }

        public override void Apresentar()
        {
            base.Apresentar();
            Console.WriteLine($" | Classe: Arqueiro | Flechas: {QtdFlechas}");
        }

        public override bool Atacar()
        {
            if (!base.Atacar()) return false;

            if (QtdFlechas > 0)
            {
                QtdFlechas--;
                Console.WriteLine($"{Nome} dispara uma flecha precisa à distância! Flechas restantes: {QtdFlechas}");
                return true;
            }
            else
            {
                Console.WriteLine($"{Nome} tentou atacar, mas está sem flechas!");
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SAÍDA ESPERADA NO TESTE DA VIDA ===");
            Personagem p1 = new Personagem("TesteAlto", 150, 1);
            Console.WriteLine($"Personagem criado com vida 150 -> vida registrada: {p1.Vida}");

            Personagem p2 = new Personagem("TesteBaixo", -20, 1);
            Console.WriteLine($"Personagem criado com vida -20 -> vida registrada: {p2.Vida}");
            Console.WriteLine();
            List<Personagem> guilda = new List<Personagem>
            {
                new Guerreiro("Thorin", 100, 5, "Machado de Batalha"),
                new Mago("Merlin", 80, 7, "Fogo"),
                new Guerreiro("Brutus", 0, 3, "Espada Longa"),
                new Mago("Gandalf", 95, 10, "Luz"),
                new Arqueiro("Legolas", 90, 6, 5)
            };

            Console.WriteLine("=== PERSONAGENS ===");
            foreach (Personagem p in guilda)
            {
                p.Apresentar();
            }

            Console.WriteLine("\n=== BATALHA ===");
            foreach (Personagem p in guilda)
            {
                p.Atacar();
            }
            Console.WriteLine("\n=== TESTE DO BÔNUS (RECEBER DANO) ===");
            guilda[0].ReceberDano(30);
            guilda[0].ReceberDano(100);
        }
    }
}