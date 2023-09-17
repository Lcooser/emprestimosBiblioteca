using System;

interface IPublicacao
{
    string Tipo { get; }
    string Nome { get; }
    DateTime CalcularDataDevolucao();
}

abstract class Publicacao : IPublicacao
{
    public string Tipo { get; protected set; }
    public string Nome { get; protected set; }
    protected DateTime DataEmprestimo;

    public Publicacao(string nome)
    {
        Nome = nome;
        DataEmprestimo = DateTime.Now;
    }

    public abstract DateTime CalcularDataDevolucao();
}

class Livro : Publicacao
{
    public Livro(string nome) : base(nome)
    {
        Tipo = "Livro";
    }

    public override DateTime CalcularDataDevolucao() => DataEmprestimo.AddDays(5);
}

class Jornal : Publicacao
{
    public Jornal(string nome) : base(nome)
    {
        Tipo = "Jornal";
    }

    public override DateTime CalcularDataDevolucao() => DataEmprestimo.AddDays(7);
}

class Revista : Publicacao
{
    public Revista(string nome) : base(nome)
    {
        Tipo = "Revista";
    }

    public override DateTime CalcularDataDevolucao() => DataEmprestimo.AddDays(15);
}

class Program
{
    static void Main()
    {
        IPublicacao livro = new Livro("Livro A");
        IPublicacao jornal = new Jornal("Jornal B");
        IPublicacao revista = new Revista("Revista C");

        ImprimirDetalhes(livro);
        ImprimirDetalhes(jornal);
        ImprimirDetalhes(revista);
    }

    static void ImprimirDetalhes(IPublicacao publicacao)
    {
        Console.WriteLine($"Empréstimo de {publicacao.Tipo}: {publicacao.Nome}");
        Console.WriteLine($"Data de devolução: {publicacao.CalcularDataDevolucao():dd/MM/yyyy}");
        Console.WriteLine();
    }
}
