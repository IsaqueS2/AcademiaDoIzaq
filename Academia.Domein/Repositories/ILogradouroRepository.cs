//ISAQUE DE OLIVEIRA DOS SANTOS
using Academia.Domain.Entities;
namespace AcademiaDoZe.Domain.Repositories
{
    public interface ILogradouroRepository : IRepository<Logradouro>
    {
   
        Task<Logradouro?> ObterPorCep(string cep);

        Task<IEnumerable<Logradouro>> ObterPorCidade(string cidade);
    }
}