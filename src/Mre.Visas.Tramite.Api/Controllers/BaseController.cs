﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Mre.Visas.Tramite.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public abstract class BaseController : ControllerBase
  {
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
  }
}