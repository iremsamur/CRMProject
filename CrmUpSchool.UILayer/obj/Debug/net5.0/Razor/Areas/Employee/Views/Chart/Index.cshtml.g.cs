#pragma checksum "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\Chart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1be44bbcb5a5d15a748dc935fbc79eb6fb54e5d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Employee_Views_Chart_Index), @"mvc.1.0.view", @"/Areas/Employee/Views/Chart/Index.cshtml")]
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
#nullable restore
#line 4 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\_ViewImports.cshtml"
using CrmUpSchool.UILayer.Areas.Employee.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1be44bbcb5a5d15a748dc935fbc79eb6fb54e5d8", @"/Areas/Employee/Views/Chart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab1bea9cd889669266f33b394e203953bc038acb", @"/Areas/Employee/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Employee_Views_Chart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Employee\Views\Chart\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_EmployeeLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-7 grid-margin stretch-card"">
        <div class=""card"">
            <div class=""card-body"">
                <p class=""card-title"">Burası Grafik Alanıdır</p>
               
            </div>
        </div>
    </div>
    
</div>
<script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
<script type=""text/javascript"">

    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(DrawonLoad);

    function DrawonLoad() {
        $(function () {
            $.ajax({
                type: 'GET',
                url: '/Employee/Chart/DepartmentChart',
                success: function (chartsdata) {

                    var Data = chartsdata.jsonlist;
                    var data = new google.visualization.DataTable();

                    data.addColumn('string', 'departmentname');
                    data.addColumn('number', 'salaryavg');

                    for (var i =");
            WriteLiteral(@" 0; i < Data.length; i++) {
                        data.addRow([Data[i].departmentname, Data[i].salaryavg]);
                    }

                    var chart = new google.visualization.PieChart(document.getElementById('chartdiv'));

                    chart.draw(data,
                        {
                            title: ""Google Chart Core Projesi"",
                            position: ""top"",
                            fontsize: ""16px""
                        });
                }
            });
        })
    }

</script>


");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591