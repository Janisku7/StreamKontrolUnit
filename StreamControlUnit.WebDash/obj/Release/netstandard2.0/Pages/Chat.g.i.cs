#pragma checksum "C:\Users\janis\source\repos\StreamControlUnit.WebDash\Pages\Chat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5dce8b8fa6e58dd70b0b6e437aad4cc68221e43d"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace StreamControlUnit.WebDash.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Blazor;
    using Microsoft.AspNetCore.Blazor.Components;
    using System.Net.Http;
    using Microsoft.AspNetCore.Blazor.Layouts;
    using Microsoft.AspNetCore.Blazor.Routing;
    using Microsoft.JSInterop;
    using StreamControlUnit.WebDash;
    using StreamControlUnit.WebDash.Shared;
    using Blazor.Extensions;
    [Microsoft.AspNetCore.Blazor.Layouts.LayoutAttribute(typeof(MainLayout))]

    [Microsoft.AspNetCore.Blazor.Components.RouteAttribute("/chat")]
    public class Chat : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 20 "C:\Users\janis\source\repos\StreamControlUnit.WebDash\Pages\Chat.cshtml"
           
    string message;
    IList<string> messages = new List<string>();
    bool disabled = true;
    HubConnection connection;
    protected override async Task OnInitAsync()
    {
        connection = new HubConnectionBuilder().WithUrl("/hubs/chat").Build();
        connection.On<string>("SendAction", this.OnMessage);
        connection.On<string>("SendMessage", this.OnMessage);
        await connection.StartAsync();
        disabled = false;
    }
    Task OnMessage(string message)
    {
        messages.Add(message);
        StateHasChanged();
        return Task.CompletedTask;
    }
    async Task SendAsync()
    {
        await connection.InvokeAsync("Send", message);
        message = "";
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591
