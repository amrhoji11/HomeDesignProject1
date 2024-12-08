namespace Landing.PL.Helpers
{
    public class FileProfileSetting
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\fileProfile", folderName);
            string fileName = $"{Guid.NewGuid()}{file.FileName}";
            string filePath = Path.Combine(folderPath, fileName);

            // باستخدام using لضمان إغلاق الملف بعد نسخه
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }

        // ميثود لحذف الصورة من المجلد
        public static void DeleteFile(string fileName, string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\fileProfile", folderName, fileName);
            if (File.Exists(filePath))
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(filePath);
            }
        }
    }
}
