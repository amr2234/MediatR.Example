using MediatR.Domain.Entities;
using MediatR.Domain.Interfaces.Features;
using MediatR.Domain.Interfaces.Persistence;
using MediatR.Example.Commands;


namespace MediatR.Example.Handlers
{

    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductAppSerives _ProductAppSerives;
        private readonly IUnitofWORk _UnitOfWork;

        public DeleteProductHandler(IProductAppSerives productAppSerives, IUnitofWORk unitOfWork)
        {
            _ProductAppSerives = productAppSerives;
            _UnitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            await _ProductAppSerives.Delete(request.Id);
            _UnitOfWork.Commit();
            return request.Id;
        }
    }
}
