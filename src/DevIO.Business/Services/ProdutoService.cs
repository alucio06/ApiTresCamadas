using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository fornecedorRepository, INotificador notificador) : base(notificador)
        {
            _produtoRepository = fornecedorRepository;
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            if (!(await _produtoRepository.Buscar(f => f.Id == produto.Id)).Any())
            {
                Notificar("Produto não encontrado");
                return;
            }

            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            if (!(await _produtoRepository.Buscar(f => f.Id == id)).Any())
            {
                Notificar("Produto não encontrado");
                return;
            }

            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
