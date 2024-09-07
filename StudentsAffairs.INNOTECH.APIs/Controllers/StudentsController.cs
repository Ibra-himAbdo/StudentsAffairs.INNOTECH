namespace StudentsAffairs.INNOTECH.APIs.Controllers;
public class StudentsController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public StudentsController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateStudent([FromBody] StudentToCreateDto studentToCreateDto)
    {
        var student = _mapper.Map<StudentToCreateDto, Student>(studentToCreateDto);
        var IsStudentExist = await _unitOfWork.GetStudentRepository().IsStudentExist(student);
        if (IsStudentExist) return BadRequest(new ApiResponse(400, "Student already exist"));

        var IsDepartmentExist = await _unitOfWork.GetDepartmentRepository().IsDepartmentWithIdExist(student.DepartmentId);
        if (!IsDepartmentExist) return BadRequest(new ApiResponse(400, "Department does not exist"));

        await _unitOfWork.Repository<Student>().AddAsync(student);
        var success = await _unitOfWork.CompleteAsync();
        return Ok(success);
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<StudentToReturnDto>>> GetStudents
        ([FromQuery] StudentSpecificationParams specificationParams)
    {
        var spec = new StudentWithEnrollmentsAndDepartmentSpecification(specificationParams);
        //var students = await _studentRepo.GetAllWithSpecificationAsync(spec);
        var students = await _unitOfWork.Repository<Student>().GetAllWithSpecificationAsync(spec);

        var data = _mapper.Map<IReadOnlyList<Student>, IReadOnlyList<StudentToReturnDto>>(students);

        var countSpec = new StudentWithFiltrationForCountSpecification(specificationParams);
        //var count = await _studentRepo.GetCountAsync(countSpec);
        var count = await _unitOfWork.Repository<Student>().GetCountAsync(countSpec);

        return Ok(new Pagination<StudentToReturnDto>(specificationParams.PageIndex, specificationParams.PageSize, count, data));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<StudentToReturnDto>> GetStudent([FromRoute] int id)
    {
        var spec = new StudentWithEnrollmentsAndDepartmentSpecification(id);
        //var student = await _studentRepo.GetByIdWithSpecificationAsync(spec);
        var student = await _unitOfWork.Repository<Student>().GetByIdWithSpecificationAsync(spec);
        if (student is null) return NotFound(new ApiResponse(404));
        return Ok(_mapper.Map<Student, StudentToReturnDto>(student));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateStudent([FromBody] UpdateStudentDto studentToUpdate)
    {
        var student = await _unitOfWork.Repository<Student>().GetByIdAsync(studentToUpdate.Id);
        if (student is null) return NotFound(new ApiResponse(404));
        _mapper.Map(studentToUpdate, student);
        _unitOfWork.Repository<Student>().Update(student);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteStudent([FromRoute] int id)
    {
        var student = await _unitOfWork.Repository<Student>().GetByIdAsync(id);
        if (student is null) return NotFound(new ApiResponse(404));
        _unitOfWork.Repository<Student>().Delete(student);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }


}
