#pragma checksum "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Admin\Views\AdminCustomer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18802f03e51b7054ab7fd9aef288d89b11b44af5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminCustomer_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminCustomer/Index.cshtml")]
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
#line 1 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Admin\Views\_ViewImports.cshtml"
using CrmUpSchool.UILayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Admin\Views\_ViewImports.cshtml"
using CrmUpSchool.UILayer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Admin\Views\_ViewImports.cshtml"
using CrmUpSchool.EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Admin\Views\_ViewImports.cshtml"
using Crm.UpSchool.DTOLayer.DTOs.ContactDTOs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18802f03e51b7054ab7fd9aef288d89b11b44af5", @"/Areas/Admin/Views/AdminCustomer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7eb215ee0fc9eb4dd208875cddeac7017fe0e0c0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_AdminCustomer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\User\Desktop\UpSchoolBootcamp\CrmUpSchool.UILayer\CrmUpSchool.UILayer\Areas\Admin\Views\AdminCustomer\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_CrmLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js""></script>


<h1>Müşteri Ajax İşlemleri</h1>
<br />
<button type=""button"" id=""btncustomerlist"" class=""btn btn-outline-dark"" style=""display:inline-block;inline-size:200px;"">Müşteri Listesi</button>
<!--Butonları diğer form elemanlarından ayırt eden özellik id'leridir-->
<button type=""button"" id=""btncustomeradd"" class=""btn btn-outline-primary"" style=""display:inline-block;inline-size:200px;"">Müşteri Ekle</button>
<button type=""button"" id=""btncustomerget"" class=""btn btn-outline-success"" style=""display:inline-block;inline-size:200px;"">Müşteri Getir</button>
<button type=""button"" id=""btncustomerdelete"" class=""btn btn-outline-danger"" style=""display:inline-block;inline-size:200px;"">Müşteri Sil</button>
<button type=""button"" id=""btncustomerupdate"" class=""btn btn-outline-warning"" style=""display:inline-block;inline-size:200px;"">Müşteri Güncelle</button>
<br />
<button type=""button"" id=""btnsweet"" class=""btn btn-outline-info"" style=""displa");
            WriteLiteral(@"y:inline-block;inline-size:200px;"">Sweet Button</button>

<br />

<div id=""customerlist"">
    <!--müşteri listesine tıklanınca müşterilerin geleceği alan burası-->
</div>
<br />
<div class=""form-group"">
    <!--ekleme işlemi-->
    <input type=""text"" id=""txtcustomername"" placeholder=""Müşteri Adını Giriniz"" 
    class=""form-control""/>
    
    <br>
    <input type=""text"" id=""txtcustomersurname"" placeholder=""Müşteri Soyadını Giriniz"" 
           class=""form-control"" />
           <br />
    <input type=""text"" id=""txtcustomermail"" placeholder=""Müşteri Mailini Giriniz"" 
           class=""form-control"" />
           <br />
    <input type=""text"" id=""txtcustomerphone"" placeholder=""Müşteri Telefonunu Giriniz"" 
           class=""form-control"" />
           <br />
</div>
<br />
<!--id'ye göre listeleme için -->
<div class=""form-group"">
    <input  type=""text"" placeholder=""Aranacak ID değerini Giriniz."" id=""txtid"" class=""form-control""/>

</div>
<br />
<div id=""customergetbyid"">
    <!--a");
            WriteLiteral(@"rananın bilgileri buraay gelecek-->
</div>
<div>
    <input type=""text"" class=""form-control"" id=""txtdeleteid"" placeholder=""Silinecek ID değerini giriniz.""/>
</div>
<br />
<div class=""form-group"">
    <h4>Güncelleme Paneli</h4>
    <br />
    <input type=""text"" class=""form-control"" id=""txteditid"" placeholder=""Güncellenecek ID"" />
    <br />
    <input type=""text"" class=""form-control"" id=""txtname"" placeholder=""Güncellenecek Adınız""/>
    <br />
    <input type=""text"" class=""form-control"" id=""txtsurname"" placeholder=""Güncellenecek Soyadınız"" />
    <br />

    <input type=""text"" class=""form-control"" id=""txtmail"" placeholder=""Güncellenecek Mailiniz"" />
    <br />
    <input type=""text"" class=""form-control"" id=""txtphone"" placeholder=""Güncellenecek Telefonunuz"" />

</div>

<script>
    //listeleme işlemi ajax kodu
    $(""#btncustomerlist"").click(function () {
        //butona tıklandığında işlem yapsın 
        $.ajax({
            contentType: ""application/json"",
            dataType: """);
            WriteLiteral(@"json"",
            type: ""get"",
            url: ""/Admin/AdminCustomer/CustomerList/"",
            success: function (funk1) {
                //eğer başarılı olursa
                //funk1 isimli bir fonksiyon beni karşılasın
                let values = jQuery.parseJSON(funk1); //gelen değeri html tarafında json'a dönüştür

                console.log(values);
                //dönen değerleri html tablosunda getirelim

                let tablehtml = ""<table class=table table-bordered> <tr><th>Müşteri ID</th><th>Müşteri Adı</th><th>Müşteri Soyadı</th><th>Müşteri Mail</th></tr>"";
                $.each(values,(index,item)=>{
                    //each burada foreach görevi görüyor
                    //item verileri aşağıda çağırmamızı sağlar
                    tablehtml+=`<tr><td id=customerID>${item.CustomerID}</td> <td>${item.CustomerName}</td> <td>${item.CustomerSurname}</td>
                    <td>${item.CustomerMail}</td></tr>`
                    //alt gr+; ile javascririptteki ver");
            WriteLiteral(@"ileri çekebiliriz
                    //{} içinde item. veritabanındaki kolonun adı

                });
                tablehtml+=""</table>"";
                //verileri yansıtacağım yeri belirtiyorum
                $(""#customerlist"").html(tablehtml);//tablehtml'den gelen tablo değerini
                //bu id'si yazan div içinde gösterecek


            }
        });
    });
    //ekleme işlemi
    $(""#btncustomeradd"").click(function(){
        let customervalues={
            CustomerName:$(""#txtcustomername"").val(),//html elemanına inputa girilen değeri alır
            //modele atar. CustomerName modeldeki karşılığı entitydeki adı
            CustomerSurname:$(""#txtcustomersurname"").val(),
            CustomerMail: $(""#txtcustomermail"").val(),
            CustomerPhone: $(""#txtcustomerphone"").val()


        };
        $.ajax({
            type:""post"",
            url:""/Admin/AdminCustomer/AddCustomer/"",//işlemi yapan controller url'ı
            
            data:customerval");
            WriteLiteral(@"ues,
            success:function(funk2){
                let result = JQuery.parseJSON(funk2);
                alert(""Müşteri başarılı bir şekilde eklendi."");
            }
        });
    });
    //id'ye göre getirme
    $(""#btncustomerget"").click(x=>{
        let id=$(""#txtid"").val();
        $.ajax({
            contentType:""application/json"",
            dataType:""json"",
            type:""get"",
            url:""/Admin/AdminCustomer/GetByID/"",
            data:{CustomerID:id},//bu CustomerID hem sql'deki hemde GetBYID metodundaki
            //parametredeki id oluyor
            success:function(funk1){
                let result = jQuery.parseJSON(funk3);
                console.log(result);
                //bunları html olarak tabloya gelen veriyi yansıtalım
                let tablehtml2=`<table class=table table-bordered> <tr><th>Müşteri ID</th>
                <th>Müşteri Adı</th><th>Müşteri soyadı</th></tr><tr><td>${result.CustomerID}
                </td><td>${result.Custome");
            WriteLiteral(@"rName}</td><td>${result.CustomerSurname}</td></tr>
                </table>
                `;
                $(""#customergetbyid"").html(tablehtml2);
            }

        })

    })
    //silme işlemi
    $(""#btncustomerdelete"").click(x=>{
        let id=$(""#txtdeletedid"").val();
        $.ajax({
            url : ""/Admin/AdminCustomer/DeleteCustomer/""+id;
            type:""get"",
            contentType:""application/json"",
            dataType:""json"",
            success:function(funk4){
                alert(""Müşteri Başarılı Bir Şekilde Silindi."")
            }
        });
    });


    //güncelleme işlemi
    $(""#btncustomerupdate"").click(function(){
        //var value = $(""#customerID"").val();
        let value={
        CustomerID: $(""#txteditid"").val(),
        CustomerName:$(""#txtname"").val(),
        CustomerSurname:$(""txtsurname"").val(),
        CustomerPhone:$(""txtphone"").val(),
        CustomerMail: $(""txtmail"").val()
        };
        
        $.ajax({
    ");
            WriteLiteral("        type:\"get\",\r\n            url:\"/Admin/AdminCustomer/UpdateCustomer/\",\r\n            data:values,\r\n            success:function(funkS){\r\n                alert(\"Güncelleme İşlemi yapıldı\");\r\n            }\r\n        });\r\n\r\n    });\r\n\r\n\r\n\r\n\r\n\r\n</script>\r\n");
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