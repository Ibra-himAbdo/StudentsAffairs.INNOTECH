namespace StudentsAffairs.INNOTECH.APIs.Controllers;

public class DepartmentsController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentsController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<ActionResult> CreateDepartment
        ([FromBody] AddDepartmentDto departmentToCreateDto)
    {
        var department = _mapper.Map<AddDepartmentDto, Department>(departmentToCreateDto);
        var result = await _unitOfWork.GetDepartmentRepository().IsDepartmentExist(department);
        if (result) return BadRequest(new ApiResponse(400, "Department already exist"));

        await _unitOfWork.Repository<Department>().AddAsync(department);
        await _unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<DepartmentToReturnDto>>> GetAllDepartments
        ([FromQuery] SpecificationParams specificationParams)
    {
        var spec = new DepartmentSpecifications(specificationParams);
        var departments = await _unitOfWork.Repository<Department>().GetAllWithSpecificationAsync(spec);
        var data = _mapper.Map<IReadOnlyList<Department>, IReadOnlyList<DepartmentToReturnDto>>(departments);
        var countSpec = new DepartmentWithFiltrationForCountSpecification(specificationParams);
        var count = await _unitOfWork.Repository<Department>().GetCountAsync(countSpec);
        return Ok(new Pagination<DepartmentToReturnDto>(specificationParams.PageIndex, specificationParams.PageSize, count, data));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<DepartmentToReturnDto>> GetDepartment([FromRoute] int id)
    {
        var spec = new DepartmentSpecifications(id);
        var department = await _unitOfWork.Repository<Department>().GetByIdWithSpecificationAsync(spec);
        if (department is null) return NotFound(new ApiResponse(404));
        return Ok(_mapper.Map<Department, DepartmentToReturnDto>(department));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateDepartment
        ([FromBody] UpdateDepartmentDto departmentToUpdateDto)
    {
        var department = await _unitOfWork.Repository<Department>().GetByIdAsync(departmentToUpdateDto.Id);
        if (department is null) return NotFound(new ApiResponse(404));
        _mapper.Map(departmentToUpdateDto, department);
        _unitOfWork.Repository<Department>().Update(department);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteDepartment([FromRoute] int id)
    {
        var department = await _unitOfWork.Repository<Department>().GetByIdAsync(id);
        if (department is null)
            return NotFound(new ApiResponse(404, $"Department with id: '{id}' not found"));

        _unitOfWork.Repository<Department>().Delete(department);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }
}
