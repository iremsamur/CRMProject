#pragma checksum "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\EmployeeTask\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68dd6eeada5d7efbdeaafeb74125c31b4fb69c62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EmployeeTask_Index), @"mvc.1.0.view", @"/Views/EmployeeTask/Index.cshtml")]
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
#line 1 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\_ViewImports.cshtml"
using CrmUpSchool.UILayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\_ViewImports.cshtml"
using CrmUpSchool.UILayer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\_ViewImports.cshtml"
using CrmUpSchool.EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68dd6eeada5d7efbdeaafeb74125c31b4fb69c62", @"/Views/EmployeeTask/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3aa0f20dcbd6df4ca6b0c7c436233d1145dc4e1", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_EmployeeTask_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EmployeeTask>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\EmployeeTask\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_CrmLayout.cshtml";
    int count = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h3>Görev Listesi</h3>

<table class=""table table-bordered"">
    <tr>
        <th>#</th>
        <th>Başlık</th>
        <th>Durum</th>
        <th>Tarih</th>
        <th>Görevin Sorumlu Olduğu Personel</th>
        <th>Görevi Atayan Kişi</th>
        <th>Sil</th>
        <th>Güncelle</th>
        <th>Detaylar</th>
    </tr>
");
#nullable restore
#line 22 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\EmployeeTask\Index.cshtml"
     foreach (var item in Model)
    {
        count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 26 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\EmployeeTask\Index.cshtml"
           Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\EmployeeTask\Index.cshtml"
           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\EmployeeTask\Index.cshtml"
           Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 29 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\EmployeeTask\Index.cshtml"
           Write(item.Date.ToString("dd.MMM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 30 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\EmployeeTask\Index.cshtml"
           Write(item.AssigneeUser.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 30 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\EmployeeTask\Index.cshtml"
                                   Write(item.AssigneeUser.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 31 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\EmployeeTask\Index.cshtml"
           Write(item.FollowerUser.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 31 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\EmployeeTask\Index.cshtml"
                                   Write(item.FollowerUser.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td><a href=\"#\" class=\"btn btn-outline-danger\">Sil</a></td>\r\n            <td><a href=\"#\" class=\"btn btn-outline-success\">Güncelle</a></td>\r\n            <td><a href=\"#\" class=\"btn btn-outline-dark\">Detaylar</a></td>\r\n        </tr>\r\n");
#nullable restore
#line 36 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Views\EmployeeTask\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n<a href=\"/EmployeeTask/AddTask/\" class=\"btn btn-outline-info\">Yeni Görev Girişi</a>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<EmployeeTask>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
