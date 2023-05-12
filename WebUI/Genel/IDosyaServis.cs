namespace WebUI.Genel {
    public interface IDosyaServis {
        Stream GetFileStream(string path);
        FileServiceFileInfo GetFileInfo(string path);
        Task<FileServiceFileInfo> DosyaKaydet(Stream fileStream, string mimeType);
        Task<FileServiceFileInfo> DosyaKaydet(byte[] file, string mimeType);
        void DosyaSil(string path);
    }

    public struct FileServiceFileInfo {
        public readonly string RelativePath;
        public readonly string FullPath;

        public FileServiceFileInfo(string relativePath, string fullPath) : this() {
            RelativePath = relativePath;
            FullPath = fullPath;
        }
    }
}
