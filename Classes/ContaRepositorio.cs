using System.Collections;
using System.Collections.Generic;
using DIO.Bank.Interfaces;

namespace DIO.Bank.Classes
{
    public class ContaRepositorio : IRepositorio<Conta>
    {
        private List<Conta>  listaConta = new List<Conta>();

        public void Atualiza(int id, Conta entidade)
        {
            listaConta[id] = entidade;
        }

        public void Insere(Conta entidade)
        {
            listaConta.Add(entidade);
        }

        public List<Conta> Lista()
        {
            return listaConta;
        }

        public int ProximoId()
        {
            return listaConta.Count;
        }

        public Conta RetornaPorId(int Id)
        {
            return listaConta[Id];
        }
    }
}