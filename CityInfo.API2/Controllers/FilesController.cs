using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API2.Controllers
{

    [Route("api/files")]
 //   [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {


        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(
            FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
                ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider));
        }

        [HttpGet("{fileID}")]
        public ActionResult GetFile(string fileID)
        {
            //FileContentResult    //po file result klasi 
            // FileStreamResult  //stream to read from +content type
            //   PhysicalFileResult
            //   VirtualFileResult //ta dva pustaju da propustis ime fajla i content type(tip sadrzaja)
            //sve to moze ali lakse je sad


            //look up the actual file,depending on the fileId
            var pathToFile = "Format response data in ASP.NET Core Web API _ Microsoft Learn.html"; //radi !
            //opciono
            //var pathToFile = "greske.txt";


            //check whether the file exists
            if (!System.IO.File.Exists(pathToFile))
            { 
            return NotFound();
            }

            if (!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType)) 
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);

           
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
