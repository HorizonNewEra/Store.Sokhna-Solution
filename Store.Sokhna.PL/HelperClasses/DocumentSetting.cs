namespace Store.Sokhna.PL.HelperClasses
{
    public class DocumentSetting
    {
        public static string Upload(IFormFile file,string foldername)
        {
            string filenewname = $"{Guid.NewGuid()}{file.FileName.ToLower()}";
            string filepath=Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\media\\{foldername}", filenewname);
            
            using var FileStream= new FileStream(filepath, FileMode.Create);
            file.CopyTo(FileStream);
            return filenewname;
        }
        public static void Delete(string filename, string foldername)
        {
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\media\\{foldername}", filename);
            if (File.Exists(filepath))
                File.Delete(filepath);
        }
    }
}
