using System;
using Shared.Domain.ValueObjects;

namespace Shared.Domain.Entities;

public class Pessoa
{
    public Guid Id { get; }
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public Endereco Endereco { get; private set; }

    public Pessoa(Guid id, string nome, DateTime dataNascimento, Endereco endereco)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("O identificador da pessoa não pode ser vazio.", nameof(id));
        }

        Nome = string.IsNullOrWhiteSpace(nome)
            ? throw new ArgumentException("O nome da pessoa deve ser informado.", nameof(nome))
            : nome;

        DataNascimento = dataNascimento == default
            ? throw new ArgumentException("A data de nascimento deve ser válida.", nameof(dataNascimento))
            : dataNascimento;

        Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
        Id = id;
    }

    public static Pessoa CriarNova(string nome, DateTime dataNascimento, Endereco endereco)
        => new(Guid.NewGuid(), nome, dataNascimento, endereco);

    public void AtualizarEndereco(Endereco novoEndereco)
    {
        Endereco = novoEndereco ?? throw new ArgumentNullException(nameof(novoEndereco));
    }

    public void AtualizarNome(string novoNome)
    {
        Nome = string.IsNullOrWhiteSpace(novoNome)
            ? throw new ArgumentException("O nome da pessoa deve ser informado.", nameof(novoNome))
            : novoNome;
    }
}
