using ControleEndereco.AppCore.Mappers;
using ControleEndereco.Domain.Interfaces.Repositories;

using FluentValidation;

using MediatR;

namespace ControleEndereco.AppCore.Commands.AtualizarEndereco
{
    public class AtualizarEnderecoCommandHandler : IRequestHandler<AtualizarEnderecoCommand, AtualizarEnderecoResult>
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IValidator<AtualizarEnderecoCommand> _atualizarEnderecoCommandValidator;

        public AtualizarEnderecoCommandHandler(IEnderecoRepository enderecoRepository, IValidator<AtualizarEnderecoCommand> atualizarEnderecoCommandValidator)
        {
            _enderecoRepository = enderecoRepository;
            _atualizarEnderecoCommandValidator = atualizarEnderecoCommandValidator;
        }

        public async Task<AtualizarEnderecoResult> Handle(AtualizarEnderecoCommand request, CancellationToken cancellationToken)
        {
            await _atualizarEnderecoCommandValidator.ValidateAndThrowAsync(request, cancellationToken);

            var entity = request.ToModel();
            await _enderecoRepository.AtualizarAsync(request.Id, entity);

            return new(entity.Id);
        }
    }
}
