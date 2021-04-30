using System.Collections.Generic;

namespace DIO.Bank.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaPorId(int Id);
         void Insere(T entidade);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}