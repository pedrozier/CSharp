using MediatR;

namespace ControleEndereco.AppCore.Commands.DeletarEndereco
{
    public record DeletarEnderecoCommand(long Id) : IRequest<DeletarEnderecoResult>;
}
