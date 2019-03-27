using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class RepositorioBalance
    {
        public static Balance Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Balance balance = new Balance();

            try
            {
                balance = contexto.balances.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return balance;
        }

        public static List<Balance> GetList(Expression<Func<Balance, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Balance> balance = new List<Balance>();

            try
            {
                balance = contexto.balances.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return balance;
        }
    }
}
