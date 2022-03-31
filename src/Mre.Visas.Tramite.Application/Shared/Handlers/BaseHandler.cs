using AutoMapper;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Security;

namespace Mre.Visas.Tramite.Application.Shared.Handlers
{
  public abstract class BaseHandler
  {
    protected BaseHandler()
    {
    }

    protected BaseHandler(IUnitOfWork unitOfWork)
    {
      UnitOfWork = unitOfWork;
    }
    protected BaseHandler(IUnitOfWork unitOfWork, ITokenAcceso tokenAcceso, INotificadorClient notificadorClient)
    {
      UnitOfWork = unitOfWork;
      NotificadorClient = notificadorClient;
      TokenAcceso = tokenAcceso;
    }

    protected BaseHandler(IMapper mapper)
    {
      Mapper = mapper;
    }

    protected BaseHandler(INotificadorClient notificadorClient)
    {
      NotificadorClient = notificadorClient;
    }
    protected BaseHandler(ITokenAcceso tokenAcceso)
    {
      TokenAcceso = tokenAcceso;
    }

    protected BaseHandler(IMapper mapper, IUnitOfWork unitOfWork, INotificadorClient notificadorClient, ITokenAcceso tokenAcceso)
    {
      Mapper = mapper;
      UnitOfWork = unitOfWork;
      NotificadorClient = notificadorClient;
      TokenAcceso = tokenAcceso;
    }

    protected IUnitOfWork UnitOfWork;

    protected IMapper Mapper;

    protected INotificadorClient NotificadorClient;

    protected ITokenAcceso TokenAcceso;
  }
}