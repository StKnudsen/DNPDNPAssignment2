#pragma checksum "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b144132848f2e302960cf02deb881c7cc434ae1"
// <auto-generated/>
#pragma warning disable 1591
namespace WebClient.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\_Imports.razor"
using WebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\_Imports.razor"
using WebClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
using Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
using WebClient.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Families")]
    public partial class Families : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Families</h1>\r\n\r\n");
            __builder.OpenElement(1, "p");
            __builder.AddMarkupContent(2, "\r\n    Search:\r\n    ");
            __builder.OpenElement(3, "input");
            __builder.AddAttribute(4, "type", "text");
            __builder.AddAttribute(5, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 9 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
                                 (arg) => filter(arg)

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 12 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
 if (familiesToShow == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(6, "<p>Loading.....</p>");
#nullable restore
#line 15 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
}
else if (!familiesToShow.Any())
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(7, "<p>No people have been added.</p>");
#nullable restore
#line 19 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "table");
            __builder.AddAttribute(9, "class", "table table-striped table-hover");
            __builder.AddMarkupContent(10, "<thead class=\"thead-dark\"><tr><th>Street</th>\r\n            <th>House number</th>\r\n            <th>Name</th>\r\n            <th>Action</th></tr></thead>\r\n        ");
            __builder.OpenElement(11, "tbody");
#nullable restore
#line 32 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
         foreach (Family family in familiesToShow)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(12, "tr");
            __builder.OpenElement(13, "td");
            __builder.AddContent(14, 
#nullable restore
#line 35 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
                     family.StreetName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n                ");
            __builder.OpenElement(16, "td");
            __builder.AddContent(17, 
#nullable restore
#line 36 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
                     family.HouseNumber

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                ");
            __builder.OpenElement(19, "td");
#nullable restore
#line 38 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
                     foreach (var person in family.Adults)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(20, "span");
            __builder.AddContent(21, 
#nullable restore
#line 40 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
                               person.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(22, " ");
            __builder.AddContent(23, 
#nullable restore
#line 40 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
                                                 person.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                        <br>");
#nullable restore
#line 42 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n                ");
            __builder.AddMarkupContent(26, "<td><button class=\"btn btn-warning\"><span class=\"oi oi-pencil\"></span></button>\r\n                    <button class=\"btn btn-danger\"><span class=\"oi oi-trash\"></span></button></td>");
            __builder.CloseElement();
#nullable restore
#line 53 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 56 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 58 "C:\Users\Tina Hadberg\RiderProjects\DNPAssignment2\WebClient\Pages\Families.razor"
       
    public List<Family> _Families { get; set; }
    public List<Family> familiesToShow { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _Families = await _familyData.GetFamilyAsync();
        familiesToShow = _Families;
    }

    private void filter(ChangeEventArgs args)
    {
        if (args.Value != null && args.Value.Equals(""))
        {
            familiesToShow = _Families;
            return;
        }

        List<Adult> allAdults = new List<Adult>();
        foreach (Family family in _Families)
        {
            allAdults.AddRange(family.Adults);
        }
        List<Adult> match = allAdults.Where(
            adult => adult.FirstName.Contains(args.Value.ToString()) || adult.LastName.Contains(args.Value.ToString())
            ).ToList();

        familiesToShow = _Families.Where(a =>
        {
            foreach (Adult adult in a.Adults)
            {
                if (match.Contains(adult))
                {
                    return true;
                }
            }
            return false;
        }).ToList();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IFamilyData _familyData { get; set; }
    }
}
#pragma warning restore 1591
