using LazZiya.ImageResize;
using Microsoft.AspNetCore.Http;
using System.Drawing;
namespace DairElAnbaBeshoy.Core.Manager
{
    public static class FileManger
    {
        public static string UploadPhoto( IFormFile PhotoFile , string PhysicalPath , int Width , int Height )
        {
            var img = Image.FromStream( PhotoFile.OpenReadStream( ) );
            var ScaleImage = ImageResize.Scale( img , Width , Height );
            int _min = 100;
            int _max = 999;
            Random _rdm = new Random( );
            int guid = _rdm.Next( _min , _max );
            string photopath = Directory.GetCurrentDirectory( ) + "/wwwroot" + PhysicalPath;
            string photoname = guid + Path.GetFileName( PhotoFile.FileName );
            string finalpath = photopath + photoname;
            SaveImage.SaveAs( ScaleImage , finalpath );

            return photoname;
        }
        public static string UploadFile( IFormFile File , string PhysicalPath )
        {
            string FilePath = Directory.GetCurrentDirectory( ) + PhysicalPath;
            string FileName = Path.GetFileName( File.FileName );
            string finalpath = FilePath + FileName;
            using ( var stream = System.IO.File.Create( finalpath ) )
            {
                File.CopyTo( stream );
            }

            return FileName;
        }
        public static bool DeleteFile( string filePath )
        {
            try
            {
                // Check if file exists with its full path
                if ( File.Exists( filePath ) )
                {
                    // If file found, delete it
                    File.Delete( filePath );
                    return true;
                }
                return false;
            }
            catch ( IOException ioExp )
            {
                Console.WriteLine( ioExp.Message );
                return false;
            }
        }
    }
}
