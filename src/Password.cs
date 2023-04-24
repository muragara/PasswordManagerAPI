using System.Text.Json;

namespace PasswordManagerAPI;

public class Password{
    public int id {get; set;}
    public string category {get; set;}
    public string app {get; set;}
    public string username {get; set;}
    public string encryptedPassword {get; set;}

    public Password(int id, string category, string app, string username, string encryptedPassword){
        this.id = id;
        this.category = category;
        this.app = app;
        this.username = username;
        this.encryptedPassword = encryptedPassword;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}