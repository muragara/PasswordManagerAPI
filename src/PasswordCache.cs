using System.Runtime.Caching;
using System.Text;

namespace PasswordManagerAPI;

public class PasswordCache{
    private MemoryCache cache;

    public PasswordCache(){
        this.cache = new MemoryCache("PasswordCache");
    }

    public void AddPassword(Password password){
        if(this.cache.Get(password.id.ToString()) is null)
            this.cache.Add(password.id.ToString(), password, MemoryCache.InfiniteAbsoluteExpiration);
        else
            UpdatePassword(password);
    }

    public Password GetPassword(int id){
        Password password = this.cache.Get(id.ToString()) as Password;
        return password;
    }

    public List<Password> GetPasswords(){
        List<Password> passwordList = new List<Password>();
        foreach(var password in this.cache.ToList()){
            passwordList.Add((Password)password.Value);
        }
        return passwordList;
    }
   
    public Password GetPasswordDecrypted(int id){
        Password password = (Password)this.cache.Get(id.ToString());
        byte[] data = Convert.FromBase64String(password.encryptedPassword);
        password.encryptedPassword = Encoding.UTF8.GetString(data);
        return password;
    }

    public void UpdatePassword(Password password){
        if(this.cache.Get(password.id.ToString()) is not null)
            this.cache.Set(password.id.ToString(), password, DateTimeOffset.MaxValue);
    }

    public void DeletePassword(int id){
        this.cache.Remove(id.ToString());
    }

}