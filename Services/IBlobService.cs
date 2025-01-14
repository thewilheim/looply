using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace looply.Services
{
    public interface IBlobService
    {
        Task<Uri> UploadAsync(Stream stream, string contentType);
        Task<FileResponse> DownloadAsync(Guid fileId);
        Task DeleteAsync(Guid fileId);
    }
}

public record FileResponse(Stream stream, string contentType);