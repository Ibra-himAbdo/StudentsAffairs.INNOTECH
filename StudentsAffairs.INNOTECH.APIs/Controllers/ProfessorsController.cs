namespace StudentsAffairs.INNOTECH.APIs.Controllers;

public class ProfessorsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProfessorsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreateProfessor([FromBody] AddProfessorDto professorToCreateDto)
    {
        var professor = _mapper.Map<AddProfessorDto, Professor>(professorToCreateDto);
        var IsProfessorExist = await _unitOfWork.GetProfessorRepository().IsProfessorExist(professor);
        if (IsProfessorExist)
            return BadRequest(new ApiResponse(400, "Professor already exist"));

        var IsDepartmentExist = await _unitOfWork.GetDepartmentRepository().IsDepartmentWithIdExist(professor.DepartmentId);
        if (!IsDepartmentExist)
            return BadRequest(new ApiResponse(400, "Department does not exist"));

        await _unitOfWork.Repository<Professor>().AddAsync(professor);
        await _unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id }, professor);
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<ProfessorToReturnDto>>> GetAllProfessors
        ([FromQuery] ProfessorSpecificationParams specificationParams)
    {
        var spec = new ProfessorWithDepartmentSpecification(specificationParams);
        var professors = await _unitOfWork.Repository<Professor>().GetAllWithSpecificationAsync(spec);
        var data = _mapper.Map<IReadOnlyList<Professor>, IReadOnlyList<ProfessorToReturnDto>>(professors);
        var countSpec = new ProfessorWithFiltrationForCountSpecification(specificationParams);
        var count = await _unitOfWork.Repository<Professor>().GetCountAsync(countSpec);
        return Ok(new Pagination<ProfessorToReturnDto>(specificationParams.PageIndex, specificationParams.PageSize, count, data));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ProfessorToReturnDto>> GetProfessor([FromRoute] int id)
    {
        var spec = new ProfessorWithDepartmentSpecification(id);
        var professor = await _unitOfWork.Repository<Professor>().GetByIdWithSpecificationAsync(spec);
        if (professor is null) return NotFound(new ApiResponse(404));
        return Ok(_mapper.Map<Professor, ProfessorToReturnDto>(professor));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProfessor
        ([FromBody] UpdateProfessorDto professorToUpdateDto)
    {
        var professor = await _unitOfWork.Repository<Professor>().GetByIdAsync(professorToUpdateDto.Id);
        if (professor is null) return NotFound(new ApiResponse(404));
        _mapper.Map(professorToUpdateDto, professor);
        _unitOfWork.Repository<Professor>().Update(professor);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteProfessor([FromRoute] int id)
    {
        var professor = await _unitOfWork.Repository<Professor>().GetByIdAsync(id);
        if (professor is null) return NotFound(new ApiResponse(404));

        _unitOfWork.Repository<Professor>().Delete(professor);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

}
