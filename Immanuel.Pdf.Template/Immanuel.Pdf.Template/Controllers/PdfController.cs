using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Immanuel.Pdf.Template.Controllers
{
    public class PdfController : ApiController
    {
        public HttpResponseMessage ConvertHtmlToPdf()
        {
            string html = @"<page id='a4-doc' size='A4'>A4<div style='width: 100px; height: 100px; border: 1px solid red; position: absolute; left: 568px; top: 293.281px;' class='ina4'></div><div class='ina4' style='width: 100px; height: 100px; border: 1px solid red; position: absolute; left: 480.344px; top: 138.563px;'></div></page>";
            PdfSharp.Pdf.PdfDocument pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.Letter);
            //pdf.Save("document.pdf");
            byte[] arr = null;
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                pdf.Save(stream, true);
                arr = stream.ToArray();
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            //byte[] arr = System.IO.File.ReadAllBytes(pPath);
            response.Content = new StreamContent(new System.IO.MemoryStream(arr));
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentLength = arr.Length;
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = "Transformed.pdf"
            };

            return response;
        }
     }
}