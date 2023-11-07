using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor) ||
                fornecedor.Endereco != null && !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            if ((await _fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento)).Any())
            {
                Notificar("Já existe um fornecedor com esse documento informado");
                return;
            }

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if (!(await _fornecedorRepository.Buscar(f => f.Id == fornecedor.Id)).Any())
            {
                Notificar("Fornecedor não encontrado");
                return;
            }

            if ((await _fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id)).Any())
            {
                Notificar("Já existe um fornecedor com esse documento informado");
                return;
            }

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task Remover(Guid id)
        {
            var fornecedor = await _fornecedorRepository.ObterFornecedorProdutoEndereco(id);

            if (fornecedor == null)
            {
                Notificar("Fornecedor não encontrado");
                return;
            }

            if (fornecedor.Produtos != null && fornecedor.Produtos.Any())
            {
                Notificar("Fornecedor possui produtos cadastrados");
                return;
            }

            var endereco = await _fornecedorRepository.ObterEnderecoPorFornecedor(id);

            if (endereco != null)
            {
                await _fornecedorRepository.RemoverEnderecoFornecedor(endereco);
            }

            await _fornecedorRepository.Remover(id);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
        }
    }
}
