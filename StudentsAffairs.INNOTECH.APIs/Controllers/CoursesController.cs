namespace StudentsAffairs.INNOTECH.APIs.Controllers;

public class CoursesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CoursesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<CourseToReturnDto>> CreateCourse
        ([FromBody] AddCourseDto createdCourse)
    {
        var course = _mapper.Map<AddCourseDto, Course>(createdCourse);

        var isCourseExist = await _unitOfWork.GetCourseRepository().IsCourseExist(course);
        if (isCourseExist) return BadRequest(new ApiResponse(400, "Course already exist"));

        var isdepartmentExist =
            await _unitOfWork.GetDepartmentRepository().IsDepartmentWithIdExist(course.DepartmentId);
        if (!isdepartmentExist)
            return BadRequest(new ApiResponse(400, "Department does not exist"));

        await _unitOfWork.Repository<Course>().AddAsync(course);
        await _unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
    }


    [HttpGet]
    public async Task<ActionResult<Pagination<CourseToReturnDto>>> GetCourses
        ([FromQuery] CourseSpecificationParams specificationParams)
    {
        var spec = new CourseWithDepartmentSpecification(specificationParams);
        var courses = await _unitOfWork.Repository<Course>().GetAllWithSpecificationAsync(spec);
        var data = _mapper.Map<IReadOnlyList<Course>, IReadOnlyList<CourseToReturnDto>>(courses);
        var countSpec = new CourseWithFiltrationForCountSpecification(specificationParams);
        var count = await _unitOfWork.Repository<Course>().GetCountAsync(countSpec);
        return Ok(new Pagination<CourseToReturnDto>(specificationParams.PageIndex, specificationParams.PageSize, count, data));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<CourseToReturnDto>> GetCourse([FromRoute] int id)
    {
        var spec = new CourseWithDepartmentSpecification(id);
        var course = await _unitOfWork.Repository<Course>().GetByIdWithSpecificationAsync(spec);
        if (course is null) return NotFound(new ApiResponse(404));
        return Ok(_mapper.Map<Course, CourseToReturnDto>(course));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCourse
        ([FromBody] UpdateCourseDto courseToUpdate)
    {
        var course = await _unitOfWork.Repository<Course>().GetByIdAsync(courseToUpdate.Id);
        if (course is null) return NotFound(new ApiResponse(404));
        _mapper.Map(courseToUpdate, course);
        _unitOfWork.Repository<Course>().Update(course);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteCourse([FromRoute] int id)
    {
        var course = await _unitOfWork.Repository<Course>().GetByIdAsync(id);
        if (course is null) return NotFound(new ApiResponse(404));
        _unitOfWork.Repository<Course>().Delete(course);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }
}
