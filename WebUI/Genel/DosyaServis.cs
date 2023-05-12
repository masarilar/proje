using Microsoft.Extensions.FileProviders;

namespace WebUI.Genel {
    public class DosyaServis : IDosyaServis {
        private readonly IFileProvider FileProvider;
        private readonly string BaseSavePath;

        public DosyaServis(string baseSavePath, IFileProvider fileProvider) {
            FileProvider = fileProvider;
            BaseSavePath = baseSavePath;
        }
        public void DosyaSil(string path) => File.Delete(Path.Combine(BaseSavePath, path));
        public FileServiceFileInfo GetFileInfo(string path) {
            var fileInfo = FileProvider.GetFileInfo(path);
            return new FileServiceFileInfo(path, fileInfo.PhysicalPath);
        }
        public Stream GetFileStream(string path) {
            var fileInfo = FileProvider.GetFileInfo(path);
            return !fileInfo.Exists ? throw new FileNotFoundException() : fileInfo.CreateReadStream();
        }
        public async Task<FileServiceFileInfo> DosyaKaydet(Stream fileStream, string mimeType) {
            var relativeDirectoryPath = DosyaYoluOlustur();
            var fileName = DosyaAdiOlustur();
            var relativePath = Path.Combine(relativeDirectoryPath, $"{fileName}.{mimeType.Split('/')[1]}");
            var fullDirectoryPath = Path.Combine(BaseSavePath, relativeDirectoryPath);
            var fullPath = Path.Combine(BaseSavePath, relativePath);
            if (!Directory.Exists(fullDirectoryPath)) {
                Directory.CreateDirectory(fullDirectoryPath);
            }
            using var fileCreateStream = new FileStream(fullPath, FileMode.Create);
            await fileStream.CopyToAsync(fileCreateStream);
            return new FileServiceFileInfo(relativePath, fullPath);
        }
        public Task<FileServiceFileInfo> DosyaKaydet(byte[] file, string mimeType) {
            using var fileMemoryStream = new MemoryStream(file);
            return DosyaKaydet(fileMemoryStream, mimeType);
        }
        private static string DosyaYoluOlustur() {
            var now = DateTime.Now;
            return Path.Combine(now.Year.ToString(), now.Month.ToString(), now.Day.ToString());
        }
        private static string DosyaAdiOlustur() => Guid.NewGuid().ToString();

    }
}
