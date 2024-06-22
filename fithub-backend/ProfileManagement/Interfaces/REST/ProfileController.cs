using System.Net.Mime;
using fithub_backend.ProfileManagement.Domain.Model.Queries;
using fithub_backend.ProfileManagement.Domain.Services;
using fithub_backend.ProfileManagement.Interfaces.REST.Resources;
using fithub_backend.ProfileManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace fithub_backend.ProfileManagement.Interfaces.REST;


[ApiController] 
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)] 
public class ProfileController(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
    : ControllerBase
{
    [HttpGet("{profileId:int}")]
    public async Task<IActionResult> GetProfileById(int profileId)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);
        if (profile == null) return NotFound();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfileResource resource)
    {
        var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await profileCommandService.Handle(createProfileCommand);
        if (profile is null) return BadRequest();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new {profileId = profileResource.Id}, profileResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProfiles()
    {
        var getAllProfilesQuery = new GetAllProfilesQuery();
        var profiles = await profileQueryService.Handle(getAllProfilesQuery);
        var profileResources = profiles.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);   
        return Ok(profileResources);
    }
}