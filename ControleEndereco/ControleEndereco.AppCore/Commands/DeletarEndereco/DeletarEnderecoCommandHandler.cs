using ControleEndereco.AppCore.Commands.DeletarEndereco;
using ControleEndereco.Domain.Interfaces.Repositories;
using MediatR;

public class DeletarEnderecoCommandHandler : IRequestHandler<DeletarEnderecoCommand, DeletarEnderecoResult>
{
    private readonly IEnderecoRepository _enderecoRepository;

    public DeletarEnderecoCommandHandler(IEnderecoRepository enderecoRepository)
    {
        _enderecoRepository = enderecoRepository;
    }

    public async Task<DeletarEnderecoResult> Handle(DeletarEnderecoCommand request, CancellationToken cancellationToken)
    {
        await _enderecoRepository.DeletarAsync(request.Id);

        return new DeletarEnderecoResult(true);
    }
}
