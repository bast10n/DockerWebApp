using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace dockerWebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly UserContext _context;
    public UsersController(ILogger<UsersController> logger, UserContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{guid}")]
    public async Task<ActionResult<User>> GetUser(Guid guid)
    {
        var user = await _context.Users.FindAsync(guid);        
        if (user == null) return NotFound();
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> AddUser(User user)
    {
        if (user.Guid.ToString().Length < 5)
        {
            user.Guid = Guid.NewGuid();
        }
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new {guid = user.Guid}, user);
    }

    [HttpPut("{guid}")]
    public async Task<ActionResult> UpdateUser(Guid guid, User user)
    {
        if (guid != user.Guid) return BadRequest();
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{guid}")]
    public async Task<ActionResult> DeleteUser(Guid guid)
    {
        var user = await _context.Users.FindAsync(guid);        
        if (user == null) return NotFound();
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}