using Test.Data.Context;
using Test.Data.Model;
using Test.Data.Response;
using Test.Data.Request;
using Microsoft.EntityFrameworkCore;
using static Test.Data.Services.PagoServices;

namespace Test.Data.Services;

public class PagoServices : IPagoServices
{
    private readonly IMyDbContext dbContext;

    public PagoServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<List<FacturaPagoResponse>>> Consultar(string filtro)
    {
        try
        {
            var contactos = await dbContext.FacturaPagos
                .Where(c =>
                    (c.Observacion)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
            return new Result<List<FacturaPagoResponse>>()
            {
                Message = "Ok",
                Success = true,
                Data = contactos
            };
        }
        catch (Exception E)
        {
            return new Result<List<FacturaPagoResponse>>
            {
                Message = E.Message,
                Success = false
            };
        }
    }

    public async Task<Result> Crear(FacturaPagoRequest request)
    {
        try
        {
            var contacto = FacturaPago.Crear(request);
            dbContext.FacturaPagos.Add(contacto);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(FacturaPagoRequest request)
    {
        try
        {
            var contacto = await dbContext.FacturaPagos
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return new Result() { Message = "No se encontro el pago", Success = false };

            if (contacto.Mofidicar(request))
                await dbContext.SaveChangesAsync();

            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }

    public async Task<Result> Eliminar(FacturaPagoRequest request)
    {
        try
        {
            var contacto = await dbContext.FacturaPagos
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return new Result() { Message = "No se encontro el pago", Success = false };

            dbContext.FacturaPagos.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };

        }
    }

}

public interface IPagoServices
{
    Task<Result<List<FacturaPagoResponse>>> Consultar(string filtro);
    Task<Result> Crear(FacturaPagoRequest request);
    Task<Result> Modificar(FacturaPagoRequest request);
    Task<Result> Eliminar(FacturaPagoRequest request);
}