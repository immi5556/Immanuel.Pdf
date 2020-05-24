using System;

namespace NetCore.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = System.IO.Directory.GetCurrentDirectory(); 
            byte[] file = Resource1.wkhtmltopdf; 
            CMemoryExecute.Run(file, dir, "-B 25mm -T 25mm --footer-spacing 5 --footer-html 'footer.html' 'http://www.tamil-bible.com/lookup.php?Book=Romans&Chapter=11' lordjesus.pdf");
        }
    }
}
