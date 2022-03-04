using agenda.Data;
using agenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agenda.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext BancoContext)
        {
            _bancoContext = BancoContext; 
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel Contato)
        {
            _bancoContext.Contatos.Add(Contato);
            _bancoContext.SaveChanges();
                return Contato;

        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.id == id);
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel ContatoDB = ListarPorId(contato.id);

            if (ContatoDB == null) throw new System.Exception("houve um erro na atualização do Contato");

            ContatoDB.nome = contato.nome;
            ContatoDB.email = contato.email;
            ContatoDB.telefone = contato.telefone;

            _bancoContext.Contatos.Update(ContatoDB);
            _bancoContext.SaveChanges();

            return ContatoDB;
        }

        public bool ApagarContato(int id)
        {
            ContatoModel ContatoDB = ListarPorId(id);

            if (ContatoDB == null) throw new System.Exception("Erro na exclusão do contato");

            _bancoContext.Contatos.Remove(ContatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
