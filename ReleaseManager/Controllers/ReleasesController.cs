using Microsoft.AspNetCore.Mvc;

namespace ReleaseManager.Controllers;

[Route("api/release")]
[ApiController]
public class ReleasesController(IReleaseService releasesService) : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetReleaseById(Guid id)
    {
        try
        {
            return Ok(releasesService.GetReleaseById(id));
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("names")]
    public IActionResult GetReleasesName()
    {
        try
        {
            return Ok(releasesService.GetReleasesName());
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    [Route("new")]
    public IActionResult CreateRelease(Release release)
    {
        try
        {
            return Ok(releasesService.CreateRelease(release));
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [Route("task")]
    public IActionResult UpdateTask(ReleaseTaskInfo taskInfo)
    {
        try
        {
            return Ok(releasesService.UpdateTask(taskInfo));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound();
        }
    }
}
