#pragma checksum "C:\Users\AlumnoMCSD\Documents\Azure\MvcStorageFile\MvcStorageFile\Views\AzureFile\ReadFile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1b5ad01ca82f8fe443132fb5430192b704babde"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AzureFile_ReadFile), @"mvc.1.0.view", @"/Views/AzureFile/ReadFile.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\AlumnoMCSD\Documents\Azure\MvcStorageFile\MvcStorageFile\Views\_ViewImports.cshtml"
using MvcStorageFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\AlumnoMCSD\Documents\Azure\MvcStorageFile\MvcStorageFile\Views\_ViewImports.cshtml"
using MvcStorageFile.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1b5ad01ca82f8fe443132fb5430192b704babde", @"/Views/AzureFile/ReadFile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abd7cb41b881e00c6c933d21709a8d7e60e83e0d", @"/Views/_ViewImports.cshtml")]
    public class Views_AzureFile_ReadFile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\AlumnoMCSD\Documents\Azure\MvcStorageFile\MvcStorageFile\Views\AzureFile\ReadFile.cshtml"
  
    ViewData["Title"] = "ReadFile";
    String valor = ViewData["text"] as String;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>ReadFile</h1>\r\n\r\n<p>\r\n    ");
#nullable restore
#line 10 "C:\Users\AlumnoMCSD\Documents\Azure\MvcStorageFile\MvcStorageFile\Views\AzureFile\ReadFile.cshtml"
Write(valor);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
