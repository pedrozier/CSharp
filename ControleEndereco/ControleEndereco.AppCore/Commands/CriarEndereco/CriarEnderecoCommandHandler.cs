using ControleEndereco.Domain.Interfaces.Repositories;

using ControleEndereco.AppCore.Mappers;

using FluentValidation;

using MediatR;

namespace ControleEndereco.AppCore.Commands.CriarEndereco
{
    public class CriarEnderecoCommandHandler : IRequestHandler<CriarEnderecoCommand, CriarEnderecoResult>
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IValidator<CriarEnderecoCommand> _criarEnderecoCommandValidator;

        public CriarEnderecoCommandHandler(IEnderecoRepository enderecoRepository, IValidator<CriarEnderecoCommand> criarEnderecoCommandValidator)
        {
            _enderecoRepository = enderecoRepository;
            _criarEnderecoCommandValidator = criarEnderecoCommandValidator;
        }

        public async Task<CriarEnderecoResult> Handle(CriarEnderecoCommand request, CancellationToken cancellationToken)
        {
            await _criarEnderecoCommandValidator.ValidateAndThrowAsync(request, cancellationToken);

            var entity = request.ToModel();
            await _enderecoRepository.SalvarAsync(entity);

            return new(entity.Id);
        }
    }
}
