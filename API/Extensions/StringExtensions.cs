namespace API.Extensions
{
    public static class StringExtensions
    {
        public static string TransformGenre(this string genre){
            return genre.ToUpper();
        }
    }
}