#pragma checksum "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\EmployeeTaskArea\EmployeeTaskListByProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45b552a968b28f52ba4b3ccb758b6c2e5c8695c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Employee_Views_EmployeeTaskArea_EmployeeTaskListByProfile), @"mvc.1.0.view", @"/Areas/Employee/Views/EmployeeTaskArea/EmployeeTaskListByProfile.cshtml")]
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
#line 1 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\_ViewImports.cshtml"
using CrmUpSchool.UILayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\_ViewImports.cshtml"
using CrmUpSchool.UILayer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\_ViewImports.cshtml"
using CrmUpSchool.EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45b552a968b28f52ba4b3ccb758b6c2e5c8695c8", @"/Areas/Employee/Views/EmployeeTaskArea/EmployeeTaskListByProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3aa0f20dcbd6df4ca6b0c7c436233d1145dc4e1", @"/Areas/Employee/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Employee_Views_EmployeeTaskArea_EmployeeTaskListByProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EmployeeTask>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\EmployeeTaskArea\EmployeeTaskListByProfile.cshtml"
  
    ViewData["Title"] = "EmployeeTaskListByProfile";
    Layout = "~/Views/Shared/_EmployeeLayout.cshtml";
    int count = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Görevleriniz</h3>\r\n\r\n<table class=\"table table-bordered\">\r\n    <tr>\r\n        <th>#</th>\r\n        <th>Başlık</th>\r\n        <th>Durum</th>\r\n        <th>Tarih</th>\r\n        <th>Detaylar</th>\r\n        <th>Yeni İşlem</th>\r\n  \r\n    </tr>\r\n");
#nullable restore
#line 20 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\EmployeeTaskArea\EmployeeTaskListByProfile.cshtml"
     foreach (var item in Model)
    {
        count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 24 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\EmployeeTaskArea\EmployeeTaskListByProfile.cshtml"
           Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\EmployeeTaskArea\EmployeeTaskListByProfile.cshtml"
           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\EmployeeTaskArea\EmployeeTaskListByProfile.cshtml"
           Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\EmployeeTaskArea\EmployeeTaskListByProfile.cshtml"
           Write(item.Date.ToString("dd.MMM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n          \r\n          \r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 672, "\"", 734, 2);
            WriteAttributeValue("", 679, "/Employee/EmployeeTaskDetail/Index/", 679, 35, true);
#nullable restore
#line 30 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\EmployeeTaskArea\EmployeeTaskListByProfile.cshtml"
WriteAttributeValue("", 714, item.EmployeeTaskID, 714, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-success\">Detaylar</a></td>\r\n            <td><a href=\"#\" class=\"btn btn-outline-dark\">Yeni İşlem</a></td>\r\n        </tr>\r\n");
#nullable restore
#line 33 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\EmployeeTaskArea\EmployeeTaskListByProfile.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n\r\n\r\n\r\n");
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
