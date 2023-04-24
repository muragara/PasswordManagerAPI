using Microsoft.AspNetCore.Mvc;

namespace PasswordManagerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PasswordController {
    private static readonly Lazy<PasswordCache> Singleton =
        new Lazy<PasswordCache>(() => new PasswordCache());

    public PasswordCache cache { get { return Singleton.Value; } }


    //1. Add the users encrypted password to the list of users password store.
    [HttpPost("AddPassword")]
    public void AddPassword(Password password){
        this.cache.AddPassword(password);
    }

    //3. Get a single item from the password store.
    [HttpGet("GetPassword")]
    public Password GetPassword([FromQuery] int id){
        return this.cache.GetPassword(id);
    }

    //2. Get the list of all passwords for the user.
    [HttpGet("GetPasswords")]
    public List<Password> GetPasswords(){
        return this.cache.GetPasswords();
    }

    // 3. Get a single item from the password store with password decyrpted.
    [HttpGet("GetPasswordDecrypted")]
    public Password GetPasswordDecrypted(int id){
        return this.cache.GetPasswordDecrypted(id);
    }

    //4. Update a password store item.
    [HttpPut("UpdatePassword")]
    public void UpdatePassword(Password password){
        this.cache.UpdatePassword(password);
    }

    //5. Delete a password store item.
    [HttpDelete("DeletePassword")]
    public void DeletePassword(int id){
        this.cache.DeletePassword(id);
    }

} 