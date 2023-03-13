namespace dotNetflixServiceServer.Services
{
    public interface IHashPassword
    {
        public string Hash(string pass);
    }
}
