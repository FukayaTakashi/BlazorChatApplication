
namespace ChatApplication.Domain.Helperes
{
    public static class RootPath
    {
        public static string GetFullPath(string path)
        {
            if (Path.IsPathFullyQualified(path))
            {
                return Path.GetFullPath(path);
            }
            else
            {
                return Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    path);
            }
        }
    }
}
