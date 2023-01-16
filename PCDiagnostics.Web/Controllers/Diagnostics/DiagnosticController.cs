using Microsoft.AspNetCore.Mvc;
using PCDiagnostics.Core.Domains.Diagnostics;
using PCDiagnostics.Core.Domains.Diagnostics.Services;
using PCDiagnostics.Web.Controllers.Diagnostics.Dto;

namespace PCDiagnostics.Web.Controllers.Diagnostics;

[ApiController]
[Route("diagnostic")]
public class DiagnosticController
{
	private readonly IDiagnosticService _diagnosticService;

	public DiagnosticController(IDiagnosticService diagnosticService)
	{
		_diagnosticService = diagnosticService;
	}

	[HttpPost]
	public async Task<DiagnosticDto> Create(DiagnosticDto model, CancellationToken cancellationToken)
	{
		var res = await _diagnosticService.CreateAsync(new Diagnostic()
		{
			CheckTime = model.CheckTime
		}, cancellationToken);

		return new DiagnosticDto()
		{
			Id = res.Id,
			CheckTime = res.CheckTime
		};
	}

	[HttpDelete("{id}")]
	public Task Delete(Guid id, CancellationToken cancellationToken)
	{
		return _diagnosticService.DeleteAsync(id, cancellationToken);
	}

	[HttpPut("{id}")]
	public Task Update(DiagnosticDto model, Guid id, CancellationToken cancellationToken)
	{
		return _diagnosticService.UpdateAsync(new Diagnostic()
		{
			Id = model.Id,
			CheckTime = model.CheckTime
		}, id, cancellationToken);
	}

	[HttpGet("{id}")]
	public async Task<DiagnosticDto> GetById(Guid id, CancellationToken cancellationToken)
	{
		var model = await _diagnosticService.GetByIdAsync(id, cancellationToken);

		return new DiagnosticDto
		{
			Id = model.Id,
			CheckTime = model.CheckTime
		};
	}

	[HttpGet]
	public async Task<IEnumerable<DiagnosticDto>> GetAll(CancellationToken cancellationToken)
	{
		var models = await _diagnosticService.GetAllAsync(cancellationToken);

		return models.Select(it => new DiagnosticDto()
		{
			Id = it.Id,
			CheckTime = it.CheckTime
		});
	}
}
