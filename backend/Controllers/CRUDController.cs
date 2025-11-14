using Microsoft.AspNetCore.Mvc;
using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController]
public abstract class CRUDController<TEntity, TKey, TRequestDTO, TResponseDTO> : ControllerBase 
    where TEntity : BaseModel<TEntity, TKey>, new()
    where TRequestDTO : class, ITransferObject<TEntity, TKey, TRequestDTO>, new()
    where TResponseDTO : class, ITransferObject<TEntity, TKey, TResponseDTO>, new()
{
    private readonly CRUDService<TEntity, TKey> CRUDService;

    public CRUDController(CRUDService<TEntity, TKey> crudService)
    {
        CRUDService = crudService;
    }

    ////
    // GET ALL
    [HttpGet]
    public async Task<ActionResult<List<TResponseDTO>>> GetAll()
    {
        ServiceResult<List<TEntity>> result = await CRUDService.GetAll();

        if (result.IsError)
        {
            switch (result.Error)
            {
                case ResultError.NotFound:
                    return NotFound();
                case ResultError.NullReturnValue:
                    // TODO: Log null value error
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // Null result value only occurs as error and is handled above
        List<TEntity> entities = result.Value!;

        List<TResponseDTO> responseEntities = new List<TResponseDTO>();
        foreach (TEntity entity in entities)
            responseEntities.Add(TResponseDTO.CreateWithEntity(entity));

        

        return Ok(entities);
    }

    ////
    // GET ONE (ID)
    [HttpGet("{id}")]
    public async Task<ActionResult<TResponseDTO>> GetByKey(TKey key)
    {
        ServiceResult<TEntity> result = await CRUDService.GetByKey(key);

        if (result.IsError)
        {
            switch (result.Error)
            {
                case ResultError.NotFound:
                    return NotFound();
                case ResultError.NullReturnValue:
                    // TODO: Log null value error
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // Null result value only occurs as error and is handled above
        TResponseDTO responseDTO = TResponseDTO.CreateWithEntity(result.Value!);

        return Ok(responseDTO);
    }

    ////
    // POST
    [HttpPost]
    public async Task<IActionResult> Post(TRequestDTO requestDTO)
    {
        // Convert to complete model for service compatibility
        TEntity newEntity = new TEntity();
        requestDTO.CopyFieldsTo(newEntity);
        
        ServiceResult<TEntity> result = await CRUDService.Post(newEntity);

        if (result.IsError)
        {
            switch (result.Error)
            {
                case ResultError.BadRequest:
                    return BadRequest();
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // Null value only occurs as error and is handled above
        TEntity returnedEntity = result.Value!;
        TResponseDTO responseDTO = TResponseDTO.CreateWithEntity(returnedEntity);

        return CreatedAtAction(
                    nameof(Post),
                    new { key = returnedEntity.Key },
                    responseDTO);
    }

    ////
    // PUT
    [HttpPut("{key}")]
    public async Task<IActionResult> Put(TKey key, TRequestDTO requestDTO)
    {
        if (key is null)
            return BadRequest();

        // Convert to Entity to ensure Key property exists
        TEntity newEntity = new TEntity();
        requestDTO.CopyFieldsTo(newEntity);

        if (newEntity.Key is null)
        {
            // DTO may not have key property or DTO.CopyFieldsTo(entity) may not
            // be updating entity key

            // TODO: Log null key property

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
            
        if (key.Equals(newEntity.Key))
            return BadRequest();

        ServiceResult<TEntity> result = await CRUDService.Put(newEntity);

        if (result.IsError)
        {
            switch (result.Error)
            {
                case ResultError.NotFound:
                    return NotFound();
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        return NoContent();
    }

    ////
    // DELETE
    [HttpDelete("{key}")]
    public async Task<IActionResult> Delete(TKey key)
    {
        IServiceResult result = await CRUDService.Delete(key);

        if (result.IsError)
            return StatusCode(StatusCodes.Status500InternalServerError);

        return NoContent();
    }
}